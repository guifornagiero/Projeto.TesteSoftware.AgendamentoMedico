using AgendamentoService.Domain.Entities;
using AgendamentoService.Domain.Entities.Consultas;
using AgendamentoService.Domain.Entities.Exceptions;
using AgendamentoService.Domain.Enums;
using AgendamentoService.Domain.Interfaces.Repositories;
using AgendamentoService.Domain.Interfaces.RestServices;
using AgendamentoService.Domain.Interfaces.Services;
using AgendamentoService.Domain.Interfaces.Services.Emails;
using Microsoft.Extensions.Logging;
using System.Net;

namespace AgendamentoService.Application.Services
{
    public class ConsultaService(
        ICadastroRestService _cadastroRestService,
        IConsultaRepository _consultaRepository,
        IEmailService _emailService,
        ILogger<ConsultaService> _logger) : IConsultaService
    {
        public async Task<List<Consulta>> GetAll()
        {
            return await _consultaRepository.GetAll();
        }

        public async Task<Consulta> GetById(int id)
        {
            return await _consultaRepository.GetById(id);
        }

        public async Task<bool> Delete(int id)
        {
            return await _consultaRepository.Delete(id);
        }

        public async Task<Consulta> Create(CriarConsultaDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

            try
            {
                Clinica clinica = await _cadastroRestService.GetClinicaById(dto.ClinicaId)
                    ?? throw new BusinessException(HttpStatusCode.NotFound, $"Clinica com ID {dto.ClinicaId} não encontrada.");

                Medico medico = await _cadastroRestService.GetMedicoById(dto.MedicoId)
                    ?? throw new BusinessException(HttpStatusCode.NotFound, $"Médico com ID {dto.MedicoId} não encontrado.");

                Paciente paciente = await _cadastroRestService.GetPacienteById(dto.PacienteId)
                    ?? throw new BusinessException(HttpStatusCode.NotFound, $"Paciente com ID {dto.PacienteId} não encontrado.");

                var conflito = await _consultaRepository.GetConsultaNoHorario(dto.MedicoId, dto.ClinicaId, dto.DataHora);

                if (conflito != null)
                {
                    _logger.LogInformation("Existe um conflito de horários.");
                    Consulta consulta = await _consultaRepository.Create(new()
                    {
                        ClinicaId = dto.ClinicaId,
                        MedicoId = dto.MedicoId,
                        PacienteId = dto.PacienteId,
                        DataHora = dto.DataHora,
                        Status = StatusAgendamento.AguardandoHorario
                    });

                    await _emailService.EnviarEmail(
                        paciente.Email,
                        "Conflito na consulta",
                        "Sua consulta possui um conflito de horários. Ela será salva e estará no status de Aguardando Horário. Altere o horário ou aguarde para continuar."
                    );

                    return consulta;
                }

                return await _consultaRepository.Create(new()
                {
                    ClinicaId = dto.ClinicaId,
                    MedicoId = dto.MedicoId,
                    PacienteId = dto.PacienteId,
                    DataHora = dto.DataHora,
                    Status = StatusAgendamento.Agendado
                });
            }
            catch (BusinessException ex)
            {
                _logger.LogWarning("BusinessException durante o processamento.");
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
