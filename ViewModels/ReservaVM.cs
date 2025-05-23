using CRUD.Models;
using System.ComponentModel.DataAnnotations;

namespace CRUD.ViewModels
{
    public class ReservaVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Data da reserva é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataReserva { get; set; }

        [Required(ErrorMessage = "Hora de início é obrigatória.")]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "Hora de término é obrigatória.")]
        [DataType(DataType.Time)]
        public TimeSpan HoraFim { get; set; }

        [Required(ErrorMessage = "Cliente é obrigatório.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Sala é obrigatória.")]
        public int SalaId { get; set; }

        public string? Observacoes { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Valor deve ser maior ou igual a zero.")]
        public decimal Valor { get; set; }

        // Referências diretas ao modelo real
        public Cliente? Cliente { get; set; }
        public Sala? Sala { get; set; }

        // Listas para usar em selects
        public List<Cliente>? Clientes { get; set; }
        public List<Sala>? Salas { get; set; }
    }
}
