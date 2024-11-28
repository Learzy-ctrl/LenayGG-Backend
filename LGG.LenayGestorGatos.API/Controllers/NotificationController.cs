/// Developer : Israel Curiel
/// Creation Date : 28/11/2024
/// Creation Description: Controlador
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos

namespace LGG.LenayGestorGatos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ApiController
    {
        public NotificationController(IApiController appController) : base(appController)
        {

        }

        [HttpPost("GetNotifications")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetNotifications([FromHeader] string Authorization)
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("Token no proporcionado.");
            }

            var token = Authorization.StartsWith("Bearer ") ? Authorization.Substring("Bearer ".Length).Trim() : null;

            if (token == null)
            {
                return Unauthorized("Token no válido.");
            }
            return Ok(await _appController.notificationPresenter.GetNotifications(token));
        }

        [HttpPost("CheckIsRead")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> CheckIsRead([FromBody] List<IdNotificationAggregate> aggregates, [FromHeader] string Authorization)
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("Token no proporcionado.");
            }

            var token = Authorization.StartsWith("Bearer ") ? Authorization.Substring("Bearer ".Length).Trim() : null;

            if (token == null)
            {
                return Unauthorized("Token no válido.");
            }
            return Ok(await _appController.notificationPresenter.CheckIsRead(aggregates, token));
        }

        [HttpPost("CheckIsDeleted")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> CheckIsDeleted([FromBody] List<IdNotificationAggregate> aggregates, [FromHeader] string Authorization)
        {
            if (string.IsNullOrEmpty(Authorization))
            {
                return Unauthorized("Token no proporcionado.");
            }

            var token = Authorization.StartsWith("Bearer ") ? Authorization.Substring("Bearer ".Length).Trim() : null;

            if (token == null)
            {
                return Unauthorized("Token no válido.");
            }
            return Ok(await _appController.notificationPresenter.CheckIsDeleted(aggregates, token));
        }
    }
}
