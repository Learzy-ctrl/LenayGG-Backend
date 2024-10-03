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
    }
}
