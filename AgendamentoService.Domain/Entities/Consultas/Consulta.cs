using AgendamentoService.Domain.Enums;

namespace AgendamentoService.Domain.Entities.Consultas
{
    public class Consulta
    {
        public int Id { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        public int ClinicaId { get; set; }
        public Clinica Clinica { get; set; }

        public DateTime DataHora { get; set; }
        public string Observacoes { get; set; }
        public StatusAgendamento Status { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}
