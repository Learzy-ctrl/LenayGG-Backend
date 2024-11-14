using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LGG.LenayGestorGatos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        public UserController(IApiController apiController) : base(apiController) { }

        [HttpPost("UploadImage")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> UploadImage([FromBody] PhotoUserAggregate aggregate, [FromHeader] string Authorization)
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
            return Ok(await _appController.usuarioPresenter.UploadImage(aggregate, token));
        }

        [HttpPost("UpdateUser")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> UpdateUser([FromBody] UpdateUserAggregate aggregate, [FromHeader] string Authorization)
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
            return Ok(await _appController.usuarioPresenter.UpdateUser(aggregate, token));
        }

        [HttpPost("GetUser")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetUser([FromHeader] string Authorization)
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
            return Ok(await _appController.usuarioPresenter.GetUser(token));
        }

        [HttpPost("DeleteUser")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> DeleteUser([FromHeader] string Authorization)
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
            return Ok(await _appController.usuarioPresenter.DeleteUser(token));
        }

        /*[HttpPost("ChangeUserEmail")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> ChangeUserEmail([FromBody] EmailAggregate aggregate, [FromHeader] string Authorization)
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
            return Ok(await _appController.usuarioPresenter.ChangeUserEmail(aggregate, token));
        }*/

        [HttpPost("ChangeUserPassword")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> ChangeUserPassword([FromBody] PasswordAggregate aggregate, [FromHeader] string Authorization)
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
            return Ok(await _appController.usuarioPresenter.ChangeUserPassword(aggregate, token));
        }
    }
}
