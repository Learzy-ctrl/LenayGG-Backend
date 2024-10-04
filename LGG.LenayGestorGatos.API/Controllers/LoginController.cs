/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description: Controlador
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ApiController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public LoginController(IApiController appController) : base(appController)
        {

        }

        /// <summary>
        /// Registro de Usuario a la tabla Usuario, y al servicio de FirebaseAuth
        /// </summary>
        /// <param name="">Params de entrada</param> 
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST 
        ///        {
        ///          "id": "",
        ///          "nombreUser": "David",
        ///          "contrasenia": "123456",
        ///          "email": "correo@test.com"
        ///          "fechaNacimiento": "2024-10-04T23:50:12.423Z"
        ///         }
        /// </remarks>   
        /// <response code="200">string</response>  
        /// <response code="400">string</response> 
        /// <response code="500">string</response> 
        [HttpPost("AddUsuario")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> AddUsuario([FromBody] UsuarioAggregate aggregate)
        {
            var response = await _appController.fireAuthPresenter.SignUp(aggregate);
            aggregate.Id = response.Mensaje;
            if(response.TipoError == 0)
            {
                return Ok(await _appController.usuarioPresenter.AddUsuario(aggregate));
            }
            return Ok(response);
        }
    }
}
