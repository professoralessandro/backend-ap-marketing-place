using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.TiposLancamentosLancamentos
{
    public class TiposLancamentosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.TipoLancamento model)
        {
            string validation = "";

            if (model.TipoLancamentoId > 0)
            {
                validation += "Identificação do tipo de lancamento invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do lancamento contem menos de três caracteres\n";
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
        public string UpdateValidation(basecs.Models.TipoLancamento model)
        {
            string validation = "";

            if (model.TipoLancamentoId == 0)
            {
                validation += "Identificação do tipo de lancamento invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do lancamento contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificacao do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region DELETE
        public string DeleteValidation(int id)
        {
            string validation = "";

            if (id == 0)
            {
                validation += "Identificação do tipo de lancamento invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
