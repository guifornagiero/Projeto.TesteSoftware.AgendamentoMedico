using CadastroService.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClinicaController(IClinicaService _clinicaService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var clinicas = await _clinicaService.GetAll();
            return Ok(clinicas);
        }
    }
}
