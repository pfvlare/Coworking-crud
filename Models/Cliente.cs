using System;
using System.Collections.Generic;

namespace CRUD.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
