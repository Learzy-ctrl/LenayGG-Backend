using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGG.LenayGestorGatos.Domain.DTOs.Transaction
{
    public class CategoriaDto
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
        public string Icono { get; set; }
        public string Nombre { get; set; }
    }
}
