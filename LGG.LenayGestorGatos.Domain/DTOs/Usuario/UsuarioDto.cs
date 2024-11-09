using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGG.LenayGestorGatos.Domain.DTOs.Usuario
{
    public class UsuarioDto
    {
        [Key]
        public string Id { get; set; }
        public string? FotoUser {  get; set; }
        public string NombreUser {  get; set; }
        public string? ApellidoUsuario {  get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
