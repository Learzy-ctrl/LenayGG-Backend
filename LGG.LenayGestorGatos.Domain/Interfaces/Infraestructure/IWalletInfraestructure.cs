/// Developer : Israel Curiel
/// Creation Date : 10/10/2024
/// Creation Description:Interface
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Domain.Interfaces.Infraestructure
{
    public interface IWalletInfraestructure
    {
        /// <summary>
        /// Agrega un registro a la tabla Billetera
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB> AddWallet(WalletAggregate aggregate);

        /// <summary>
        /// Consulta todas las billeteras del usuario
        /// </summary>
        /// <returns></returns>
        Task<List<WalletDto>> GetWallets(string IdUser);

        /// <summary>
        /// Consulta una billetera del usuario
        /// </summary>
        /// <returns></returns>
        Task<WalletDto> GetWalletById(IdWalletAggregate idWallet);

        /// <summary>
        /// Edita algunos campos de una billetera
        /// </summary>
        /// <returns></returns>
        Task<RespuestaDB>UpdateWallet(WalletAggregate aggregate);
    }
}
