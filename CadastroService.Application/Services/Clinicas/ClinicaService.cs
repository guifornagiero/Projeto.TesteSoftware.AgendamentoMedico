using CadastroService.Domain.Entities.Clinicas;
using CadastroService.Domain.Interfaces.Repositories.Clinicas;
using CadastroService.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace CadastroService.Application.Services.Clinicas
{
    public class ClinicaService(
        ILogger<ClinicaService> _logger,
        IClinicaRepository _clinicaRepository) : IClinicaService
    {
        public async Task<List<Clinica>> GetAll()
        {
            try
            {
                _logger.LogInformation("Buscando todas as Clinicas.");
                return await _clinicaRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro durante GetAll.");
                throw;
            }
        }
    }
}
