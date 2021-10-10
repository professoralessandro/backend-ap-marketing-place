using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Telefones
{
    public class TelefonesBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Telefone model)
        {
            string validation = "";

            if (model.TelefoneId > 0)
            {
                validation += "Identificação do telefone invalida\n";
            }

            if (model.TipoTelefoneId < 1)
            {
                validation += "Identificação do tipo telefone invalida\n";
            }

            if (!string.IsNullOrEmpty(model.Numero))
            {
                model.Numero = Validators.RemoveInjections(model.Numero);
                if (model.Numero.Length < 10)
                {
                    validation += "Descrição do telefone contem menos de dez caracteres\n";
                }

                if (!int.TryParse(model.Numero, out int n))
                {
                    validation += "O campo nao esta no formato numerico\n";
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
                validation += "Não pode ser adicinado tipo de telefone inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Telefone model)
        {
            string validation = "";

            if (model.TelefoneId < 1)
            {
                validation += "Identificação do tipo de telefone invalido\n";
            }

            if (model.TipoTelefoneId < 1)
            {
                validation += "Identificação do tipo telefone invalida\n";
            }

            if (!string.IsNullOrEmpty(model.Numero))
            {
                model.Numero = Validators.RemoveInjections(model.Numero);
                if (model.Numero.Length < 10)
                {
                    validation += "Descrição do telefone contem menos de dez caracteres\n";
                }

                if (!int.TryParse(model.Numero, out int n))
                {
                    validation += "O campo nao esta no formato numerico\n";
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
                validation += "Identificação do tipo de telefone invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
