using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.Business.AvaliacoesBusiness;

namespace basecs.Business.Bloqueios
{
    public class BloqueiosBusiness : IBloqueiosBusiness
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
                model.NomeBloqueio = model.NomeBloqueio.RemoveInjections();
                if (model.NomeBloqueio.Length < 3)
                {
                    validation += "Descrição do bloqueios contem menos de três caracteres\n";
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
        public string UpdateValidation(basecs.Models.Bloqueio model)
        {
            string validation = "";

            if (model.BloqueioId == 0)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (!string.IsNullOrEmpty(model.NomeBloqueio))
            {
                model.NomeBloqueio = model.NomeBloqueio.RemoveInjections();
                if (model.NomeBloqueio.Length < 3)
                {
                    validation += "Descrição do bloqueios contem menos de três caracteres\n";
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
                validation += "Identificação do bloqueios invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
