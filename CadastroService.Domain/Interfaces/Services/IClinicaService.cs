using CadastroService.Domain.Entities.Clinicas;

namespace CadastroService.Domain.Interfaces.Services
{
    public interface IClinicaService
    {
        Task<List<Clinica>> GetAll();
    }
}
