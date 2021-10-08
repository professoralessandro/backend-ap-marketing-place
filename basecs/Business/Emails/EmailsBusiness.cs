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
                validation += "Identificação tipod de email e invalida\n";
            }

            if (!string.IsNullOrEmpty(model.NomeEmail))
            {
                model.NomeEmail = Validators.RemoveInjections(model.NomeEmail);
                if (model.NomeEmail.Length < 3)
                {
                    validation += "Descrição do bloqueios contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Destinatario))
            {
                model.Destinatario = Validators.RemoveInjections(model.Destinatario);
                if (model.Destinatario.Length < 3)
                {
                    validation += "Descrição do destinatário contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Assunto))
            {
                model.NomeEmail = Validators.RemoveInjections(model.Assunto);
                if (model.Assunto.Length < 3)
                {
                    validation += "Descrição do assunto contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Mensagem))
            {
                model.Mensagem = Validators.RemoveInjections(model.Mensagem);
                if (model.Mensagem.Length < 3)
                {
                    validation += "A mensagem contem menos de três caracteres\n";
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

            if (model.EmailId == 0)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (model.UsuarioEnvioId < 1)
            {
                validation += "Identificação do usuario que enviou e invalida\n";
            }

            if (model.TipoEmailId < 1)
            {
                validation += "Identificação tipod de email e invalida\n";
            }

            if (!string.IsNullOrEmpty(model.NomeEmail))
            {
                model.NomeEmail = Validators.RemoveInjections(model.NomeEmail);
                if (model.NomeEmail.Length < 3)
                {
                    validation += "Descrição do bloqueios contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Destinatario))
            {
                model.Destinatario = Validators.RemoveInjections(model.Destinatario);
                if (model.Destinatario.Length < 3)
                {
                    validation += "Descrição do destinatário contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Assunto))
            {
                model.NomeEmail = Validators.RemoveInjections(model.Assunto);
                if (model.Assunto.Length < 3)
                {
                    validation += "Descrição do assunto contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Mensagem))
            {
                model.Mensagem = Validators.RemoveInjections(model.Mensagem);
                if (model.Mensagem.Length < 3)
                {
                    validation += "A mensagem contem menos de três caracteres\n";
                }
            }

            // LINHAS DE TESTE
            // VERIFICAR AQUI SE O STATUS DO EMAIL E IGUAL A ENVIADO E MUDAR ESTA CONDICAO
            if (model.StatusEnvio < 1)
            {
                validation += "Um email uma vez enviado nao pode ser alterado\n";
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
                validation += "Um email excluido nao pode ser alterado\n";
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
