/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description:Interface
/// Update Date : 07/11/24
/// Update Description : --
///CopyRight: Lenay gestor de gastos

namespace LGG.LenayGestorGatos.Domain.Interfaces.Services
{
    public interface IUsuarioPresenter
    {
        /// <summary>
        /// agrega registro a la tabla Usuario
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> AddUsuario(UsuarioAggregate aggregate);

        /// <summary>
        /// Actualiza foto de perfil de un usuario
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> UploadImage(PhotoUserAggregate photoUserAggregate, string token);

        /// <summary>
        /// Actualiza los datos de un usuario
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> UpdateUser(UpdateUserAggregate aggregate, string token);

        /// <summary>
        /// Consulta un usuario por su id
        /// </summary>
        /// <returns></returns>
        Task<object> GetUser(string token);

        /// <summary>
        /// Elimina un usuario por su id
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> DeleteUser(string token);

        /// <summary>
        /// Cambia el correo de un usuario
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> ChangeUserEmail(EmailAggregate aggregate, string token);

        /// <summary>
        /// Cambia La contrasenia de un usuario
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> ChangeUserPassword(PasswordAggregate aggregate, string token);
    }
}
