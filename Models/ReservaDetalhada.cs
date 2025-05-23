using System;

namespace CRUD.Models
{
    public class ReservaDetalhada
    {
        public int ReservaId { get; set; }

        public string Cliente { get; set; } = null!;

        public string Sala { get; set; } = null!;

        public string TipoSala { get; set; } = null!;

        public int Capacidade { get; set; }

        public decimal PrecoHora { get; set; }

        public DateTime DataReserva { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFim { get; set; }

        public string? Observacoes { get; set; }
    }
}
