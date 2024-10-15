/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description:Interface
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Domain.Interfaces.Services
{
    public interface IWalletPresenter
    {
        /// <summary>
        /// Agrega un registro a la tabla Billetera
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> AddWallet(WalletAggregate aggregate, string token);

        /// <summary>
        /// Consulta todas las billeteras del usuario
        /// </summary>
        /// <returns></returns>
        Task<List<WalletDto>> GetWallets(string token);

        /// <summary>
        /// Consulta una billetera del usuario
        /// </summary>
        /// <returns></returns>
        Task<WalletDto> GetWalletById(string token, IdWalletAggregate idWallet);

        /// <summary>
        /// Edita algunos campos de una billetera
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> UpdateWallet(string token, WalletAggregate aggregate);

        /// <summary>
        /// Elimina una billetera con su id
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> DeleteWallet(string token, IdWalletAggregate idWallet);
    }
}
