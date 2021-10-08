using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Mensagems
{
    public class MensagemsBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Mensagem model)
        {
            string validation = "";

            if (model.MensagemId > 0)
            {
                validation += "Identificação do mensagems invalido\n";
            }

            if (model.RemetenteId < 1)
            {
                validation += "Identificação do remetente invalido\n";
            }

            if (!string.IsNullOrEmpty(model.MensagemContexto))
            {
                model.MensagemContexto = Validators.RemoveInjections(model.MensagemContexto);
                if (model.MensagemContexto.Length < 3)
                {
                    validation += "Descrição da mensagem contem menos de três caracteres\n";
                }
            }

            if (model.TipoMensagemId < 1)
            {
                validation += "Identificação do tipo de mensagem invalido\n";
            }

            if (model.IsHtml.Equals(null))
            {
                validation += "Identificação do conteudo da mensagem invalido\n";
            }

            if (model.DestinatarioId < 1)
            {
                validation += "Identificação do remetente invalido\n";
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
                validation += "Não pode ser adicinado mensagem inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Mensagem model)
        {
            string validation = "";

            if (model.MensagemId < 1)
            {
                validation += "Identificação do mensagems invalido\n";
            }

            if (model.RemetenteId < 1)
            {
                validation += "Identificação do remetente invalido\n";
            }

            if (!string.IsNullOrEmpty(model.MensagemContexto))
            {
                model.MensagemContexto = Validators.RemoveInjections(model.MensagemContexto);
                if (model.MensagemContexto.Length < 3)
                {
                    validation += "Descrição da mensagem contem menos de três caracteres\n";
                }
            }

            if (model.TipoMensagemId < 1)
            {
                validation += "Identificação do tipo de mensagem invalido\n";
            }

            if (model.IsHtml.Equals(null))
            {
                validation += "Identificação do conteudo da mensagem invalido\n";
            }

            if (model.DestinatarioId < 1)
            {
                validation += "Identificação do remetente invalido\n";
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
                validation += "Identificação do mensagems invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
