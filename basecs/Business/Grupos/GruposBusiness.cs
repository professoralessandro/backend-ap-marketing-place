using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Grupos
{
    public class GruposBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Grupo model)
        {
            string validation = "";

            if (model.GrupoId > 0)
            {
                validation += "Identificação do grupo invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do grupo contem menos de três caracteres\n";
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
                validation += "Não pode ser adicinado bloqueio inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Grupo model)
        {
            string validation = "";

            if (model.GrupoId < 1)
            {
                validation += "Identificação do grupo invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do grupo contem menos de três caracteres\n";
                }
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
                validation += "Identificação do grupo invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
