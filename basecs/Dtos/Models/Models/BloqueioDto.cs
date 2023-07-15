using basecs.Enuns;
using System;

#nullable disable

namespace basecs.Models
{
    public partial class BloqueioDto
    {
        public Guid BloqueioId { get; set; }

        public TipoBloqueioEnum TipoBloqueio { get; set; }

        public int ItemBloqueadoId { get; set; }

        public string NomeBloqueio { get; set; }

        public bool IsBloqueiaAcesso { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
