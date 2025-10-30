using AgendamentoService.Domain.Entities;

namespace AgendamentoService.Domain.Interfaces.RestServices
{
    public interface ICadastroRestService
    {
        Task<List<Medico>> GetMedicosByEspecialidade(int especialidadeId);
        Task<Clinica> GetClinicaById(int clinicaId);
        Task<Medico> GetMedicoById(int id);
        Task<Paciente> GetPacienteById(int id);
    }
}
