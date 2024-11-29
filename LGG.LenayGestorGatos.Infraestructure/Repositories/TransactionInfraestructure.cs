/// Developer : Israel Curiel
/// Creation Date : 25/10/2024
/// Creation Description: Clase
/// Update Date : 03/11/2024
/// Update Description : Datos de envio agregados(Fecha Actual)
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Infraestructure.Repositories
{
    class TransactionInfraestructure : ITransactionInfraestructure
    {
        private readonly GestorGastosContext _context;
        public TransactionInfraestructure(GestorGastosContext context)
        {
            _context = context;
        }

        public async Task<RespuestaDB> AddGasto(TransactionAggregate aggregate)
        {
            try
            {
                var sqlQuery = "CALL SP_AgregarGasto(@p_DescripcionDelGasto, @p_Fecha, @p_IdCategoria, @p_IdBilletera, @p_Dinero, @p_IdUsuario)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_DescripcionDelGasto", aggregate.Descripcion),
                    new MySqlParameter("@p_Fecha", aggregate.Fecha),
                    new MySqlParameter("@p_IdCategoria", aggregate.IdCategoria),
                    new MySqlParameter("@p_IdBilletera", aggregate.IdBilletera),
                    new MySqlParameter("@p_Dinero", aggregate.Dinero),
                    new MySqlParameter("@p_IdUsuario", aggregate.IdUsuario)
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
                    NumError = 2
                };
            }
        }

        public async Task<RespuestaDB> AddIngreso(TransactionAggregate aggregate)
        {
            try
            {
                var sqlQuery = "CALL SP_AgregarIngreso(@p_Descripcion, @p_Fecha, @p_IdCategoria, @p_IdBilletera, @p_Dinero, @p_IdUsuario)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_Descripcion", aggregate.Descripcion),
                    new MySqlParameter("@p_Fecha", aggregate.Fecha),
                    new MySqlParameter("@p_IdCategoria", aggregate.IdCategoria),
                    new MySqlParameter("@p_IdBilletera", aggregate.IdBilletera),
                    new MySqlParameter("@p_Dinero", aggregate.Dinero),
                    new MySqlParameter("@p_IdUsuario", aggregate.IdUsuario)
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
                    NumError = 2
                };
            }
        }

        public async Task<object> GetRegistrosGastosByIdUsuario(string usuarioId, DateTime fechaActual)
        {
            try
            {
                var sqlQuery = "CALL SP_ConsultarGastosPorUsuario(@p_IdUsuario, @p_FechaActual)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_IdUsuario", usuarioId),
                    new MySqlParameter("@p_FechaActual", fechaActual)
                };
                var dataSP = await _context.gastoDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
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

        public async Task<object> GetRegistrosGastosByIdWallet(IdWalletAggregate aggregate, DateTime fechaActual)
        {
            try
            {
                var sqlQuery = "CALL SP_ConsultarGastosPorBilletera(@p_IdBilletera, @p_FechaActual)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_IdBilletera", aggregate.id),
                    new MySqlParameter("@p_FechaActual", fechaActual)
                };
                var dataSP = await _context.gastoDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
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

        public async Task<object> GetRegistrosIngresosByIdUsuario(string usuarioId, DateTime fechaActual)
        {
            try
            {
                var sqlQuery = "CALL SP_ConsultarIngresosPorUsuario(@p_IdUsuario, @p_FechaActual)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_IdUsuario", usuarioId),
                    new MySqlParameter("@p_FechaActual", fechaActual)
                };
                var dataSP = await _context.ingresoDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
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

        public async Task<object> GetRegistrosIngresosByIdWallet(IdWalletAggregate aggregate, DateTime fechaActual)
        {
            try
            {
                var sqlQuery = "CALL SP_ConsultarIngresosPorBilletera(@p_IdBilletera, @p_FechaActual)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_IdBilletera", aggregate.id),
                    new MySqlParameter("@p_FechaActual", fechaActual)
                };
                var dataSP = await _context.ingresoDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
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

        public async Task<object> GetCategorias()
        {
            try
            {
                var sqlQuery = "CALL SP_ConsultarCategorias()";
                var dataSP = await _context.categoriaDto.FromSqlRaw(sqlQuery).ToListAsync();
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
