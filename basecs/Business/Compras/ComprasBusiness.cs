using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Compras
{
    public class ComprasBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Compra model)
        {
            string validation = "";

            if (model.CompraId > 0)
            {
                validation += "Identificação da compra invalido\n";
            }

            if (model.ProdutoId < 1)
            {
                validation += "Identificação do produto que incluiu e invalido\n";
            }

            if (model.CompradorId < 1)
            {
                validation += "Identificação da compra que incluiu e invalido\n";
            }

            if (model.FormaPagamentoId < 1)
            {
                validation += "Identificação da forma de pagamento que incluiu e invalido\n";
            }

            if (model.StatusCompraId < 1)
            {
                validation += "Identificação do status da compra que incluiu e invalido\n";
            }

            if (model.EntregaId < 1)
            {
                validation += "Identificação da entrega que incluiu e invalido\n";
            }

            if (model.LancamentoPaiId < 1)
            {
                validation += "Identificação do lancamento que incluiu e invalido\n";
            }

            if (model.EnderecoId < 1)
            {
                validation += "Identificação do endereço que incluiu e invalido\n";
            }

            if (model.EnderecoId < 1)
            {
                validation += "Identificação do endereço que incluiu e invalido\n";
            }

            if (model.GarantiaId < 1)
            {
                validation += "Identificação da garantia que incluiu e invalido\n";
            }

            if (model.TelefoneId < 1)
            {
                validation += "Identificação da telefone que incluiu e invalido\n";
            }

            if (model.VendedorId < 1)
            {
                validation += "Identificação do vendedor que incluiu e invalido\n";
            }

            if (model.AvaliacaoId < 1)
            {
                validation += "Identificação da avaliação que incluiu e invalido\n";
            }

            if (!model.Ativo)
            {
                validation += "Não pode ser adicinada compra inativada\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Compra model)
        {
            string validation = "";

            if (model.CompraId == 0)
            {
                validation += "Identificação da compra invalido\n";
            }

            if (!string.IsNullOrEmpty(model.CodigoCompra))
            {
                model.CodigoCompra = Validators.RemoveInjections(model.CodigoCompra);
                if (model.CodigoCompra.Length > 20)
                {
                    validation += "Descrição do codigodacompra contem mais de vinte caracteres\n";
                }
            }

            if (model.ProdutoId < 1)
            {
                validation += "Identificação do produto que incluiu e invalido\n";
            }

            if (model.CompradorId < 1)
            {
                validation += "Identificação da compra que incluiu e invalido\n";
            }

            if (model.FormaPagamentoId < 1)
            {
                validation += "Identificação da forma de pagamento que incluiu e invalido\n";
            }

            if (model.StatusCompraId < 1)
            {
                validation += "Identificação do status da compra que incluiu e invalido\n";
            }

            if (model.EntregaId < 1)
            {
                validation += "Identificação da entrega que incluiu e invalido\n";
            }

            if (model.LancamentoPaiId < 1)
            {
                validation += "Identificação do lancamento que incluiu e invalido\n";
            }

            if (model.EnderecoId < 1)
            {
                validation += "Identificação do endereço que incluiu e invalido\n";
            }

            if (model.EnderecoId < 1)
            {
                validation += "Identificação do endereço que incluiu e invalido\n";
            }

            if (model.GarantiaId < 1)
            {
                validation += "Identificação da garantia que incluiu e invalido\n";
            }

            if (model.TelefoneId < 1)
            {
                validation += "Identificação da telefone que incluiu e invalido\n";
            }

            if (model.VendedorId < 1)
            {
                validation += "Identificação do vendedor que incluiu e invalido\n";
            }

            if (model.AvaliacaoId < 1)
            {
                validation += "Identificação da avaliação que incluiu e invalido\n";
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
                validation += "Identificação da compra invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
