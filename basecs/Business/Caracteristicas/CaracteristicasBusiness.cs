using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.Business.AvaliacoesBusiness;

namespace basecs.Business.Caracteristicas
{
    public class CaracteristicasBusiness : ICaracteristicasBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Caracteristica model)
        {
            string validation = "";

            if (model.CaracteristicaId > 0)
            {
                validation += "Identificação do tipo de caracteristica invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do caracteristica contem menos de dois caracteres\n";
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

            if (model.CaracteristicaId < 1)
            {
                validation += "Identificacao do tipo de caracteristica\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Caracteristica model)
        {
            string validation = "";

            if (model.CaracteristicaId == 0)
            {
                validation += "Identificação do tipo de caracteristica invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do caracteristica contem menos de dois caracteres\n";
                }
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificacao do usuario que incluiu e invalido\n";
            }

            if (model.CaracteristicaId < 1)
            {
                validation += "Identificacao do tipo de caracteristica\n";
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
                validation += "Identificação do tipo de caracteristica invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
