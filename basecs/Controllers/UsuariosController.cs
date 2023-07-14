using System;
using System.Collections.Generic;
using basecs.Helpers.Patterns.Controller;
using basecs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using basecs.Interfaces.Services.IUsuariosService;
using basecs.Interfaces.Services.ILogsService;
using basecs.Dtos.Usuarios;

namespace backend_adm.Controllers
{
    public class UsuariosController : ControllerCS
    {
        #region ATRIBUTTES
        private readonly IUsuariosService _service;
        private readonly ILogsService _log;
        #endregion

        #region CONSTRUCTORS
        public UsuariosController([FromServices] IUsuariosService service, [FromServices] ILogsService log)
        {
            _service = service;
            _log = log;
        }
        #endregion

        #region RETURN LIST PAGINATED
        [HttpGet, Route("paginated")]
        public async Task<ActionResult<List<Usuario>>> ReturnListWithParameters(
                [FromQuery] Guid? id,
                [FromQuery] string nome,
                [FromQuery] string nmrDocumento,
                [FromQuery] string email,
                [FromQuery] bool? ativo,
                [FromQuery] int? pageNumber,
                [FromQuery] int? rowspPage
            )
        {
            try
            {
                return Ok(await _service.ReturnListWithParametersPaginated(id, nome, nmrDocumento, email, ativo, pageNumber, rowspPage));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ReturnListWithParameters(
                [FromQuery] Guid? id,
                [FromQuery] string nome,
                [FromQuery] string nmrDocumento,
                [FromQuery] string email,
                [FromQuery] bool? ativo
            )
        {
            try
            {
                return Ok(await _service.ReturnListWithParameters(id, nome, nmrDocumento, email, ativo));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        #endregion

        #region INSERT
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] InsertUserDto model)
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
        public async Task<ActionResult<Usuario>> Update(Usuario model)
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
        public async Task<ActionResult> Delete(Guid id)
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