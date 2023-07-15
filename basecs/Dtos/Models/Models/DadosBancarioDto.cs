using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class DadosBancarioDto
    {
        public Guid DadoBancarioId { get; set; }

        public Guid UsuarioId { get; set; }

        public string Banco { get; set; }

        public string Agencia { get; set; }

        public string Conta { get; set; }

        public string Tipo { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
