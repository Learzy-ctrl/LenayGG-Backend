/// Developer : Israel Curiel
/// Creation Date : 10/10/2024
/// Creation Description: Clase
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
using LGG.LenayGestorGatos.Domain.Aggregates.Wallet;
using LGG.LenayGestorGatos.Domain.DTOs.Wallet;

namespace LGG.LenayGestorGatos.Infraestructure.Repositories
{
    public class WalletInfraestructure : IWalletInfraestructure
    {
        private readonly GestorGastosContext _context;
        public WalletInfraestructure(GestorGastosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Agrega un registro de la tabla Billetera
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> AddWallet(WalletAggregate aggregate)
        {
            try
            {
                // Define la consulta SQL para llamar al procedimiento almacenado
                var sqlQuery = "CALL SP_InsertarBilletera(@p_Nombre, @p_Saldo, @p_LimiteCredito, @p_TasaInteres, @p_IdTipoCuenta, @p_FechaDePago, @p_FechaCorte, @p_IdUsuario, @p_Color)";

                // Define los parámetros para el procedimiento almacenado
                var parameters = new[]
                {
                    new MySqlParameter("@p_Nombre", aggregate.Nombre),
                    new MySqlParameter("@p_Saldo", aggregate.Saldo),
                    new MySqlParameter("@p_LimiteCredito", aggregate.LimiteCredito),
                    new MySqlParameter("@p_TasaInteres", aggregate.TazaInteres),
                    new MySqlParameter("@p_IdTipoCuenta", aggregate.IdTipoCuenta),
                    new MySqlParameter("@p_FechaDePago", aggregate.FechaDePago),
                    new MySqlParameter("@p_FechaCorte", aggregate.FechaCorte),
                    new MySqlParameter("@p_IdUsuario", aggregate.IdUsuario),
                    new MySqlParameter("@p_Color", aggregate.Color)
                };

                // Ejecuta la consulta SQL asíncrona
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
                    NumError = 1
                };
            }
        }

        /// <summary>
        /// Consulta las billeteras de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<List<WalletDto>> GetWallets(string IdUser)
        {
            try
            {
                var sqlQuery = "CALL SP_ConsultarBilleterasPorUsuario(@p_IdUsuario)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_IdUsuario", IdUser),
                };
                var dataSP = await _context.walletDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
            }catch(MySqlException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Consulta una billetera de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<WalletDto> GetWalletById(IdWalletAggregate idWallet)
        {
            try
            {
                var sqlQuery = "CALL SP_ConsultarBilleteraEspecifica(@p_IdBilletera)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_IdBilletera", idWallet.id)
                };
                var dataSP = await _context.walletDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Edita algunos campos de una billetera
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> UpdateWallet(WalletAggregate aggregate)
        {
            try
            {
                var sqlQuery = "CALL SP_EditarBilletera(@p_IdBilletera, @p_Nombre, @p_LimiteCredito, @p_TasaInteres, @p_FechaDePago, @p_FechaCorte, @p_Color)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_IdBilletera", aggregate.idBilletera),
                    new MySqlParameter("@p_Nombre", aggregate.Nombre),
                    new MySqlParameter("@p_LimiteCredito", aggregate.LimiteCredito),
                    new MySqlParameter("@p_TasaInteres", aggregate.TazaInteres),
                    new MySqlParameter("@p_FechaDePago", aggregate.FechaDePago),
                    new MySqlParameter("@p_FechaCorte", aggregate.FechaCorte),
                    new MySqlParameter("@p_Color", aggregate.Color)
                };

                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);
                return new RespuestaDB
                {
                    Resultado = "Operacion exitosa",
                    NumError = 0
                };
            }
            catch(MySqlException ex)
            {
                return new RespuestaDB
                {
                    Resultado = $"Error en la base de datos: {ex.Message}",
                    NumError = 1
                };
            }
        }

        /// <summary>
        /// Elimina una billetera por su id
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> DeleteWallet(IdWalletAggregate idWallet)
        {
            try
            {
                var sqlQuery = "CALL SP_EliminarBilletera(@p_IdBilletera)";
                var parameters = new[]
                {
                    new MySqlParameter("@p_IdBilletera", idWallet.id)
                };
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);
                return new RespuestaDB
                {
                    Resultado = "Operacion exitosa",
                    NumError = 0
                };
            }catch(MySqlException ex)
            {
                return new RespuestaDB
                {
                    Resultado = $"Ocurrio un error {ex.Message}",
                    NumError = 1
                };
            }
        }
    }
}
