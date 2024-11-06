/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description:Interface
/// Update Date : 06/11/24
/// Update Description : Metodo recuperar contraseña agregada
///CopyRight: Lenay gestor de gastos
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
        /// Inicia sesion al usuario y devuelve un token de acceso
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> SignIn(SignInAggregate aggregate);

        /// <summary>
        /// Valida si el token del usuario es valido
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> ValidateAuth(string token);

        /// <summary>
        /// Envia un correo para resetear contrasenia
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> ResetPasswordByEmail(ResetPasswordAggregate aggregate);
    }
}
