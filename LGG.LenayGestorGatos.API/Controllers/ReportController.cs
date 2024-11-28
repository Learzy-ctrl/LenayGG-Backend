/// Developer : Israel Curiel
/// Creation Date : 14/11/2024
/// Creation Description: Controlador
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ApiController
    {
        public ReportController(IApiController appController) : base(appController)
        {

        }

        /// <summary>
        /// Consulta los gastos en un rango de fechas
        /// </summary>
        /// <param name="">Params de entrada</param> 
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST 
        ///        {
        ///          "fecha_inicio": "2024-01-14T20:02:01.896Z",
        ///          "fecha_fin": "2024-11-14T20:02:01.896Z",
        ///          "id_usuario": null,
        ///          "id_billetera": "b73ca863-9a96-11ef-8703-5254001eccc3",
        ///          "todas_billeteras": false
        ///        }
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("GetGastosByFilter")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetGastosByFilter([FromBody] ConsultaGastosAggregate aggregate, [FromHeader] string Authorization)
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
            return Ok(await _appController.reportePresenter.GetGastosByFilter(aggregate, token));
        }
    }
}
