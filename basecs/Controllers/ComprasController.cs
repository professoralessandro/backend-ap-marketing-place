using System;
using System.Collections.Generic;
using basecs.Helpers.Patterns.Controller;
using basecs.Models;
using basecs.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using basecs.Interfaces.IComprasService;

namespace backend_adm.Controllers
{
    public class ComprasController : ControllerCS
    {
        #region ATRIBUTTES
        private readonly IComprasService _service;
        private readonly LogsService _log;
        #endregion

        #region CONSTRUCTORS
        public ComprasController([FromServices] IComprasService service, [FromServices] LogsService log)
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
    }
}