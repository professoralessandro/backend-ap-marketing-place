using System;
using System.Collections.Generic;
using basecs.Helpers.Patterns.Controller;
using basecs.Models;
using basecs.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using basecs.Dtos.Checkout.Request;

namespace backend_adm.Controllers
{
    public class ComprasController : ControllerCS
    {
        #region ATRIBUTTES
        private readonly ComprasService _service;
        private readonly LogsService _log;
        #endregion

        #region CONSTRUCTORS
        public ComprasController([FromServices] ComprasService service, [FromServices] LogsService log)
        {
            _service = service;
            _log = log;
        }
        #endregion

        #region RETURN LIST PAGINATED
        [HttpGet, Route("paginated")]
        public async Task<ActionResult<List<Compra>>> ReturnListWithParameters(
                [FromQuery] int? id,
                [FromQuery] string codigoCompra,
                [FromQuery] int? produtoId,
                [FromQuery] int? compradorId,
                [FromQuery] int? formaPagamentoId,
                [FromQuery] int? statusCompraId,
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
                [FromQuery] int? formaPagamentoId,
                [FromQuery] int? statusCompraId,
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
        [HttpPost]
        public async Task<ActionResult<Compra>> Checkout(CheckoutDto model)
        {
            // PEGAR O ID DO USUARIO VINDO DO TOKEN E VALIDAR O USUARIO

            // PEGAR O ID DA COMPRA E VERIFICAR A QUANTIDADE

            // SE A QUANTIDADE COMPRADA EXISTIR NA BASE FAZER A RESERVA DA COMPRA POR 5 MINUTOS

            // SE A QQUANTIDADE NECESSARIA NO EXISTIR RETORNAR BADREQUEST COM A QQUANTIDADE DISPONIVEL

            // NESTE PASSO EFETIVAR O PAGAMENTO INTEGRANDO COM O MERCADO PAGO

            // SE O PAGAMENTO RETORNAR UM TOKEN VALIDO CONCLUIR A COMPRA E EFETIVAR COMMIT NA BASE DE DADOS

            // SE NAO RETORNAR UM TOKEN VALIDO EFETIVAR O ROLL BACK DA COMPRA

            // SE A COMPRA ESTIVER OK RETORNAR O ID DA COMPRA E STATUS OK()

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Compra>> MercadoLivreIntegrationCheckout(Compra model)
        {
            return Ok();
        }
        #endregion
    }
}