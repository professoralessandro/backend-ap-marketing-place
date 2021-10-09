using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Pagamentos
{
    public class PagamentosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Pagamento model)
        {
            string validation = "";

            if (model.PagamentoId > 0)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (model.LancamentoId < 1)
            {
                validation += "Identificação do lancamento que incluiu e invalido\n";
            }

            if (model.UsuarioInclusaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            if (!model.Ativo)
            {
                validation += "Não pode ser adicinado um pagamento inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Pagamento model)
        {
            string validation = "";

            if (model.PagamentoId < 1)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (model.LancamentoId < 1)
            {
                validation += "Identificação do lancamento que incluiu e invalido\n";
            }

            if (model.UsuarioInclusaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region DELETE
        public string DeleteValidation(int id)
        {
            string validation = "";

            if (id < 1)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
