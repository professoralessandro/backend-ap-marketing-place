using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.Business.IAvaliacoesBusiness;
using System;

namespace basecs.Business.Compras
{
    public class ComprasBusiness : IComprasBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Compra model)
        {
            string validation = "";

            if (model.CompraId == Guid.Empty)
            {
                validation += "Identificação da compra invalido\n";
            }

            if (model.ProdutoId == Guid.Empty)
            {
                validation += "Identificacao do produto que incluiu e invalido\n";
            }

            if (model.CompradorId == Guid.Empty)
            {
                validation += "Identificacao da compra que incluiu e invalido\n";
            }

            if ((int)model.FormaPagamento < 0)
            {
                validation += "Identificacao da forma de pagamento que incluiu e invalido\n";
            }

            if ((int)model.StatusCompra < 0)
            {
                validation += "Identificacao do status da compra que incluiu e invalido\n";
            }

            if (model.EntregaId == Guid.Empty)
            {
                validation += "Identificacao da entrega que incluiu e invalido\n";
            }

            if (model.LancamentoPaiId == Guid.Empty)
            {
                validation += "Identificacao do lancamento que incluiu e invalido\n";
            }

            if (model.EnderecoId == Guid.Empty)
            {
                validation += "Identificacao do endereço que incluiu e invalido\n";
            }

            if (model.EnderecoId == Guid.Empty)
            {
                validation += "Identificacao do endereço que incluiu e invalido\n";
            }

            if (model.GarantiaId == Guid.Empty)
            {
                validation += "Identificacao da garantia que incluiu e invalido\n";
            }

            if (model.VendedorId == Guid.Empty)
            {
                validation += "Identificacao do vendedor que incluiu e invalido\n";
            }

            if (model.AvaliacaoId == Guid.Empty)
            {
                validation += "Identificacao da avaliação que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Compra model)
        {
            string validation = "";

            if (model.CompraId == Guid.Empty)
            {
                validation += "Identificação da compra invalido\n";
            }

            if (!string.IsNullOrEmpty(model.CodigoCompra))
            {
                model.CodigoCompra = model.CodigoCompra.RemoveInjections();
                if (model.CodigoCompra.Length > 20)
                {
                    validation += "Descrição do codigodacompra contem mais de vinte caracteres\n";
                }
            }

            if (model.ProdutoId == Guid.Empty)
            {
                validation += "Identificacao do produto que incluiu e invalido\n";
            }

            if (model.CompradorId == Guid.Empty)
            {
                validation += "Identificacao da compra que incluiu e invalido\n";
            }

            if ((int)model.FormaPagamento < 0)
            {
                validation += "Identificacao da forma de pagamento que incluiu e invalido\n";
            }

            if ((int)model.StatusCompra < 1)
            {
                validation += "Identificacao do status da compra que incluiu e invalido\n";
            }

            if (model.EntregaId == Guid.Empty)
            {
                validation += "Identificacao da entrega que incluiu e invalido\n";
            }

            if (model.LancamentoPaiId == Guid.Empty)
            {
                validation += "Identificacao do lancamento que incluiu e invalido\n";
            }

            if (model.EnderecoId == Guid.Empty)
            {
                validation += "Identificacao do endereço que incluiu e invalido\n";
            }

            if (model.EnderecoId == Guid.Empty)
            {
                validation += "Identificacao do endereço que incluiu e invalido\n";
            }

            if (model.GarantiaId == Guid.Empty)
            {
                validation += "Identificacao da garantia que incluiu e invalido\n";
            }

            if (model.VendedorId == Guid.Empty)
            {
                validation += "Identificacao do vendedor que incluiu e invalido\n";
            }

            if (model.AvaliacaoId == Guid.Empty)
            {
                validation += "Identificacao da avaliação que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region DELETE
        public string DeleteValidation(Guid id)
        {
            string validation = "";

            if (id == Guid.Empty)
            {
                validation += "Identificação da compra invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
