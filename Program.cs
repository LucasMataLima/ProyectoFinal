using Lucas_Mata.DataBase;

namespace Lucas_Mata
{
    class Program
    {
        static void Main(string[] args)
        {   
            InicioSesion CheckSesiom = new InicioSesion();
            var Checkin = CheckSesiom.Sesion("Lucas666", "Lucas1234");

            if (Checkin.Id != 0)
            {
                ///Usuarios ------------------
                //Instancia del controlador 
                UsuarioHandler usuarioHandler = new UsuarioHandler();
                Console.WriteLine("Usuarios: ");
                //Ejecuto GetUsuario y lo almaceno en Usuario.
                var Usuario = usuarioHandler.GetUsuario("tcasazza");
                //Muestro Usuario
                Console.WriteLine("Id: " + Usuario.Id);
                Console.WriteLine("Nombre: " + Usuario.Nombre);
                Console.WriteLine("Apellido: " + Usuario.Apellido);
                Console.WriteLine("Nombre de Usuario: " + Usuario.NombreUsuario);
                Console.WriteLine("Contraseña: " + Usuario.Contraseña);
                Console.WriteLine("Mail: " + Usuario.Mail);
                Console.WriteLine("Producto seleccionado:" + Usuario.producto);
                Console.WriteLine("***");
                Console.WriteLine();

                //Producto ------------------
                //Instancia del controlador 
                ProductoHandler productoHandler = new ProductoHandler();
                Console.WriteLine("Productos: ");
                //Ejecuto GetProducto y lo almaceno en Usuario.
                foreach (var producto in productoHandler.GetProducto(Usuario.Id))
                {
                    //Muestro Producto
                    Console.WriteLine("Id: " + producto.Id);
                    Console.WriteLine("Descripción: " + producto.Descripcion);
                    Console.WriteLine("Costo: $" + producto.Costo);
                    Console.WriteLine("Precio de venta: $" + producto.PrecioVenta);
                    Console.WriteLine("Stock: " + producto.Stock);
                    Console.WriteLine("Id Usuario: " + producto.IdUsuario);
                    Console.WriteLine("***");
                    Console.WriteLine();
                }

                //Producto Vendido
                ProductosVendidosHandler productoVendidoHandler = new ProductosVendidosHandler();
                Console.WriteLine("Productos Vendidos: ");
                foreach (var item in productoVendidoHandler.GetProductoVendido(Usuario.Id))
                {
                    Console.WriteLine("Stock: " + item.Stock);
                    Console.WriteLine("Id Venta:" + item.IdVenta);
                    Console.WriteLine("Id Producto: " + item.IdProducto.Id);
                    Console.WriteLine("Descripción: " + item.IdProducto.Descripcion);
                    Console.WriteLine("Costo: $" + item.IdProducto.Costo);
                    Console.WriteLine("Precio de Venta: $" + item.IdProducto.PrecioVenta);
                    Console.WriteLine("Stock restante: " + item.IdProducto.Stock);
                    Console.WriteLine("***");
                }
                Console.ReadLine();

                //Venta ------------------
                //Instancia del controlador 
                VentasHandler ventasHandler = new VentasHandler();
                Console.WriteLine("Ventas: ");
                //Ejecuto GetVentas y lo almaceno.
                foreach (var venta in ventasHandler.GetVentas(Usuario.Id))
                    {
                    Console.WriteLine("Id: " + venta.Id);
                    Console.WriteLine("Comentarios: " + venta.Comentarios);
                    Console.WriteLine("***");
                    }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(Checkin.Nombre);
            }
            Console.ReadLine();
        }
    }
}