namespace AgendamentoService.Domain.Entities
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EspecialidadeId { get; set; }
        public string CRM { get; set; }
    }
}
