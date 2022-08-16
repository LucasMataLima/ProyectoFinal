using System.Collections.Generic;
namespace Lucas_Mata.Class
{
    public class ProductoVendido
    {
        //---- Property 
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdVenta { get; set; }
        public Producto IdProducto { get; set; }

        public ProductoVendido()
        {
            Producto producto = new Producto();
            IdProducto = producto;
        }
    }
}
