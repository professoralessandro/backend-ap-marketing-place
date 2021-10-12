using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Emails
{
    public class EmailsBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Email model)
        {
            string validation = "";

            if (model.EmailId > 0)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (model.UsuarioEnvioId < 1)
            {
                validation += "Identificação do usuario que enviou e invalida\n";
            }

            if (model.TipoEmailId < 1)
            {
                validation += "Identificação tipo de email e invalida\n";
            }

            if (!string.IsNullOrEmpty(model.NomeEmail))
            {
                model.NomeEmail = Validators.RemoveInjections(model.NomeEmail);
                if (model.NomeEmail.Length < 5 || model.NomeEmail.Length > 100)
                {
                    validation += "Descrição do bloqueios contem menos de cem caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Assunto))
            {
                model.Destinatario = Validators.RemoveInjections(model.Destinatario);
                if (model.Destinatario.Length < 5 || model.Destinatario.Length > 150)
                {
                    validation += "Descrição do assunto contem menos de cinco ou mais de cem caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Destinatario))
            {
                model.Destinatario = Validators.RemoveInjections(model.Destinatario);
                if (model.Destinatario.Length < 5 || model.Destinatario.Length > 150)
                {
                    validation += "Descrição do destinatário contem menos de cinco ou mais de cento e cinquenta caracteres\n";
                }
            }

            if (string.IsNullOrEmpty(model.Destinatario))
            {
                validation += "Descrição do destinatário não pode ser vazia\n";
            }

            if (!string.IsNullOrEmpty(model.Assunto))
            {
                model.NomeEmail = Validators.RemoveInjections(model.Assunto);
                if (model.Assunto.Length < 5 || model.Assunto.Length > 100)
                {
                    validation += "Descrição do assunto contem menos de cinco ou mais de 100 caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Mensagem))
            {
                model.Mensagem = Validators.RemoveInjections(model.Mensagem);
                if (model.Mensagem.Length < 15)
                {
                    validation += "A mensagem contem menos de quinze caracteres\n";
                }
            }

            if (model.StatusEnvio < 1)
            {
                validation += "O email que esta tentando inserir esta com status enviado\n";
            }

            if (model.Tentativas > 0)
            {
                validation += "O email que esta tentando inserir esta contem o numero de tentativas de envio preenchido\n";
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
                validation += "Não pode ser adicinado email inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Email model)
        {
            string validation = "";

            if (model.UsuarioEnvioId < 1)
            {
                validation += "Identificação do usuario que enviou e invalida\n";
            }

            if (model.TipoEmailId < 1)
            {
                validation += "Identificação tipo de email e invalida\n";
            }

            if (!string.IsNullOrEmpty(model.NomeEmail))
            {
                model.NomeEmail = Validators.RemoveInjections(model.NomeEmail);
                if (model.NomeEmail.Length < 5 || model.NomeEmail.Length > 100)
                {
                    validation += "Descrição do bloqueios contem menos de cem caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Assunto))
            {
                model.Destinatario = Validators.RemoveInjections(model.Destinatario);
                if (model.Destinatario.Length < 5 || model.Destinatario.Length > 150)
                {
                    validation += "Descrição do assunto contem menos de cinco ou mais de cem caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Destinatario))
            {
                model.Destinatario = Validators.RemoveInjections(model.Destinatario);
                if (model.Destinatario.Length < 5 || model.Destinatario.Length > 150)
                {
                    validation += "Descrição do destinatário contem menos de cinco ou mais de cento e cinquenta caracteres\n";
                }
            }

            if (string.IsNullOrEmpty(model.Destinatario))
            {
                validation += "Descrição do destinatário não pode ser vazia\n";
            }

            if (!string.IsNullOrEmpty(model.Assunto))
            {
                model.NomeEmail = Validators.RemoveInjections(model.Assunto);
                if (model.Assunto.Length < 5 || model.Assunto.Length > 100)
                {
                    validation += "Descrição do assunto contem menos de cinco ou mais de 100 caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Mensagem))
            {
                model.Mensagem = Validators.RemoveInjections(model.Mensagem);
                if (model.Mensagem.Length < 15)
                {
                    validation += "A mensagem contem menos de quinze caracteres\n";
                }
            }

            if (model.StatusEnvio < 1)
            {
                validation += "O email que esta tentando inserir esta com status enviado\n";
            }

            if (model.Tentativas > 0)
            {
                validation += "O email que esta tentando inserir esta contem o numero de tentativas de envio preenchido\n";
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
                validation += "Identificação do email invalida\n";
            }

            return validation;
        }
        #endregion
    }
}
