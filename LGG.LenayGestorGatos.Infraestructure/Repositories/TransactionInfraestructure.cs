using LGG.LenayGestorGatos.Domain.Aggregates.Transactions;
using LGG.LenayGestorGatos.Domain.Aggregates.Wallet;

/// Developer : Israel Curiel
/// Creation Date : 25/10/2024
/// Creation Description: Clase
/// Update Date : --
/// Update Description : --
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

        public async Task<object> GetRegistrosGastosByIdUsuario(string token)
        {
            try
            {
                var sqlQuery = "CALL SP_ConsultarIngresosPorUsuario(@p_IdUsuario)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_IdUsuario", )
                };
            }
            catch(MySqlException ex)
            {

            }
        }

        public Task<object> GetRegistrosGastosByIdWallet(IdWalletAggregate aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetRegistrosIngresosByIdUsuario(string token)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetRegistrosIngresosByIdWallet(IdWalletAggregate aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
