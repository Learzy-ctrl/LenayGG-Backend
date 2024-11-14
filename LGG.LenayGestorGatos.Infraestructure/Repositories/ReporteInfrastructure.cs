/// Developer : Israel Curiel
/// Creation Date : 14/11/2024
/// Creation Description: Clase
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Infraestructure.Repositories
{
    public class ReporteInfrastructure : IReporteInfrastructure
    {
        private GestorGastosContext _context;

        public ReporteInfrastructure(GestorGastosContext contexto)
        {
            _context = contexto;
        }

        public async Task<object> GetGastosByFilter(ConsultaGastosAggregate aggregate)
        {
            try
            {
                var sqlQuery = "CALL SP_ObtenerGastosCategorizados(@fecha_inicio, @fecha_fin, @id_usuario, @id_billetera, @todas_billeteras)";
                var parameters = new[]
                {
                    new MySqlParameter("@fecha_inicio", aggregate.fecha_inicio),
                    new MySqlParameter("@fecha_fin", aggregate.fecha_fin),
                    new MySqlParameter("@id_usuario", aggregate.id_usuario),
                    new MySqlParameter("@id_billetera", aggregate.id_billetera),
                    new MySqlParameter("@todas_billeteras", aggregate.todas_billeteras)
                };
                var dataSP = await _context.gastosPorCategoriaDtos.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
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
    }
}
