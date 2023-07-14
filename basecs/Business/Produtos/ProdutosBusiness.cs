using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.Business.IAvaliacoesBusiness;
using System;

namespace basecs.Business.Produtos
{
    public class ProdutosBusiness : IProdutosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Produto model)
        {
            string validation = "";

            if (model.ProdutoId == Guid.Empty)
            {
                validation += "Identificação do produto invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = model.Descricao.RemoveInjections();
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do produto contem menos de três caracteres\n";
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
        public string UpdateValidation(basecs.Models.Produto model)
        {
            string validation = "";

            if (model.ProdutoId == Guid.Empty)
            {
                validation += "Identificação do produto invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = model.Descricao.RemoveInjections();
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do produto contem menos de três caracteres\n";
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
                validation += "Identificação do produto invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
