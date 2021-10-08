using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Lancamentos
{
    public class LancamentosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Lancamento model)
        {
            string validation = "";

            if (model.LancamentoId > 0)
            {
                validation += "Identificação do regristro invalido\n";
            }

            if (model.TipoLancamentoId < 1)
            {
                validation += "Identificação do tipo de lancamento invalido\n";
            }

            if (model.SituacaoId < 1)
            {
                validation += "Identificação da sitação e invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Referencia))
            {
                model.Referencia = Validators.RemoveInjections(model.Referencia);
                if (model.Referencia.Length < 3)
                {
                    validation += "A referência contem menos de três caracteres\n";
                }
            }

            if (model.ValorLancamento.Equals(null))
            {
                validation += "Identificação do valor do lançamento e invalido\n";
            }

            if (model.NmrParcela.Equals(null))
            {
                validation += "Identificação da parcela e invalido\n";
            }

            if (model.QtdeParcelas.Equals(null))
            {
                validation += "Identificação da quantidade de parcelas e invalido\n";
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
                validation += "Não pode ser adicinado lancamento inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Lancamento model)
        {
            string validation = "";

            if (model.LancamentoId < 1)
            {
                validation += "Identificação do regristro invalido\n";
            }

            if (model.TipoLancamentoId < 1)
            {
                validation += "Identificação do tipo de lancamento invalido\n";
            }

            if (model.SituacaoId < 1)
            {
                validation += "Identificação da sitação e invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Referencia))
            {
                model.Referencia = Validators.RemoveInjections(model.Referencia);
                if (model.Referencia.Length < 3)
                {
                    validation += "A referência contem menos de três caracteres\n";
                }
            }

            if (model.ValorLancamento.Equals(null))
            {
                validation += "Identificação do valor do lançamento e invalido\n";
            }

            if (model.NmrParcela.Equals(null))
            {
                validation += "Identificação da parcela e invalido\n";
            }

            if (model.QtdeParcelas.Equals(null))
            {
                validation += "Identificação da quantidade de parcelas e invalido\n";
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
                validation += "Identificação do registro invalida\n";
            }

            return validation;
        }
        #endregion
    }
}
