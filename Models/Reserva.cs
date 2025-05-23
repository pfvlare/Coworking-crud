using System;

namespace CRUD.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int SalaId { get; set; }

        public DateTime DataReserva { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFim { get; set; }

        public string? Observacoes { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;

        public virtual Sala Sala { get; set; } = null!;
    }
}
