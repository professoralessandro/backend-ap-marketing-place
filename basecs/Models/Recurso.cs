using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Recurso
    {
        public int RecursoId { get; set; }
        public string Nome { get; set; }
        public string Chave { get; set; }
        public string ToolTip { get; set; }
        public string Route { get; set; }
        public bool Menu { get; set; }
        public int? RecursoIdPai { get; set; }
        public int? Ordem { get; set; }
        public bool Ativo { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Path { get; set; }
        public bool IsSubMenu { get; set; }
    }
}
