/// Developer : Israel Curiel
/// Creation Date : 14/11/2024
/// Creation Description: Clase
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Aplication.Presenters
{
    public class ReportePresenter : IReportePresenter
    {
        private IUnitRepository _unitRepository;
        private IMapper _mapper;

        public ReportePresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<object> GetGastosByFilter(ConsultaGastosAggregate aggregate, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            aggregate.id_usuario = respuesta.Resultado;
            return await _unitRepository.reporteInfrastructure.GetGastosByFilter(aggregate);
        }
    }
}
