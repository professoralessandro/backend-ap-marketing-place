using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Bloqueios
{
    public class BloqueiosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Bloqueio model)
        {
            string validation = "";

            if (model.BloqueioId > 0)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (!string.IsNullOrEmpty(model.NomeBloqueio))
            {
                model.NomeBloqueio = Validators.RemoveInjections(model.NomeBloqueio);
                if (model.NomeBloqueio.Length < 3 || model.NomeBloqueio.Length > 100)
                {
                    validation += "Descrição do bloqueios contem menos de três ou mais que cem caracteres\n";
                }
            }

            if (string.IsNullOrEmpty(model.NomeBloqueio))
            {
                validation += "Descrição do bloqueio nao pode ser vazia\n";
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
        public string UpdateValidation(basecs.Models.Bloqueio model)
        {
            string validation = "";

            if (model.BloqueioId < 1)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (!string.IsNullOrEmpty(model.NomeBloqueio))
            {
                model.NomeBloqueio = Validators.RemoveInjections(model.NomeBloqueio);
                if (model.NomeBloqueio.Length < 3 || model.NomeBloqueio.Length > 100)
                {
                    validation += "Descrição do bloqueios contem menos de três ou mais que cem caracteres\n";
                }
            }

            if (string.IsNullOrEmpty(model.NomeBloqueio))
            {
                validation += "Descrição do bloqueio nao pode ser vazia\n";
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
