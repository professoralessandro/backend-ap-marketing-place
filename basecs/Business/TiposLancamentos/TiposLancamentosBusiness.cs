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
                validation += "Identificação do tipo de lançamento invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do lançamento contem menos de três caracteres\n";
                }
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
                validation += "Não pode ser adicinado tipo de lançamento inativado\n";
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
                validation += "Identificação do tipo de lançamento invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do lançamento contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificaçao do usuario que incluiu e invalido\n";
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
                validation += "Identificação do tipo de lançamento invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
