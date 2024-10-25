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
    }
}
