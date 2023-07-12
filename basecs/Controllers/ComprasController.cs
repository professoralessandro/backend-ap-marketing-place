using System;
using System.Collections.Generic;
using basecs.Helpers.Patterns.Controller;
using basecs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using basecs.Dtos.Checkout.Request;
using System.ComponentModel.DataAnnotations;
using basecs.Enuns;
using basecs.Interfaces.Services.ILogsService;
using basecs.Interfaces.Services.IAvaliacoesService;
using basecs.Interfaces.Services.IUsuariosService;
using basecs.Interfaces.Services.IComprasService;
using basecs.Helpers.RumtimeStings;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Collections.Specialized;
using basecs.Helpers.Helpers.Validators;
using basecs.Dtos.Checkout.Test.Enum;
using basecs.Dtos.Checkout.Test.TransferObjects;
using System.Globalization;
using System.IO;

namespace backend_adm.Controllers
{
    public class ComprasController : ControllerCS
    {
        #region ATRIBUTTES
        private readonly IComprasService _service;
        private readonly IUsuariosService _userService;
        private readonly ILogsService _log;
        private readonly IProdutoService _productService;
        #endregion

        #region CONSTRUCTORS
        public ComprasController([FromServices] IComprasService service, [FromServices] ILogsService log, [FromServices] IProdutoService productService, [FromServices] IUsuariosService userService)
        {
            _service = service;
            _log = log;
            _productService = productService;
            _userService = userService;
        }
        #endregion

        #region RETURN LIST PAGINATED
        [HttpGet, Route("paginated")]
        public async Task<ActionResult<List<Compra>>> ReturnListWithParameters(
                [FromQuery] int? id,
                [FromQuery] string codigoCompra,
                [FromQuery] int? produtoId,
                [FromQuery] int? compradorId,
                [FromQuery] FormaPagamentoEnum? formaPagamentoId,
                [FromQuery] StatusCompraEnum? statusCompraId,
                [FromQuery] int? entregaId,
                [FromQuery] int? lancamentoPaiId,
                [FromQuery] int? enderecoId,
                [FromQuery] int? garantiaId,
                [FromQuery] int? telefoneId,
                [FromQuery] int? vendedorId,
                [FromQuery] int? avaliacaoId,
                [FromQuery] bool? isPago,
                [FromQuery] bool? isEntregue,
                [FromQuery] bool? isAvaliado,
                [FromQuery] bool? ativo,
                [FromQuery] int? pageNumber,
                [FromQuery] int? rowspPage
            )
        {
            try
            {
                return Ok(await _service.ReturnListWithParametersPaginated(
                    id,
                    codigoCompra,
                    produtoId,
                    compradorId,
                    formaPagamentoId,
                    statusCompraId,
                    entregaId,
                    lancamentoPaiId,
                    enderecoId,
                    garantiaId,
                    telefoneId,
                    vendedorId,
                    avaliacaoId,
                    isPago,
                    isEntregue,
                    isAvaliado,
                    ativo,
                    pageNumber,
                    rowspPage
                ));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        [HttpGet]
        public async Task<ActionResult<List<Compra>>> ReturnListWithParameters(
                [FromQuery] int? id,
                [FromQuery] string codigoCompra,
                [FromQuery] int? produtoId,
                [FromQuery] int? compradorId,
                [FromQuery] FormaPagamentoEnum? formaPagamento,
                [FromQuery] StatusCompraEnum? statusCompra,
                [FromQuery] int? entregaId,
                [FromQuery] int? lancamentoPaiId,
                [FromQuery] int? enderecoId,
                [FromQuery] int? garantiaId,
                [FromQuery] int? telefoneId,
                [FromQuery] int? vendedorId,
                [FromQuery] int? avaliacaoId,
                [FromQuery] bool? isPago,
                [FromQuery] bool? isEntregue,
                [FromQuery] bool? isAvaliado,
                [FromQuery] bool? ativo
            )
        {
            try
            {
                return Ok(await _service.ReturnListWithParameters(
                    id,
                    codigoCompra,
                    produtoId,
                    compradorId,
                    formaPagamento,
                    statusCompra,
                    entregaId,
                    lancamentoPaiId,
                    enderecoId,
                    garantiaId,
                    telefoneId,
                    vendedorId,
                    avaliacaoId,
                    isPago,
                    isEntregue,
                    isAvaliado,
                    ativo
                ));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        #endregion

        #region INSERT
        [HttpPost]
        public async Task<ActionResult<Compra>> Insert([FromBody] Compra model)
        {
            try
            {
                var response = await _service.Insert(model);
                await this._log.Create(this.Request, this.Response, this.Response.StatusCode.ToString());
                return Ok(response);
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 422;
                await this._log.Create(this.Request, this.Response, ex.Message);
                return UnprocessableEntity(ex.Message);
            }
        }
        #endregion

        #region UPDATE
        [HttpPut]
        public async Task<ActionResult<Compra>> Update(Compra model)
        {
            try
            {
                var response = await _service.Update(model);
                await this._log.Create(this.Request, this.Response, this.Response.StatusCode.ToString());
                return Ok(response);
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 422;
                await this._log.Create(this.Request, this.Response, ex.Message);
                return UnprocessableEntity(ex.Message);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete]
        public async Task<ActionResult> Delete(Int32 id)
        {
            try
            {
                await _service.Delete(id);
                await this._log.Create(this.Request, this.Response, this.Response.StatusCode.ToString());
                return Ok();
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 422;
                await this._log.Create(this.Request, this.Response, ex.Message);
                return UnprocessableEntity(ex.Message);
            }
        }
        #endregion

        #region CHECKOUT
        /// <summary>
        /// Realiza checkout com a conta parametrizada na configura��o do sistema.
        /// </summary>
        /// <param name="PaymentCreateRequest">Objeto com os parametros de usuario e produto necessarios para o checkout.</param>
        /// <returns></returns>
        [HttpPost, Route("Checkout")]
        public async Task<ActionResult<string>> Checkout([FromBody] PaymentCreateRequest model)
        {
            try
            {
                // VALIDACAO DOS PRODUTOS A SEREM COMPRADOS
                if (!model.Product.Any()) throw new ValidationException("Erro na validacao dos produtos");

                // PEGAR O ID DO USUARIO VINDO DO TOKEN E VALIDAR O USUARIO
                var user = await _userService.ReturnListWithParametersPaginated(model.UsuarioId, null, null, null, true, 1, 1);

                // VALIDAR SE A COMPRA EXISTE
                if (user == null) throw new ValidationException("Erro: nao foi possivel buscar pelo usuario na base de dados");

                //Conjunto de par�metros/formData.
                NameValueCollection postData = new NameValueCollection();
                postData.Add("email", RumtimeStingsPagSeguro.Email);
                postData.Add("token", RumtimeStingsPagSeguro.Token);
                postData.Add("currency", "BRL");

                for (int i = 0; i < model.Product.Count; i++)
                {
                    var productFromDb = await _productService.FindById(model.Product[i].ProductId);

                    // VALIDAR SE A COMPRA EXISTE
                    if (productFromDb == null) throw new ValidationException("Erro: nao foi possivel buscar pela compra na base de dados");

                    // SE A QUANTIDADE NECESSARIA NO EXISTIR RETORNAR BADREQUEST COM A QUANTIDADE DISPONIVEL
                    if (productFromDb.Quantidade <= model.Product[i].Quantity) throw new ValidationException("Erro: nao existem produtos suficientes em estoque");

                    postData.Add(string.Concat("itemId", i + 1), string.Concat("000", productFromDb.ProdutoId.ToString()));// ID DO PRODUTO
                    postData.Add(string.Concat("itemDescription", i + 1), productFromDb.Descricao); // DESCRICAO DO PRODUTO
                    postData.Add(string.Concat("itemAmount", i + 1), productFromDb.PrecoVenda.ToString()); // PRECO DE VENDA DO PRODUTO
                    postData.Add(string.Concat("itemQuantity", i + 1), model.Product[i].Quantity.ToString()); // QUANTIDADE SOLICITADA PELO CLIENTE
                    postData.Add(string.Concat("itemWeight", i + 1), "20"); // VALOT SETADO NA MAO POIS NAO TEMOS PESO CADASTRADO NA BASE
                }

                //Reference.
                postData.Add("reference", "REF1234");

                //Comprador.
                postData.Add("senderName", user.First().Nome);
                postData.Add("senderAreaCode", "44"); // AREA TESTE, A PREENCHER
                postData.Add("senderPhone", user.First().NmrTelefone.FoneMPSanitizer());
                postData.Add("senderEmail", user.First().Email);

                //Shipping.
                postData.Add("shippingAddressRequired", "false");

                //Formas de pagamento.
                //Cart�o de cr�dito e boleto.
                postData.Add("acceptPaymentMethodGroup", "CREDIT_CARD,BOLETO");

                //String que receber� o XML de retorno.
                string xmlString = null;

                //Webclient faz o post para o servidor de pagseguro.
                using (WebClient wc = new WebClient())
                {
                    //Informa header sobre URL.
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                    //Faz o POST e retorna o XML contendo resposta do servidor do pagseguro.
                    var result = wc.UploadValues(RumtimeStingsPagSeguro.Url, postData);

                    //Obt�m string do XML.
                    xmlString = Encoding.ASCII.GetString(result);
                }

                //Cria documento XML.
                XmlDocument xmlDoc = new XmlDocument();

                //Carrega documento XML por string.
                xmlDoc.LoadXml(xmlString);

                //Obt�m c�digo de transa��o (Checkout).
                var code = xmlDoc.GetElementsByTagName("code")[0];

                //Obt�m data de transa��o (Checkout).
                var date = xmlDoc.GetElementsByTagName("date")[0];

                //Retorna c�digo do checkout.
                return Ok(string.Concat(RumtimeStingsPagSeguro.CheckoutUrl, code.InnerText));
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

        // TESTES
        /// <summary>
        /// Consulta por c�digo refer�ncia.
        /// </summary>
        /// <param name="emailUsuario">E-mail usu�rio pagseguro.</param>
        /// <param name="token">Token.</param>
        /// <param name="urlConsultaTransacao">URL consulta transa��o.</param>
        /// <param name="codigoReferencia">C�digo de refer�ncia.</param>
        /// <returns>DTO com resultados do XML.</returns>
        [HttpGet, Route("ConsultaPorCodigoReferencia")]
        public ActionResult<ConsultaTransacaoPagSeguroDTO> ConsultaPorCodigoReferencia(
            [FromQuery] string emailUsuario,
            [FromQuery] string token,
            [FromQuery] string urlConsultaTransacao,
            [FromQuery] string codigoReferencia)
        {
            //Vari�vel de retorno.
            ConsultaTransacaoPagSeguroDTO retorno = new ConsultaTransacaoPagSeguroDTO();
            retorno.listTransaction = new List<ConsultaTransacaoPagSeguroTransactionDTO>();

            try
            {
                //uri de consulta da transa��o.
                string uri = string.Concat(urlConsultaTransacao, "?email=", emailUsuario, "&token=", token, "&reference=", codigoReferencia);

                //Classe que ir� fazer a requisi��o GET.
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

                //M�todo do webrequest.
                request.Method = "GET";

                //String que vai armazenar o xml de retorno.
                string xmlString = null;

                //Obt�m resposta do servidor.
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //Cria stream para obter retorno.
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        //L� stream.
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            //Xml convertido para string.
                            xmlString = reader.ReadToEnd();

                            //Cria xml document para facilitar acesso ao xml.
                            XmlDocument xmlDoc = new XmlDocument();

                            //Carrega xml document atrav�s da string com XML.
                            xmlDoc.LoadXml(xmlString);

                            //Resultados na p�gina.
                            //Por padr�o � retornado a p�gina 1 com 50 transa��es.
                            var resultsInThisPage = Convert.ToInt32(xmlDoc.GetElementsByTagName("resultsInThisPage")[0].InnerText);

                            //Total de p�ginas.
                            var totalPages = Convert.ToInt32(xmlDoc.GetElementsByTagName("totalPages")[0].InnerText);

                            //CurrentPage.
                            var currentPage = Convert.ToInt32(xmlDoc.GetElementsByTagName("currentPage")[0].InnerText);

                            //Obt�m lista de Transa��es.
                            var listTransactions = xmlDoc.GetElementsByTagName("transactions")[0];

                            //Popula retorno.
                            retorno.CurrentPage = currentPage;
                            retorno.TotalPages = totalPages;
                            retorno.ResultsInThisPage = resultsInThisPage;

                            //Usado para convers�o de data W3C.
                            string formatStringW3CDate = "yyyy-MM-ddTHH:mm:ss.fffzzz";
                            System.Globalization.CultureInfo cInfoW3CDate = new System.Globalization.CultureInfo("en-US", true);

                            //Popula transa��es.
                            if (listTransactions != null)
                            {
                                foreach (XmlNode childNode in listTransactions)
                                {
                                    //Cria novo item de transa��o.
                                    var itemTransacao = new ConsultaTransacaoPagSeguroTransactionDTO();

                                    foreach (XmlNode childNode2 in childNode.ChildNodes)
                                    {
                                        if (childNode2.Name == "date")
                                        {
                                            var date = System.DateTime.ParseExact(childNode2.InnerText, formatStringW3CDate, cInfoW3CDate);
                                            itemTransacao.Date = date;
                                        }
                                        else if (childNode2.Name == "reference")
                                        {
                                            itemTransacao.Reference = childNode2.InnerText;
                                        }
                                        else if (childNode2.Name == "code")
                                        {
                                            itemTransacao.Code = childNode2.InnerText;
                                        }
                                        else if (childNode2.Name == "type")
                                        {
                                            itemTransacao.type = Convert.ToInt32(childNode2.InnerText);
                                        }
                                        else if (childNode2.Name == "status")
                                        {
                                            itemTransacao.Status = Convert.ToInt32(childNode2.InnerText);
                                        }
                                        else if (childNode2.Name == "paymentMethod")
                                        {
                                            foreach (XmlNode nodePaymentMethod in childNode2.ChildNodes)
                                            {
                                                if (nodePaymentMethod.Name == "type")
                                                {
                                                    itemTransacao.PaymentMethodType = Convert.ToInt32(childNode2.InnerText);
                                                }
                                            }
                                        }
                                        else if (childNode2.Name == "grossAmount")
                                        {
                                            itemTransacao.GrossAmount = Convert.ToDouble(childNode2.InnerText, CultureInfo.InvariantCulture);
                                        }
                                        else if (childNode2.Name == "discountAmount")
                                        {
                                            itemTransacao.DiscountAmount = Convert.ToDouble(childNode2.InnerText, CultureInfo.InvariantCulture);
                                        }
                                        else if (childNode2.Name == "feeAmount")
                                        {
                                            itemTransacao.FeeAmount = Convert.ToDouble(childNode2.InnerText, CultureInfo.InvariantCulture);
                                        }
                                        else if (childNode2.Name == "netAmount")
                                        {
                                            itemTransacao.NetAmount = Convert.ToDouble(childNode2.InnerText, CultureInfo.InvariantCulture);
                                        }
                                        else if (childNode2.Name == "extraAmount")
                                        {
                                            itemTransacao.ExtraAmount = Convert.ToDouble(childNode2.InnerText, CultureInfo.InvariantCulture);
                                        }
                                        else if (childNode2.Name == "lastEventDate")
                                        {
                                            var lastEventDate = System.DateTime.ParseExact(childNode2.InnerText, formatStringW3CDate, cInfoW3CDate);
                                            itemTransacao.LastEventDate = lastEventDate;
                                        }
                                    }

                                    //Adiciona item de transa��o.
                                    retorno.listTransaction.Add(itemTransacao);
                                }
                            }

                            //Fecha reader.
                            reader.Close();

                            //Fecha stream.
                            dataStream.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Retorno.
           return Ok(retorno);
        }

        /// <summary>
        /// Cancela transa��o com status de "Aguardando Pagamento" ou "Em An�lise".
        /// </summary>
        /// <param name="emailUsuario">E-mail usu�rio pagseguro.</param>
        /// <param name="token">Token.</param>
        /// <param name="urlCancelamento">URL Cancelamento.</param>
        /// <param name="transactionCode">C�digo da transa��o.</param>
        /// <returns>Bool. Caso true, transa��o foi cancelada. Caso false, transa��o n�o foi cancelada.</returns>
        [HttpDelete, Route("CancelarTransacao")]
        public ActionResult<bool> CancelarTransacao(string emailUsuario, string token, string urlCancelamento, string transactionCode)
        {
            //Monta url completa para solicita��o.
            string urlCompleta = string.Concat(urlCancelamento);

            //String que receber� o XML de retorno.
            string xmlString = null;

            //Webclient faz o post para o servidor de pagseguro.
            using (WebClient wc = new WebClient())
            {
                //Informa header sobre URL.
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                //PostData.
                System.Collections.Specialized.NameValueCollection postData = new System.Collections.Specialized.NameValueCollection();
                postData.Add("email", emailUsuario);
                postData.Add("token", token);
                postData.Add("transactionCode", transactionCode);

                //Faz o POST e retorna o XML contendo resposta do servidor do pagseguro.
                var result = wc.UploadValues(urlCancelamento, postData);

                //Obt�m string do XML.
                xmlString = Encoding.ASCII.GetString(result);
            }

            //Cria documento XML.
            XmlDocument xmlDoc = new XmlDocument();

            //Carrega documento XML por string.
            xmlDoc.LoadXml(xmlString);

            //Obt�m c�digo de transa��o (Checkout).
            //Caso ocorra tudo ok, a API do PagSeguro retornar� uma tag "result" com o conte�do "OK"
            //Caso o cancelamento n�o ocorra, ser� retornado as tags errors -> error e dentro da error, as tags code e message.
            var xmlResult = xmlDoc.GetElementsByTagName("result");

            //Retorno.
            bool retorno;

            //Verifica se tem a tag resultado.
            if (xmlResult.Count > 0)
            {
                retorno = xmlResult[0].InnerText == "OK";
            }
            else
            {
                retorno = false;
            }

            //Retorno do m�todo.
            return Ok(retorno);
        }
        // TESTES
        #endregion
    }
}