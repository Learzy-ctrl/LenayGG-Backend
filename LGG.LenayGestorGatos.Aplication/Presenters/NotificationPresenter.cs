/// Developer : Israel Curiel
/// Creation Date : 28/11/2024
/// Creation Description:Clase
/// Update Date : --/--/--
/// Update Description : ----
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Aplication.Presenters
{
    public class NotificationPresenter : INotificationPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        public NotificationPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<RespuestaDB> CheckIsDeleted(List<IdNotificationAggregate> aggregates, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            return await _unitRepository.notificationInfrastructure.CheckIsDeleted(aggregates);
        }

        public async Task<RespuestaDB> CheckIsRead(List<IdNotificationAggregate> aggregates, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            return await _unitRepository.notificationInfrastructure.CheckIsRead(aggregates);
        }

        public async Task<List<NotificationDto>> GetNotifications(string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return null;
            }
            return await _unitRepository.notificationInfrastructure.GetNotifications(respuesta.Resultado);
        }
    }
}
