/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description:Interface
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Domain.Interfaces.Services
{
    public interface IFireAuthPresenter
    {
        /// <summary>
        /// Registra al usuario usando FirebaseAuth
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> SignUp(UsuarioAggregate aggregate);
    }
}
