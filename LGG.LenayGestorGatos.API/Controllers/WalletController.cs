/// Developer : Israel Curiel
/// Creation Date : 10/10/2024
/// Creation Description: Controlador
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ApiController
    {
        public WalletController(IApiController appController) : base(appController)
        {

        }


        /// <summary>
        /// Registro de Billetera con autenticacion en firebase
        /// </summary>
        /// <param name="">Params de entrada</param> 
        /// <remarks>
        /// Sample request: 
              /*{
                  "nombre": "Mercado Pago",
                  "saldo": 50,
                  "limiteCredito": 0,
                  "tazaInteres": 0,
                  "idTipoCuenta": 2,
                  "fechaDePago": "2024-10-10T09:48:42.620Z",
                  "fechaCorte": "2024-10-10T09:48:42.620Z",
                  "idUsuario": "string",
                  "color": "#ffffff"
                 }*/
        /// </remarks>   
        /// <response code="200">string</response>  
        /// <response code="400">string</response> 
        /// <response code="500">string</response> 
        [HttpPost("AddWallet")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> AddWallet([FromBody]WalletAggregate aggregate, [FromHeader] string Authorization)
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
            return Ok(await _appController.walletPresenter.AddWallet(aggregate, token));
        }


        /// <summary>
        /// Se consulta todas las billeteras registradas por el usuario
        /// </summary>
        /// <param name="">Params de entrada</param> 
        /// <remarks>
        /// Sample request: 
        /// </remarks>   
        /// <response code="200">string</response>  
        /// <response code="400">string</response> 
        /// <response code="500">string</response> 
        [HttpPost("GetWallets")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetWallets([FromHeader] string Authorization)
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
            return Ok(await _appController.walletPresenter.GetWallets(token));
        }


        /// <summary>
        /// Se consulta todas las billeteras registradas por el usuario
        /// </summary>
        /// <param name="">Params de entrada</param> 
        /// <remarks>
        /// Sample request: 
              /*{
                  "id": "e56ca258-86f0-11ef-a534-088fc33042fa"
                 }*/
        /// </remarks>   
        /// <response code="200">string</response>  
        /// <response code="400">string</response> 
        /// <response code="500">string</response> 
        [HttpPost("GetWalletById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetWalletById([FromHeader] string Authorization, [FromBody] IdWalletAggregate idWallet)
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
            return Ok(await _appController.walletPresenter.GetWalletById(token, idWallet));
        }
    }
}
