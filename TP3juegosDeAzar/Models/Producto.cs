using System;
using System.Collections.Generic;

namespace TP3juegosDeAzar.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaHoraCreacion { get; set; } = DateTime.Now;

        public virtual ICollection<Numero> Numeros { get; set; }
    }
}

