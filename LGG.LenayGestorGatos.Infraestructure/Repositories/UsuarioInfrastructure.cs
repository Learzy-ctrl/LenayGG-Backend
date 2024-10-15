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
                    NumError = 1
                };
            }
        }

    }
}
