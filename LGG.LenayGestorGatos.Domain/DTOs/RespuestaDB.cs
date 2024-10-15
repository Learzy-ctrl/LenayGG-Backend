/// Developer : Nombre desarrollador
/// Creation Date : 25/09/2024
/// Creation Description:Dto class
/// Update Date : --
/// Update Description : --
///CopyRight: Nombre proyecto
namespace LGG.LenayGestorGatos.Domain.DTOs
{
    public class RespuestaDB
    {
        [Key]
        public int NumError {  get; set; }
        public string Resultado {  get; set; }
    }
}
