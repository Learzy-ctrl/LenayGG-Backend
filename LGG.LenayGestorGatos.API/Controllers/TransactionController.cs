/// Developer : Israel Curiel
/// Creation Date : 25/10/2024
/// Creation Description: Controlador
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ApiController
    {
        public TransactionController(IApiController apiController) : base(apiController)
        {

        }

        [HttpPost("AddGasto")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> AddGasto([FromBody] TransactionAggregate aggregate, [FromHeader] string Authorization)
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
            return Ok(await _appController.transactionPresenter.AddGasto(aggregate, token));
        }

        [HttpPost("AddIngreso")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> AddIngreso([FromBody] TransactionAggregate aggregate, [FromHeader] string Authorization)
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
            return Ok(await _appController.transactionPresenter.AddIngreso(aggregate, token));
        }

        [HttpPost("AddTransferencia")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> AddTransferencia([FromBody] TransferAggregate aggregate, [FromHeader] string Authorization)
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
            return Ok(await _appController.transactionPresenter.AddTransferencia(aggregate, token));
        }

        [HttpPost("GetTransaccionesByIdWallet")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetTransaccionesByIdWallet([FromBody] IdWalletAggregate aggregate, [FromHeader] string Authorization)
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
            return Ok(await _appController.transactionPresenter.GetTransaccionesByIdWallet(aggregate, token));
        }

        [HttpPost("GetTransaccionesByIdUsuario")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetTransaccionesByIdUsuario([FromHeader] string Authorization)
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
            return Ok(await _appController.transactionPresenter.GetTransaccionesByIdUsuario(token));
        }

        [HttpPost("GetCategorias")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetCategorias([FromHeader] string Authorization)
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
            return Ok(await _appController.transactionPresenter.GetCategorias(token));
        }
    }
}
