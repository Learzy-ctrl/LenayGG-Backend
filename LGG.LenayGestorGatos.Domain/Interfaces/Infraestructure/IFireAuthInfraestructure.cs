/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description: Interface
/// Update Date : --
/// Update Description : --
/// CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Domain.Interfaces.Infraestructure
{
    public interface IFireAuthInfraestructure
    {
        /// <summary>
        /// Registra al usuario usando FirebaseAuth
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> SignUp(UsuarioAggregate aggregate);

        /// <summary>
        /// Inicia sesión usando correo y contraseña y devuelve un token
        /// </summary>
        /// <param name="email">Correo electrónico del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <returns>Token de autenticación</returns>
        Task<string> SignIn(string email, string password);
    }
}
