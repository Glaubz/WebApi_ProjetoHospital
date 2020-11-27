using ProjetoUnip.Domain.Person;

namespace ProjetoUnip.Domain.Util
{
    public class MedicoConsulta
    {
        public int Id { get; set; }
        public long ConsultaId { get; set; }
        //public Consulta Consulta { get; set; }
        public long MedicoId { get; set; }
        //public Medico Medico { get; set; }
        public string Tratamento { get; set; }
    }
}