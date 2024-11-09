/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description:Interface
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Domain.Interfaces.Infraestructure
{
    public interface IUsuarioInfrastructure
    {
        /// <summary>
        /// Agrega un registro de la tabla Usuario
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> AddUsuario(UsuarioAggregate aggregate);

        /// <summary>
        /// Registra la url de la imagen del usuario
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> UploadImage(string UrlImage, string UID);

        /// <summary>
        /// Actualiza los datos de un usuario
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> UpdateUser(UpdateUserAggregate aggregate, string UID);

        /// <summary>
        /// Consulta un usuario por su id
        /// </summary>
        /// <returns></returns>
        Task<object> GetUser(string id);

        /// <summary>
        /// Elimina un usuario por su id
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> DeleteUser(string id);
    }
}
