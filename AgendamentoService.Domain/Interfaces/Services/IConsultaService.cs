using AgendamentoService.Domain.Entities.Consultas;

namespace AgendamentoService.Domain.Interfaces.Services
{
    public interface IConsultaService
    {
        Task<List<Consulta>> GetAll();
        Task<Consulta> GetById(int id);
        Task<bool> Delete(int id);
        Task<Consulta> Create(CriarConsultaDTO dto);
    }
}
