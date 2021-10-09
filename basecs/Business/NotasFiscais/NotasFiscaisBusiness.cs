using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.NotasFiscais
{
    public class NotasFiscaisBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.NotaFiscal model)
        {
            string validation = "";

            if (model.NotaFiscalId > 0)
            {
                validation += "Identificação do nota fiscal invalido\n";
            }

            if (model.TipoNotaFiscalId < 1)
            {
                validation += "Identificação do tipo de nota fiscal invalido\n";
            }

            if (!string.IsNullOrEmpty(model.ChaveAcesso))
            {
                model.ChaveAcesso = Validators.RemoveInjections(model.ChaveAcesso);
                if (model.ChaveAcesso.Length < 25 || !int.TryParse(model.ChaveAcesso, out int n))
                {
                    validation += "A chave de acesso e invalida\n";
                }
            }

            if (model.UsuarioId < 1)
            {
                validation += "Identificação do emissor da nota fiscal invalido\n";
            }

            if (model.DestinatarioId < 1)
            {
                validation += "Identificação do destinatário da nota fiscal invalido\n";
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
                validation += "Não pode ser adicinado notas fiscais inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.NotaFiscal model)
        {
            string validation = "";

            if (model.NotaFiscalId < 1)
            {
                validation += "Identificação da nota fiscal invalido\n";
            }

            if (model.TipoNotaFiscalId < 1)
            {
                validation += "Identificação do tipo de nota fiscal invalido\n";
            }

            if (model.UsuarioId < 1)
            {
                validation += "Identificação do emissor da nota fiscal invalido\n";
            }

            if (model.DestinatarioId < 1)
            {
                validation += "Identificação do destinatário da nota fiscal invalido\n";
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
                validation += "Identificação do tipo de nota fiscal invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
