/// Developer : Israel Curiel
/// Creation Date : 25/10/2024
/// Creation Description:Interface
/// Update Date : 30/10/2024
/// Update Description : Metodo GetCategorias Agregado
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Domain.Interfaces.Services
{
    public interface ITransactionPresenter
    {
        /// <summary>
        /// Agrega un registro a la tabla Gasto
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> AddGasto(TransactionAggregate aggregate, string token);

        /// <summary>
        /// Agrega un registro a la tabla Ingreso
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> AddIngreso(TransactionAggregate aggregate, string token);

        /// <summary>
        /// Realiza una transferencia ingresando datos a las tablas Gasto e Ingreso
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> AddTransferencia(TransferAggregate aggregate, string token);

        /// <summary>
        /// Obtiene todos los registros de las tablas Gasto e Ingreso de una billetera en especifico 
        /// </summary>
        /// <returns></returns>
        Task<object> GetTransaccionesByIdWallet(WalletFechaTransactionAggregate aggregate, string token);

        /// <summary>
        /// Obtiene todos los registros de las tablas Gasto e Ingreso de un usuario en especifico
        /// </summary>
        /// <returns></returns>
        Task<object> GetTransaccionesByIdUsuario(FechaTransactionAggregate aggregate, string token);


        /// <summary>
        /// Obtiene todas las categorias de la bd
        /// </summary>
        /// <returns></returns>
        Task<object> GetCategorias(string token);

    }
}
