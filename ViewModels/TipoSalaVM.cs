using System.ComponentModel.DataAnnotations;

namespace CRUD.ViewModels
{
    public class TipoSalaVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da sala é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A capacidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade deve ser maior que zero.")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = "O preço por hora é obrigatório.")]
        [Display(Name = "Preço por hora")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser maior ou igual a zero.")]
        public decimal Valor { get; set; }
    }
}
