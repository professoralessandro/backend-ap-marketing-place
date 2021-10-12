using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Usuarios
{
    public class UsuariosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Usuario model)
        {
            string validation = "";

            if (model.UsuarioId > 0)
            {
                validation += "Identificação do usuario invalido\n";
            }

            if (model.GrupoUsaruiId < 1)
            {
                validation += "Identificação do grupo de usuario que incluiu e invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Login))
            {
                model.Login = Validators.RemoveInjections(model.Login);
                if (model.Login.Length < 3)
                {
                    validation += "O login contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.NmrDocumento))
            {
                model.NmrDocumento = Validators.RemoveInjections(model.NmrDocumento);
                if (model.NmrDocumento.Length < 3)
                {
                    validation += "O numero do documento contem menos de três caracteres\n";
                }
            }

            if (model.TipoDocumentoId < 1)
            {
                validation += "Identificação do tipo de documento que incluiu e invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Senha))
            {
                model.Senha = Validators.RemoveInjections(model.Senha);
                if (model.Senha.Length < 3)
                {
                    validation += "O numero do documento contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Nome))
            {
                model.Nome = Validators.RemoveInjections(model.Nome);
                if (model.Nome.Length < 3)
                {
                    validation += "O nome do usuario contem menos de três caracteres\n";
                }
            }

            if (model.DataNascimento.Equals(null))
            {
                validation += "A data de nascimento deve ser informada\n";
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                model.Email = Validators.RemoveInjections(model.Email);
                if (model.Email.Length < 3)
                {
                    validation += "O email contem menos de três caracteres\n";
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
                validation += "Não pode ser adicinado bloqueio inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Usuario model)
        {
            string validation = "";

            if (model.UsuarioId < 1)
            {
                validation += "Identificação do usuario invalido\n";
            }

            if (model.GrupoUsaruiId < 1)
            {
                validation += "Identificação do grupo de usuario que incluiu e invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Login))
            {
                model.Login = Validators.RemoveInjections(model.Login);
                if (model.Login.Length < 3)
                {
                    validation += "O login contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.NmrDocumento))
            {
                model.NmrDocumento = Validators.RemoveInjections(model.NmrDocumento);
                if (model.NmrDocumento.Length < 3)
                {
                    validation += "O numero do documento contem menos de três caracteres\n";
                }
            }

            if (model.TipoDocumentoId < 1)
            {
                validation += "Identificação do tipo de documento que incluiu e invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Senha))
            {
                model.Senha = Validators.RemoveInjections(model.Senha);
                if (model.Senha.Length < 3)
                {
                    validation += "O numero do documento contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Nome))
            {
                model.Nome = Validators.RemoveInjections(model.Nome);
                if (model.Nome.Length < 3)
                {
                    validation += "O nome do usuario contem menos de três caracteres\n";
                }
            }

            if (model.DataNascimento.Equals(null))
            {
                validation += "A data de nascimento deve ser informada\n";
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                model.Email = Validators.RemoveInjections(model.Email);
                if (model.Email.Length < 3)
                {
                    validation += "O email contem menos de três caracteres\n";
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

        #region DELETE
        public string DeleteValidation(int id)
        {
            string validation = "";

            if (id < 1)
            {
                validation += "Identificação do usuario invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
