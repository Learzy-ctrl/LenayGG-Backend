using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGG.LenayGestorGatos.Domain.DTOs.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Cuerpo { get; set; }
        public bool isRead { get; set; }
    }
}
