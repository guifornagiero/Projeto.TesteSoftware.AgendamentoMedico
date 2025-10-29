using CadastroService.Domain.Entities.Clinicas;
using CadastroService.Domain.Interfaces.Data;
using CadastroService.Domain.Interfaces.Repositories.Clinicas;
using Dapper;

namespace CadastroService.Infraestructure.Repositories.Clinicas
{
    public class ClinicaRepository(ISQliteContext _context) : IClinicaRepository
    {
        public async Task<List<Clinica>> GetAll()
        {
            using var connection = _context.CreateConnection();
            return [.. await connection.QueryAsync<Clinica>("SELECT * FROM Clinicas;")];
        }
    }
}
