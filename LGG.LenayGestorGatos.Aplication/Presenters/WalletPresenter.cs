/// Developer : Israel Curiel
/// Creation Date : 10/10/2024
/// Creation Description:Clase
/// Update Date : 17/10/2024
/// Update Description : Cambio de retorno en metodos
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Aplication.Presenters
{
    public class WalletPresenter : IWalletPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        public WalletPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Agrega un registro a la tabla Billetera
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> AddWallet(WalletAggregate aggregate, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if(respuesta.NumError != 0)
            {
                return respuesta;
            }
            aggregate.IdUsuario = respuesta.Resultado;
            return await _unitRepository.walletInfraestructure.AddWallet(aggregate);
        }

        /// <summary>
        /// Consulta las billeteras registradas de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<object> GetWallets(string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            var IdUser = respuesta.Resultado;
            return await _unitRepository.walletInfraestructure.GetWallets(IdUser);
        }

        /// <summary>
        /// Consulta una billetera de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<object> GetWalletById(string token, IdWalletAggregate idWallet)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            return await _unitRepository.walletInfraestructure.GetWalletById(idWallet);
        }

        /// <summary>
        /// Edita algunos campos de una billetera
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> UpdateWallet(string token, WalletAggregate aggregate)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            return await _unitRepository.walletInfraestructure.UpdateWallet(aggregate);
        }

        public async Task<RespuestaDB> DeleteWallet(string token, IdWalletAggregate idWallet)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            return await _unitRepository.walletInfraestructure.DeleteWallet(idWallet);
        }
    }
}
