using System;
using System.Collections.Generic;
using basecs.Helpers.Patterns.Controller;
using basecs.Models;
using basecs.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace basecs.Controllers
{
    public class LogsController : ControllerCS
    {
        #region ATRIBUTTES
        private readonly LogsService _service;
        #endregion

        #region CONSTRUCTORS
        public LogsController([FromServices] LogsService service)
        {
            _service = service;
        }
        #endregion

        #region RETURN LIST PAGINATED
        [HttpGet, Route("paginated")]
        public async Task<ActionResult<List<Log>>> ReturnListWithParameters(
                [FromQuery] string param,
                [FromQuery] DateTime? dateAdded,
                [FromQuery] int? pageNumber,
                [FromQuery] int? rowspPage
            )
        {
            try
            {
                return Ok(await _service.ReturnListWithParametersPaginated(param, dateAdded, pageNumber, rowspPage));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        #endregion

        #region RETURN LIST WITH PARAMETERS
        [HttpGet]
        public async Task<ActionResult<List<Log>>> ReturnListWithParameters(
                [FromQuery] int? id,
                [FromQuery] string request,
                [FromQuery] string method,
                [FromQuery] int? userAddedId,
                [FromQuery] DateTime? dateAdded
            )
        {
            try
            {
                return Ok(await _service.ReturnListWithParameters(id, request, method, userAddedId, dateAdded));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        #endregion
    }
}
