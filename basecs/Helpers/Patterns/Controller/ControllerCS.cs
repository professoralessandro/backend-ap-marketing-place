using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace basecs.Helpers.Patterns.Controller
{
    #region CONTROLLER ATRIBUTTES
    // Para proteger a API.
    // [AllowAnonymous]
    // [AllowAnonymous, EnableCors("basecsCorsPolicy"), Route("api/[controller]"), ApiController]
    // [Authorize("Bearer"), EnableCors("basecsCorsPolicy"), Route("api/[controller]"), ApiController]
    [AllowAnonymous, Route("api/[controller]"), ApiController]
    #endregion

    public class ControllerCS : ControllerBase
    {
    }
}
