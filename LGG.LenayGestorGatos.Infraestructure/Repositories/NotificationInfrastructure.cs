/// Developer : Israel Curiel
/// Creation Date : 28/11/2024
/// Creation Description: Clase
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Infraestructure.Repositories
{
    public class NotificationInfrastructure : INotificationInfrastructure
    {
        private readonly GestorGastosContext _context;
        public NotificationInfrastructure(GestorGastosContext context)
        {
            _context = context;
        }

        public async Task<RespuestaDB> AddNotification(NotificationAggregate aggregate)
        {
            try
            {
                var sqlQuery = "CALL SP_RegistrarNotificacion(@encabezado, @cuerpo, @fecha, @idUsuario)";
                var parameters = new[]
                {
                    new MySqlParameter("@encabezado", aggregate.encabezado),
                    new MySqlParameter("@cuerpo", aggregate.cuerpo),
                    new MySqlParameter("@fecha", aggregate.fecha),
                    new MySqlParameter("@idUsuario", aggregate.idUsuario)
                };
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);
                return new RespuestaDB
                {
                    Resultado = "Operación exitosa",
                    NumError = 0
                };
            }
            catch (MySqlException ex)
            {
                return new RespuestaDB
                {
                    Resultado = $"Error en la base de datos: {ex.Message}",
                    NumError = 4
                };
            }
        }

        public async Task<RespuestaDB> CheckIsDeleted(List<IdNotificationAggregate> aggregates)
        {
            try
            {
                var sqlQuery = "CALL SP_MarcarNotificacionComoEliminada(@notificacionId)";
                foreach (var a in aggregates)
                {
                    var parameter = new MySqlParameter("@notificacionId", a.Id);
                    await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameter);
                }
                return new RespuestaDB
                {
                    Resultado = "Operación exitosa",
                    NumError = 0
                };
            }
            catch (MySqlException ex)
            {
                return new RespuestaDB
                {
                    Resultado = $"Error en la base de datos: {ex.Message}",
                    NumError = 2
                };
            }
        }

        public async Task<RespuestaDB> CheckIsRead(List<IdNotificationAggregate> aggregates)
        {
            try
            {
                var sqlQuery = "CALL SP_MarcarNotificacionComoLeida(@notificacionId)";
                foreach (var a in aggregates)
                {
                    var parameter = new MySqlParameter("@notificacionId", a.Id);
                    await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameter);
                }
                return new RespuestaDB
                {
                    Resultado = "Operación exitosa",
                    NumError = 0
                };
            }
            catch (MySqlException ex)
            {
                return new RespuestaDB
                {
                    Resultado = $"Error en la base de datos: {ex.Message}",
                    NumError = 2
                };
            }
        }

        public async Task<List<NotificationDto>> GetNotifications(string UID)
        {
            try
            {
                var sqlQuery = "CALL SP_ObtenerNotificacionesPorUsuario(@usuarioId)";
                var parameters = new[]
                {
                    new MySqlParameter("@usuarioId", UID)
                };
                return await _context.notificationDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }
    }
}
