using System.Collections.Generic;

namespace CRUD.Models
{
    public class Sala
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public int TipoSalaId { get; set; }

        public virtual TipoSala TipoSala { get; set; } = null!;

        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
