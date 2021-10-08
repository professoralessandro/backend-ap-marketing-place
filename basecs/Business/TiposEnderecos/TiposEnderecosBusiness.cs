
using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.TiposEnderecos
{
    public class TiposEnderecosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.TipoEndereco model)
        {
            string validation = "";

            if (model.TipoEnderecoId > 0)
            {
                validation += "Identificação do tipo de endereco invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do endereco contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioInclusaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificaçao do usuario que incluiu e invalido\n";
            }

            if (!model.Ativo)
            {
                validation += "Não pode ser adicinado tipo de endereço inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.TipoEndereco model)
        {
            string validation = "";

            if (model.TipoEnderecoId == 0)
            {
                validation += "Identificação do tipo de endereco invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do endereco contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificaçao do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string DeleteValidation(int id)
        {
            string validation = "";

            if (id < 1)
            {
                validation += "Identificação do tipo de endereco invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
