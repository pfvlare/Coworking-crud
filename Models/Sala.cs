using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Sala
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da sala é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O tipo de sala é obrigatório.")]
        [Display(Name = "Tipo de Sala")]
        public int TipoSalaId { get; set; }

        public virtual TipoSala TipoSala { get; set; } = null!;

        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
