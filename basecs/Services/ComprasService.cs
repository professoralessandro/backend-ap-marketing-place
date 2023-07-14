using basecs.Data;
using basecs.Dtos.Checkout.Request;
using basecs.Dtos.Checkout.Test.Enum;
using basecs.Enuns;
using basecs.Helpers.Helpers.Validators;
using basecs.Helpers.RumtimeStings;
using basecs.Interfaces.Business.IAvaliacoesBusiness;
using basecs.Interfaces.Services.IAvaliacoesService;
using basecs.Interfaces.Services.IComprasService;
using basecs.Interfaces.Services.IUsuariosService;
using basecs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace basecs.Services
{
    public class ComprasService : IComprasService
    {
        #region ATRIBUTTES
        private readonly MyDbContext _context;
        private readonly IComprasBusiness _business;
        private readonly IUsuariosService _userService;
        private readonly IProdutoService _productService;
        #endregion

        #region CONTRUCTORS
        public ComprasService(MyDbContext context, IComprasBusiness business, IUsuariosService userService, IProdutoService productService)
        {
            _context = context;
            _business = business;
            _productService = productService;
            _userService = userService;
        }
        #endregion

        #region FIND BY ID
        public async Task<Compra> FindById(Guid id)
        {
            try
            {
                return await this._context.Compras.SingleOrDefaultAsync(c => c.CompraId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Compra desejada!" + ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        public async Task<List<Compra>> ReturnListWithParametersPaginated(
                Guid? id,
                string codigoCompra,
                int? produtoId,
                int? compradorId,
                FormaPagamentoEnum? formaPagamento,
                StatusCompraEnum? statusCompra,
                int? entregaId,
                int? lancamentoPaiId,
                int? enderecoId,
                int? garantiaId,
                int? vendedorId,
                int? avaliacaoId,
                bool? isPago,
                bool? isEntregue,
                bool? isAvaliado,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            )
        {
            try
            {
                SqlParameter[] Params = {
                    new SqlParameter("@Id", id.Equals(null) ? DBNull.Value : id),
                    new SqlParameter("@CodigoCompra", string.IsNullOrEmpty(codigoCompra.RemoveInjections()) ? DBNull.Value : codigoCompra.RemoveInjections()),
                    new SqlParameter("@ProdutoId", produtoId.Equals(null) ? DBNull.Value : produtoId),
                    new SqlParameter("@CompradorId", compradorId.Equals(null) ? DBNull.Value : compradorId),
                    new SqlParameter("@FormaPagamentoId", produtoId.Equals(null) ? DBNull.Value : formaPagamento),
                    new SqlParameter("@StatusCompraId", statusCompra.Equals(null) ? DBNull.Value : statusCompra),
                    new SqlParameter("@EntregaId", entregaId.Equals(null) ? DBNull.Value : entregaId),
                    new SqlParameter("@LancamentoPaiId", entregaId.Equals(null) ? DBNull.Value : lancamentoPaiId),
                    new SqlParameter("@EnderecoId", enderecoId.Equals(null) ? DBNull.Value : enderecoId),
                    new SqlParameter("@GarantiaId", garantiaId.Equals(null) ? DBNull.Value : garantiaId),
                    new SqlParameter("@VendedorId", vendedorId.Equals(null) ? DBNull.Value : vendedorId),
                    new SqlParameter("@AvaliacaoId", avaliacaoId.Equals(null) ? DBNull.Value : avaliacaoId),
                    new SqlParameter("@IsPago", isPago.Equals(null) ? DBNull.Value : isPago),
                    new SqlParameter("@IsEntregue", isEntregue.Equals(null) ? DBNull.Value : isEntregue),
                    new SqlParameter("@IsAvaliado", isAvaliado.Equals(null) ? DBNull.Value : isAvaliado),
                    new SqlParameter("@Ativo", ativo.Equals(null) ? DBNull.Value : ativo),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@RowspPage", rowspPage)
                };

                var storedProcedure = $@"[dbo].[ComprasPaginated] @Id, @CodigoCompra, @ProdutoId, @FormaPagamentoId, @StatusCompraId, @EntregaId, @LancamentoPaiId, @EnderecoId, @GarantiaId, @VendedorId, @AvaliacaoId, @IsPago, @IsEntregue, @IsAvaliado, @Ativo, @PageNumber, @RowspPage";

                using (var context = this._context)
                {
                    return await context.Compras.FromSqlRaw(storedProcedure, Params).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos workflows: " + ex.Message);
            }

        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        public async Task<List<Compra>> ReturnListWithParameters(
            Guid? id,
            string codigoCompra,
            int? produtoId,
            int? compradorId,
            FormaPagamentoEnum? formaPagamento,
            StatusCompraEnum? statusCompra,
            int? entregaId,
            int? lancamentoPaiId,
            int? enderecoId,
            int? garantiaId,
            int? vendedorId,
            int? avaliacaoId,
            bool? isPago,
            bool? isEntregue,
            bool? isAvaliado,
            bool? ativo
            )
        {
            try
            {
                using (var context = this._context)
                {
                    return await context.Compras.Where(c =>
                    (c.CompraId == id || id == null) &&
                    (c.CodigoCompra.Contains(codigoCompra.RemoveInjections()) || string.IsNullOrEmpty(codigoCompra.RemoveInjections())) &&
                    (c.ProdutoId.Equals(produtoId) || !produtoId.Equals(null)) &&
                    (c.CompradorId.Equals(compradorId) || !compradorId.Equals(null)) &&
                    (c.FormaPagamento.Equals(formaPagamento) || !formaPagamento.Equals(null)) &&
                    (c.StatusCompra.Equals(statusCompra) || !statusCompra.Equals(null)) &&
                    (c.EntregaId.Equals(entregaId) || !entregaId.Equals(null)) &&
                    (c.LancamentoPaiId.Equals(lancamentoPaiId) || !lancamentoPaiId.Equals(null)) &&
                    (c.EnderecoId.Equals(enderecoId) || !enderecoId.Equals(null)) &&
                    (c.GarantiaId.Equals(garantiaId) || !garantiaId.Equals(null)) &&
                    (c.VendedorId.Equals(vendedorId) || !vendedorId.Equals(null)) &&
                    (c.AvaliacaoId.Equals(avaliacaoId) || !avaliacaoId.Equals(null)) &&
                    (c.IsPago.Equals(isPago) || !isPago.Equals(null)) &&
                    (c.IsEntregue.Equals(isEntregue) || !isEntregue.Equals(null)) &&
                    (c.IsAvaliado.Equals(isAvaliado) || !isAvaliado.Equals(null)) &&
                    (c.Ativo == ativo || ativo == null)
                    ).OrderByDescending(x => x.CompraId)
                    .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por tipos compras: " + ex.Message);
            }
        }
        #endregion

        #region INSERT
        public async Task<Compra> Insert(Compra model)
        {
            try
            {
                string validationMessage = _business.InsertValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Compras.Add(model);
                    await this._context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    throw new Exception(validationMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir tipos compras: " + ex.Message);
            }
        }
        #endregion

        #region UPDATE
        public async Task<Compra> Update(Compra model)
        {
            try
            {
                string validationMessage = _business.UpdateValidation(model);

                if (validationMessage.Equals(""))
                {
                    this._context.Compras.Update(model);
                    await this._context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    throw new Exception(validationMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar editar o registro: " + ex.Message);
            }
        }
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        public async Task<Compra> Delete(Guid id)
        {
            try
            {
                string validationMessage = _business.DeleteValidation(id);

                if (validationMessage.Equals(""))
                {
                    Compra model = await this.FindById(id);
                    model.Ativo = false;
                    await this.Update(model);
                    return model;
                }
                else
                {
                    throw new Exception(validationMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar deletar o registro: " + ex.Message);
            }
        }
        #endregion

        #region CHECKOUT
        public async Task<string> Checkout(PaymentCreateRequest model)
        {
            try
            {
                // VALIDACAO DOS PRODUTOS A SEREM COMPRADOS
                if (!model.Product.Any()) throw new ValidationException("Erro na validacao dos produtos");

                // PEGAR O ID DO USUARIO VINDO DO TOKEN E VALIDAR O USUARIO
                var user = await _userService.ReturnListWithParametersPaginated(model.UsuarioId, null, null, null, true, 1, 1);

                // VALIDAR SE A COMPRA EXISTE
                if (user == null) throw new ValidationException("Erro: nao foi possivel buscar pelo usuario na base de dados");

                NameValueCollection postData = await ReturnCheckoutParameters(model, user.First());

                //Retorna código do checkout.
                return string.Concat(RumtimeStingsPagSeguro.CheckoutUrl, ReturnCodeFromXML(postData));
            }
            catch (ValidationException ex)
            {
                throw new ValidationException("Houve um erro na validacao ao fazer checkout: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao fazer o checkout: " + ex.Message);
            }
        }
        #endregion

        #region PRIVATE METHODS
        private async Task<NameValueCollection> ReturnCheckoutParameters(PaymentCreateRequest request, Usuario usuario)
        {
            //Conjunto de parâmetros/formData.
            NameValueCollection postData = new NameValueCollection();
            postData.Add("email", RumtimeStingsPagSeguro.Email);
            postData.Add("token", RumtimeStingsPagSeguro.Token);
            postData.Add("currency", "BRL");

            for (int i = 0; i < request.Product.Count; i++)
            {
                var productFromDb = await _productService.FindById(request.Product[i].ProductId);

                // VALIDAR SE A COMPRA EXISTE
                if (productFromDb == null) throw new ValidationException("Erro: nao foi possivel buscar pela compra na base de dados");

                // SE A QUANTIDADE NECESSARIA NO EXISTIR RETORNAR BADREQUEST COM A QUANTIDADE DISPONIVEL
                if (productFromDb.Quantidade <= request.Product[i].Quantity) throw new ValidationException("Erro: nao existem produtos suficientes em estoque");

                postData.Add(string.Concat("itemId", i + 1), string.Concat(productFromDb.ProdutoId.ToString()));// ID DO PRODUTO
                postData.Add(string.Concat("itemDescription", i + 1), productFromDb.Descricao); // DESCRICAO DO PRODUTO
                postData.Add(string.Concat("itemAmount", i + 1), productFromDb.PrecoVenda.ToString()); // PRECO DE VENDA DO PRODUTO
                postData.Add(string.Concat("itemQuantity", i + 1), request.Product[i].Quantity.ToString()); // QUANTIDADE SOLICITADA PELO CLIENTE
                postData.Add(string.Concat("itemWeight", i + 1), "20"); // VALOT SETADO NA MAO POIS NAO TEMOS PESO CADASTRADO NA BASE
            }

            //Reference.
            postData.Add("reference", "REF1234");

            //Comprador.
            postData.Add("senderName", usuario.Nome);
            postData.Add("senderAreaCode", "44"); // AREA TESTE, A PREENCHER
            postData.Add("senderPhone", usuario.NmrTelefone.FoneMPSanitizer());
            postData.Add("senderEmail", usuario.Email);

            //Shipping.
            postData.Add("shippingAddressRequired", "false");

            //Formas de pagamento.
            //Cartão de crédito e boleto.
            postData.Add("acceptPaymentMethodGroup", "CREDIT_CARD,BOLETO");

            return postData;
        }

        private string ReturnCodeFromXML(NameValueCollection postData)
        {
            //String que receberá o XML de retorno.
            string xmlString = null;

            //Webclient faz o post para o servidor de pagseguro.
            using (WebClient wc = new WebClient())
            {
                //Informa header sobre URL.
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                //Faz o POST e retorna o XML contendo resposta do servidor do pagseguro.
                var result = wc.UploadValues(RumtimeStingsPagSeguro.Url, postData);

                //Obtém string do XML.
                xmlString = Encoding.ASCII.GetString(result);
            }

            //Cria documento XML.
            XmlDocument xmlDoc = new XmlDocument();

            //Carrega documento XML por string.
            xmlDoc.LoadXml(xmlString);

            //Obtém código de transação (Checkout).
            var code = xmlDoc.GetElementsByTagName("code")[0];

            //Obtém data de transação (Checkout).
            var date = xmlDoc.GetElementsByTagName("date")[0];

            return code.InnerText;
        }

        /// <summary>
        /// Nome amigável para status do pagseguro.
        /// </summary>
        /// <param name="status">Status.</param>
        /// <returns>Nome amigável.</returns>
        private string NomeAmigavelStatusPagSeguro(StatusTransacaoEnum status)
        {
            string retorno;

            if (status == StatusTransacaoEnum.NaoExisteTransacao)
            {
                retorno = "Nenhuma Transação Encontrada";
            }
            else if (status == StatusTransacaoEnum.AguardandoPagamento)
            {
                retorno = "Aguardando Pagamento";
            }
            else if (status == StatusTransacaoEnum.EmAnalise)
            {
                retorno = "Em Análise";
            }
            else if (status == StatusTransacaoEnum.Paga)
            {
                retorno = "Pago";
            }
            else if (status == StatusTransacaoEnum.Disponivel)
            {
                retorno = "Disponível";
            }
            else if (status == StatusTransacaoEnum.EmDisputa)
            {
                retorno = "Em Disputa";
            }
            else if (status == StatusTransacaoEnum.Devolvida)
            {
                retorno = "Devolvida";
            }
            else if (status == StatusTransacaoEnum.Cancelada)
            {
                retorno = "Cancelada";
            }
            else if (status == StatusTransacaoEnum.Debitado)
            {
                retorno = "Debitado (Devolvido)";
            }
            else if (status == StatusTransacaoEnum.RetencaoTemporaria)
            {
                retorno = "Retenção Temp.";
            }
            else
            {
                throw new Exception("Falha ao resolver status pagseguro.");
            }

            return retorno;
        }

        /// <summary>
        /// Nome amigável para tipo de pagamento do pagseguro.
        /// </summary>
        /// <param name="tipoPagamento">Tipo do pagamento.</param>
        /// <returns>Tipo pagamento.</returns>
        private string NomeAmigavelTipoPagamentoPagSeguro(TipoPagamentoEnum tipoPagamento)
        {
            string retorno;

            if (tipoPagamento == TipoPagamentoEnum.Boleto)
            {
                retorno = "Boleto";
            }
            else if (tipoPagamento == TipoPagamentoEnum.CartaoDeCredito)
            {
                retorno = "Cartão de Crédito";
            }
            else if (tipoPagamento == TipoPagamentoEnum.DebitoOnLineTEF)
            {
                retorno = "Débito Online (TEF)";
            }
            else if (tipoPagamento == TipoPagamentoEnum.OiPago)
            {
                retorno = "Oi Pago";
            }
            else if (tipoPagamento == TipoPagamentoEnum.SaldoPagSeguro)
            {
                retorno = "Saldo PagSeguro";
            }
            else if (tipoPagamento == TipoPagamentoEnum.DepositoEmConta)
            {
                retorno = "Depósito em Conta";
            }
            else
            {
                throw new Exception("Falha ao resolver tipo pagamento pagseguro.");
            }

            return retorno;
        }
        #endregion
    }
}
