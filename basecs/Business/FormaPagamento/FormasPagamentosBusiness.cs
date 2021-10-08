using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.FormasPagamentos
{
    public class FormasPagamentosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.FormaPagamento model)
        {
            string validation = "";

            if (model.FormaPagamentoId > 0)
            {
                validation += "Identificação do tipo de bloqueio invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do bloqueio contem menos de três caracteres\n";
                }
            }            

            if (model.UsuarioInclusaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificacao do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.FormaPagamento model)
        {
            string validation = "";

            if (model.FormaPagamentoId == 0)
            {
                validation += "Identificação do tipo de bloqueio invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do bloqueio contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificacao do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string DeleteValidation(int id)
        {
            string validation = "";

            if (id == 0)
            {
                validation += "Identificação do tipo de bloqueio invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
