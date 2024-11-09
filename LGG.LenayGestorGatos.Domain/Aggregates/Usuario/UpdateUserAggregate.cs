using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGG.LenayGestorGatos.Domain.Aggregates.Usuario
{
    public class UpdateUserAggregate
    {
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
    }
}
