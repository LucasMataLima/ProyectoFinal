using Lucas_Mata.DataBase;

namespace Lucas_Mata
{
    class Program
    {
        static void Main(string[] args)
        {   
            InicioSesion CheckSesiom = new InicioSesion();
            CheckSesiom.NombreUsuario = "Lucas666";
            CheckSesiom.Contraseña = "Lucas1234";

            if (CheckSesiom.Sesion())
            {
                ProductoHandler productoHandler = new ProductoHandler();
                productoHandler.GetProducto();

                UsuarioHandler usuarioHandler = new UsuarioHandler();
                usuarioHandler.GetUsuario();

                ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();
                productoVendidoHandler.GetProductoVendido();

                VentasHandler ventasHandler = new VentasHandler();
                ventasHandler.GetVentas();
            }
        }
    }
}