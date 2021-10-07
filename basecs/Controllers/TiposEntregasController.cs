using System;
using System.Collections.Generic;
using basecs.Helpers.Patterns.Controller;
using basecs.Models;
using basecs.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend_adm.Controllers
{
    public class TiposEntregasController : ControllerCS
    {
        #region ATRIBUTTES
        private readonly TiposEntregasService _service;
        private readonly LogsService _log;
        #endregion

        #region CONSTRUCTORS
        public TiposEntregasController([FromServices] TiposEntregasService service, [FromServices] LogsService log)
        {
            _service = service;
            _log = log;
        }
        #endregion

        #region RETURN LIST PAGINATED
        [HttpGet, Route("paginated")]
        public async Task<ActionResult<List<TipoEntrega>>> ReturnListWithParameters(
                [FromQuery] int? id,
                [FromQuery] string descricao,
                [FromQuery] bool? ativo,
                [FromQuery] int? pageNumber,
                [FromQuery] int? rowspPage
            )
        {
            try
            {
                return Ok(await _service.ReturnListWithParametersPaginated(id, descricao, ativo, pageNumber, rowspPage));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        [HttpGet]
        public async Task<ActionResult<List<TipoEntrega>>> ReturnListWithParameters(
            [FromQuery] int? id,
            [FromQuery] string descricao,
            [FromQuery] bool? ativo
            )
        {
            try
            {
                return Ok(await _service.ReturnListWithParameters(id, descricao, ativo));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        #endregion

        #region INSERT
        [HttpPost]
        public async Task<ActionResult<TipoEntrega>> Insert([FromBody] TipoEntrega model)
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
        public async Task<ActionResult<TipoEntrega>> Update(TipoEntrega model)
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