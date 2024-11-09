
namespace LGG.LenayGestorGatos.Domain.DTOs.Transaction
{
    public class IngresoDto
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string CategoriaIcono { get; set; }
        public string CategoriaColor { get; set; }
        public string CategoriaNombre { get; set; }
        public decimal Dinero { get; set; }
        public decimal BilleteraSaldo { get; set; }
        public string BilleteraNombre { get; set; }
        public string BilleteraColor { get; set; }
    }
}
