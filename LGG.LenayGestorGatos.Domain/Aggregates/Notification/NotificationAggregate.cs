using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGG.LenayGestorGatos.Domain.Aggregates.Notification
{
    public class NotificationAggregate
    {
        public string encabezado { get; set; }
        public string cuerpo { get; set; }
        public DateTime fecha { get; set; }
        public string idUsuario { get; set; }
    }
}
