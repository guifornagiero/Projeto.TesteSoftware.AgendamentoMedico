using CadastroService.Domain.Entities.Clinicas;

namespace CadastroService.Domain.Interfaces.Repositories.Clinicas
{
    public interface IClinicaRepository
    {
        Task<List<Clinica>> GetAll();
    }
}
