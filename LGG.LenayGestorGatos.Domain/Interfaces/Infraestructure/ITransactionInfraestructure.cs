﻿/// Developer : Israel Curiel
/// Creation Date : 25/10/2024
/// Creation Description:Interface
/// Update Date : 30/10/2024
/// Update Description : Metodo GetCategorias Agregado
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Domain.Interfaces.Infraestructure
{
    public interface ITransactionInfraestructure
    {
        /// <summary>
        /// Agrega un registro a la tabla Gasto
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> AddGasto(TransactionAggregate aggregate);

        /// <summary>
        /// Agrega un registro a la tabla Ingreso
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> AddIngreso(TransactionAggregate aggregate);

        /// <summary>
        /// Obtiene todos los registros de la tabla Gasto de una billetera en especifico 
        /// </summary>
        /// <returns></returns>
        Task<object> GetRegistrosGastosByIdWallet(IdWalletAggregate aggregate, DateTime fechaActual);

        /// <summary>
        /// Obtiene todos los registros de la tabla Ingreso de una billetera en especifico 
        /// </summary>
        /// <returns></returns>
        Task<object> GetRegistrosIngresosByIdWallet(IdWalletAggregate aggregate, DateTime fechaActual);

        /// <summary>
        /// Obtiene todos los registros de la tabla Gasto de un usuario en especifico
        /// </summary>
        /// <returns></returns>
        Task<object> GetRegistrosGastosByIdUsuario(string usuarioId, DateTime fechaActual);

        /// <summary>
        /// Obtiene todos los registros de la tabla Ingreso de un usuario en especifico
        /// </summary>
        /// <returns></returns>
        Task<object> GetRegistrosIngresosByIdUsuario(string usuarioId, DateTime fechaActual);

        /// <summary>
        /// Obtiene todas las categorias de la bd
        /// </summary>
        /// <returns></returns>
        Task<object> GetCategorias();
    }
}
