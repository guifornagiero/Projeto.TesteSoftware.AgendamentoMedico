using CadastroService.Application.Services.Clinicas;
using CadastroService.Domain.Interfaces.Data;
using CadastroService.Domain.Interfaces.Repositories.Clinicas;
using CadastroService.Domain.Interfaces.Services;
using CadastroService.Infraestructure.Data;
using CadastroService.Infraestructure.Repositories.Clinicas;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroService.Infraestructure.CrossCutting
{
    public static class DependencyInjection
    {
        public static void Inject(IServiceCollection services)
        {
            // Data
            services.AddSingleton<ISQliteContext, SQliteContext>();

            // Services
            services.AddSingleton<IClinicaService, ClinicaService>();

            // Repository
            services.AddSingleton<IClinicaRepository, ClinicaRepository>();
        }
    }
}
