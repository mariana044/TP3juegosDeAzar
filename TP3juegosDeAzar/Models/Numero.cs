namespace TP3juegosDeAzar.Models
{
    public class Numero
    {
        public int NumeroId { get; set; }
        public int Orden { get; set; }
        public int Valor { get; set; }

        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
