using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.Business.AvaliacoesBusiness;
using System;

namespace basecs.Business.Bloqueios
{
    public class BloqueiosBusiness : IBloqueiosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Bloqueio model)
        {
            string validation = "";

            if (model.BloqueioId == Guid.Empty)
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

            if (model.UsuarioInclusaoId == Guid.Empty)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Bloqueio model)
        {
            string validation = "";

            if (model.BloqueioId == Guid.Empty)
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

            if (model.UsuarioUltimaAlteracaoId == Guid.Empty)
            {
                validation += "Identificacao do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region DELETE
        public string DeleteValidation(Guid id)
        {
            string validation = "";

            if (id == Guid.Empty)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
