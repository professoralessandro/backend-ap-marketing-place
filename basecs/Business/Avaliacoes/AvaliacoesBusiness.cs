using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Services;

namespace basecs.Business.Avaliacoes
{
    public class AvaliacoesBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Avaliacao model)
        {
            string validation = "";

            if (model.AvaliacaoId > 0)
            {
                validation += "Identificação da avaliação invalida\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 10)
                {
                    validation += "Descrição da avaliação contem menos de dez caracteres\n";
                }
            }

            if (string.IsNullOrEmpty(model.Descricao))
            {
                validation += "Descrição da avaliação nao pode ser vazia\n";
            }

            if (model.Valor < 1 || model.Valor > 5)
            {
                validation += "A avaliação nao deve ser menor que um ou maior que cinco\n";
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
                validation += "Não pode ser adicinada avaliação inativada\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Avaliacao model)
        {
            string validation = "";

            if (model.AvaliacaoId < 1)
            {
                validation += "Identificação da avaliação invalida\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 10)
                {
                    validation += "Descrição da avaliação contem menos de dez caracteres\n";
                }
            }

            if (string.IsNullOrEmpty(model.Descricao))
            {
                validation += "Descrição do avaliação nao pode ser vazia\n";
            }

            if (model.Valor < 1 || model.Valor > 5)
            {
                validation += "A avaliação nao deve ser menor que um ou maior que cinco\n";
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
                validation += "Identificação da avaliação invalida\n";
            }

            return validation;
        }
        #endregion
    }
}
