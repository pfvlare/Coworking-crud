using System.Collections.Generic;

namespace CRUD.Models
{
    public class TipoSala
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public int Capacidade { get; set; }

        public decimal PrecoHora { get; set; }

        public virtual ICollection<Sala> Salas { get; set; } = new List<Sala>();
    }
}
