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
                var connection = _context.Database.GetDbConnection();

                var parameters = new DynamicParameters();
                parameters.Add("p_Id", aggregate.Id, DbType.String);
                parameters.Add("p_NombreUser", aggregate.NombreUser, DbType.String);
                parameters.Add("p_fechaNacimento", aggregate.FechaNacimiento, DbType.DateTime);

                await connection.ExecuteAsync("InsertarUsuario", parameters, commandType: CommandType.StoredProcedure);

                var respuesta = new RespuestaDB
                {
                    Mensaje = "Usuario insertado con éxito",
                    TipoError = 0
                };

                return respuesta;
            }
            catch (MySqlException ex)
            {
                return new RespuestaDB
                {
                    Mensaje = $"Error en la base de datos: {ex.Message}",
                    TipoError = 1
                };
            }
        }

    }
}
