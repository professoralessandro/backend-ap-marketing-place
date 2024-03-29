﻿using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class CartoesBancario
    {
        public int CartaoBancarioId { get; set; }
        public int UsuarioId { get; set; }
        public string Numero { get; set; }
        public string NomeNoCartao { get; set; }
        public string Bandeira { get; set; }
        public string Validade { get; set; }
        public string Tipo { get; set; }
        public string CodSeg { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
