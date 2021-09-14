using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class DadosBancario
    {
        public DadosBancario()
        {
            UsuariosDadosBancarios = new HashSet<UsuariosDadosBancario>();
        }

        public int DadoBancarioId { get; set; }
        public int UsuarioId { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Tipo { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<UsuariosDadosBancario> UsuariosDadosBancarios { get; set; }
    }
}
