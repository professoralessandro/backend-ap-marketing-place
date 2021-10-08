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

            if (model.TipoEnderecoId < 1)
            {
                validation += "Identificação do tipo de endereço que incluiu e invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Logradouro))
            {
                model.Logradouro = Validators.RemoveInjections(model.Logradouro);
                if (model.Logradouro.Length < 3)
                {
                    validation += "Descrição do logradouro contem menos de três caracteres\n";
                }
            }

            if (!int.TryParse(model.Numero, out int n))
            {
                model.Logradouro = Validators.RemoveInjections(model.Logradouro);
                if (model.Logradouro.Length < 3)
                {
                    validation += "O número informado não esta no formato correto\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Cidade))
            {
                model.Cidade = Validators.RemoveInjections(model.Cidade);
                if (model.Cidade.Length < 3)
                {
                    validation += "Descrição da cidade contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Estado))
            {
                model.Estado = Validators.RemoveInjections(model.Estado);
                if (model.Estado.Length != 2)
                {
                    validation += "o Estado não esta no formato correto\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Cep))
            {
                model.Cidade = Validators.RemoveInjections(model.Cidade);
                if (model.Cep.Length != 8)
                {
                    validation += "o CEP não esta no formato correto\n";
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
                validation += "O endereco não pode estar bloqueado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Endereco model)
        {
            string validation = "";

            if (model.EnderecoId < 1)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (model.TipoEnderecoId < 1)
            {
                validation += "Identificação do tipo de endereço que incluiu e invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Logradouro))
            {
                model.Logradouro = Validators.RemoveInjections(model.Logradouro);
                if (model.Logradouro.Length < 3)
                {
                    validation += "Descrição do logradouro contem menos de três caracteres\n";
                }
            }

            if (!int.TryParse(model.Numero, out int n))
            {
                model.Logradouro = Validators.RemoveInjections(model.Logradouro);
                if (model.Logradouro.Length < 3)
                {
                    validation += "O número informado não esta no formato correto\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Cidade))
            {
                model.Cidade = Validators.RemoveInjections(model.Cidade);
                if (model.Cidade.Length < 3)
                {
                    validation += "Descrição da cidade contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Estado))
            {
                model.Estado = Validators.RemoveInjections(model.Estado);
                if (model.Estado.Length != 2)
                {
                    validation += "o Estado não esta no formato correto\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Cep))
            {
                model.Cidade = Validators.RemoveInjections(model.Cidade);
                if (model.Cep.Length != 8)
                {
                    validation += "o CEP não esta no formato correto\n";
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

            if (id == 0)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
