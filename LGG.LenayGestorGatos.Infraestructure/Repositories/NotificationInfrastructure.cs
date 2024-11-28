/// Developer : Israel Curiel
/// Creation Date : 28/11/2024
/// Creation Description: Clase
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos

namespace LGG.LenayGestorGatos.Infraestructure.Repositories
{
    public class NotificationInfrastructure : INotificationInfrastructure
    {
        private readonly GestorGastosContext _context;
        public NotificationInfrastructure(GestorGastosContext context)
        {
            _context = context;
        }
    }
}
