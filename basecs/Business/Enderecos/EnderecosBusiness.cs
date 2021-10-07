using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Enderecos
{
    public class EnderecosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Endereco model)
        {
            string validation = "";

            if (model.EnderecoId > 0)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (!string.IsNullOrEmpty(model.NomeEndereco))
            {
                model.NomeEndereco = Validators.RemoveInjections(model.NomeEndereco);
                if (model.NomeEndereco.Length < 3)
                {
                    validation += "Descrição do bloqueios contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioInclusaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificacao do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Endereco model)
        {
            string validation = "";

            if (model.EnderecoId == 0)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (!string.IsNullOrEmpty(model.NomeEndereco))
            {
                model.NomeEndereco = Validators.RemoveInjections(model.NomeEndereco);
                if (model.NomeEndereco.Length < 3)
                {
                    validation += "Descrição do bloqueios contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificacao do usuario que incluiu e invalido\n";
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
                validation += "Identificação do bloqueios invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
