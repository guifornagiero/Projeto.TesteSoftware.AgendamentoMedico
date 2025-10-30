using AgendamentoService.Domain.Entities;
using AgendamentoService.Domain.Interfaces.RestServices;
using System.Net.Http.Json;
using System.Text.Json;

namespace AgendamentoService.Infraestructure.RestServices
{
    public class CadastroRestService : ICadastroRestService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public CadastroRestService(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<Medico>> GetMedicosByEspecialidade(int especialidadeId)
        {
            var response = await _httpClient.GetFromJsonAsync<List<Medico>>($"Medico/ByEspecialidade/{especialidadeId}", _jsonOptions);
            return response ?? new List<Medico>();
        }

        public async Task<Clinica> GetClinicaById(int clinicaId)
        {
            var response = await _httpClient.GetFromJsonAsync<Clinica>($"Clinica/{clinicaId}", _jsonOptions);
            return response;
        }

        public async Task<Medico> GetMedicoById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Medico>($"Medico/{id}", _jsonOptions);
            return response;
        }

        public async Task<Paciente> GetPacienteById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Paciente>($"Paciente/{id}", _jsonOptions);
            return response;
        }
    }
}
