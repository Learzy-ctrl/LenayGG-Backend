
namespace LGG.LenayGestorGatos.Domain.Aggregates.Reportes
{
    public class ConsultaGastosAggregate
    {
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin {  get; set; }
        public string? id_usuario { get; set; }
        public Guid? id_billetera { get; set; }
        public bool todas_billeteras { get; set; }
    }
}
