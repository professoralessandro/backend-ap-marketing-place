using System;
using basecs.Helpers.Patterns.Controller;
using basecs.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_adm.Controllers
{
    public class WelcomeController : ControllerCS
    {
        #region RETURN WELCOME MESSAGE
        [HttpGet]
        public ActionResult<string> ReturnWelcomeMessage([FromServices] WelcomeService service
            )
        {
            try
            {
                return Ok(service.ReturnWelcomeMessage());
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        #endregion
    }
}