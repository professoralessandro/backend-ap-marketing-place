using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Bloqueio
    {
        public Bloqueio()
        {
            BloqueiosProdutos = new HashSet<BloqueioProduto>();
            BloqueiosUsuarios = new HashSet<BloqueioUsuario>();
        }

        public int BloqueioId { get; set; }
        public int TipoBloqueioId { get; set; }
        public int ItemBloqueadoId { get; set; }
        public string NomeBloqueio { get; set; }
        public bool IsBloqueiaAcesso { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual TipoBloqueio TipoBloqueio { get; set; }
        public virtual ICollection<BloqueioProduto> BloqueiosProdutos { get; set; }
        public virtual ICollection<BloqueioUsuario> BloqueiosUsuarios { get; set; }
    }
}
