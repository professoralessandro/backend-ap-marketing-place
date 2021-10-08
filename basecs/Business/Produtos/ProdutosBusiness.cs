using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Produtos
{
    public class ProdutosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Produto model)
        {
            string validation = "";

            if (model.ProdutoId > 0)
            {
                validation += "Identificação do produto invalido\n";
            }

            if (model.TipoProdutoId < 1)
            {
                validation += "Identificação tipo de produto invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do produto contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Detalhes))
            {
                model.Detalhes = Validators.RemoveInjections(model.Detalhes);
                if (model.Detalhes.Length < 30)
                {
                    validation += "Os detalhes do produto contem menos de trinta caracteres\n";
                }
            }

            if (model.Quantidade.Equals(null) || model.Quantidade < 1)
            {
                validation += "A quantidade disponivel deve ser maior que 0\n";
            }

            if (model.PrecoCusto.Equals(null))
            {
                validation += "O preço de custo e obrigatório\n";
            }

            if (model.PrecoCusto.Equals(null))
            {
                validation += "O preço de custo e obrigatório\n";
            }

            if (model.PrecoVenda.Equals(null) || model.PrecoVenda < 1)
            {
                validation += "O preço de venda deve ser maior que R$ 0,99\n";
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
        public string UpdateValidation(basecs.Models.Produto model)
        {
            string validation = "";

            if (model.ProdutoId < 1)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (model.TipoProdutoId < 1)
            {
                validation += "Identificação tipo de produto invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do produto contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Detalhes))
            {
                model.Detalhes = Validators.RemoveInjections(model.Detalhes);
                if (model.Detalhes.Length < 30)
                {
                    validation += "Os detalhes do produto contem menos de trinta caracteres\n";
                }
            }

            if (model.Quantidade.Equals(null) || model.Quantidade < 1)
            {
                validation += "A quantidade disponivel deve ser maior que 0\n";
            }

            if (model.PrecoCusto.Equals(null))
            {
                validation += "O preço de custo e obrigatório\n";
            }

            if (model.PrecoCusto.Equals(null))
            {
                validation += "O preço de custo e obrigatório\n";
            }

            if (model.PrecoVenda.Equals(null) || model.PrecoVenda < 1)
            {
                validation += "O preço de venda deve ser maior que R$ 0,99\n";
            }

            if (model.UsuarioInclusaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
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
