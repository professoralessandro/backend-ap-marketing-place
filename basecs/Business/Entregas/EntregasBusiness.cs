using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Entregas
{
    public class EntregasBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Entrega model)
        {
            string validation = "";

            if (model.EntregaId > 0)
            {
                validation += "Identificação da entrega invalido\n";
            }

            if (!string.IsNullOrEmpty(model.NmrDocumento))
            {
                model.NmrDocumento = Validators.RemoveInjections(model.NmrDocumento);
                if (model.NmrDocumento.Length < 3)
                {
                    validation += "O numero do documento do destinatario contem menos de três caracteres\n";
                }
            }

            if (model.TipoDocumentoId < 1)
            {
                validation += "Identificação do tipo de documento que incluiu e invalido\n";
            }

            if (!string.IsNullOrEmpty(model.NomeRecebedor))
            {
                model.NmrDocumento = Validators.RemoveInjections(model.NmrDocumento);
                if (model.NmrDocumento.Length < 3)
                {
                    validation += "O nome do destinatário contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.NmrDocumento))
            {
                model.NmrDocumento = Validators.RemoveInjections(model.NmrDocumento);
                if (model.NmrDocumento.Length < 3)
                {
                    validation += "O numero do documento do destinatario contem menos de três caracteres\n";
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
                validation += "Não e possível adicionar uma entrega inativada\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Entrega model)
        {
            string validation = "";

            if (model.EntregaId < 1)
            {
                validation += "Identificação da entrega invalido\n";
            }

            if (!string.IsNullOrEmpty(model.NmrDocumento))
            {
                model.NmrDocumento = Validators.RemoveInjections(model.NmrDocumento);
                if (model.NmrDocumento.Length < 3)
                {
                    validation += "O numero do documento do destinatario contem menos de três caracteres\n";
                }
            }

            if (model.TipoDocumentoId < 1)
            {
                validation += "Identificação do tipo de documento que incluiu e invalido\n";
            }

            if (!string.IsNullOrEmpty(model.NomeRecebedor))
            {
                model.NmrDocumento = Validators.RemoveInjections(model.NmrDocumento);
                if (model.NmrDocumento.Length < 3)
                {
                    validation += "O nome do destinatário contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.NmrDocumento))
            {
                model.NmrDocumento = Validators.RemoveInjections(model.NmrDocumento);
                if (model.NmrDocumento.Length < 3)
                {
                    validation += "O numero do documento do destinatario contem menos de três caracteres\n";
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

            return validation;
        }
        #endregion

        #region UPDATE
        public string DeleteValidation(int id)
        {
            string validation = "";

            if (id == 0)
            {
                validation += "Identificação do tipo de entrega invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
