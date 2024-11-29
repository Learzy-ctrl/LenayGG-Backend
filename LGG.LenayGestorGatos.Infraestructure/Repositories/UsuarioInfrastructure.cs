/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description: Clase
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Infraestructure.Repositories
{
    public class UsuarioInfrastructure : IUsuarioInfrastructure
    {
        private readonly GestorGastosContext _context;
        public UsuarioInfrastructure(GestorGastosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Agrega un registro de la tabla Usuario
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> AddUsuario(UsuarioAggregate aggregate)
        {
            try
            {
                var sqlQuery = "CALL SP_InsertarUsuario(@p_Id, @p_NombreUser, @p_fechaNacimiento)";

                var parameters = new[]
                {
                    new MySqlParameter("@p_Id", aggregate.Id),
                    new MySqlParameter("@p_NombreUser", aggregate.NombreUser),
                    new MySqlParameter("@p_fechaNacimiento", aggregate.FechaNacimiento)
                };

                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return new RespuestaDB
                {
                    Resultado = "Operacion exitosa",
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


        /// <summary>
        /// Registra la url de la imagen del usuario
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> UploadImage(string UrlImage, string UID)
        {
            try
            {
                var sqlQuery = "CALL SP_ActualizarFotoUser(@p_Id, @p_FotoUser)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_Id", UID),
                    new MySqlParameter("@p_FotoUser", UrlImage)
                };

                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return new RespuestaDB
                {
                    Resultado = UrlImage,
                    NumError = 0
                };
            }
            catch(MySqlException ex)
            {
                return new RespuestaDB
                {
                    Resultado = $"Error en la base de datos: {ex.Message}",
                    NumError = 2
                };
            }
        }

        /// <summary>
        /// Actualiza los datos de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> UpdateUser(UpdateUserAggregate aggregate, string UID)
        {
            try
            {
                var sqlQuery = "CALL SP_ActualizarNombreYApellidoUsuario(@p_Id, @p_NombreUser, @p_ApellidoUsuario)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_Id", UID),
                    new MySqlParameter("@p_NombreUser", aggregate.Nombre),
                    new MySqlParameter("@p_ApellidoUsuario", aggregate.Apellido)
                };

                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return new RespuestaDB
                {
                    Resultado = "Operacion exitosa",
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

        /// <summary>
        /// Consulta un usuario por su id
        /// </summary>
        /// <returns></returns>
        public async Task<object> GetUser(string id)
        {
            try
            {
                var sqlQuery = "CALL SP_GetUsuarioById(@p_UserId)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_UserId", id)
                };

                var userList = await _context.usuarioDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                return userList.FirstOrDefault();
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

        /// <summary>
        /// Elimina un usuario por su id
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> DeleteUser(string id)
        {
            try
            {
                var sqlQuery = "CALL SP_EliminarUsuarioPorId(@p_UsuarioId)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_UsuarioId", id)
                };

                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return new RespuestaDB
                {
                    Resultado = "Operacion exitosa",
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

        /// <summary>
        /// obtiene el userDeviceId
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetUserDeviceId(string UID)
        {
            try
            {
                var sqlQuery = "CALL SP_ObtenerIdDevicePorUsuario(@usuarioId)";
                var parameter = new MySqlParameter("@usuarioId", UID);
                var idDevice = await _context.userDeviceDto.FromSqlRaw(sqlQuery, parameter).ToListAsync();
                var firstDevice = idDevice.FirstOrDefault();
                return firstDevice.idDevice;
            }
            catch (MySqlException ex)
            {
                return "Algo salio mal";
            }
        }
    }
}
