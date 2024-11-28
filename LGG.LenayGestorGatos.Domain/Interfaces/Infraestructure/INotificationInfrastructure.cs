/// Developer : Israel Curiel
/// Creation Date : 28/11/2024
/// Creation Description:Interface
/// Update Date : --/--/--
/// Update Description : ----
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Domain.Interfaces.Infraestructure
{
    public interface INotificationInfrastructure 
    {
        /// <summary>
        /// Agrega una nueva notificacion
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> AddNotification(NotificationAggregate aggregate);

        /// <summary>
        /// Consulta las notificaciones de un usuario
        /// </summary>
        /// <returns></returns>
        Task<List<NotificationDto>> GetNotifications(string UID);

        /// <summary>
        /// da check cuando el usuario ha marcado como leido una notificacion
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> CheckIsRead(List<IdNotificationAggregate> aggregates);

        /// <summary>
        /// da check cuando el usuario ha marcado como eliminado una notificacion
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> CheckIsDeleted(List<IdNotificationAggregate> aggregates); 
    }
}
