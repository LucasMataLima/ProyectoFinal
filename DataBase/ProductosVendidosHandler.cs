using Lucas_Mata.Class;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Lucas_Mata.DataBase
{
    public class ProductosVendidosHandler : DBHandler
    {
        public List<ProductoVendido> GetProductoVendido(int IdUsuario)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
           
            // el ConnectionString se encuientra en DBHandler
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                
                //Producto ------------------
                //Instancia del controlador 
                ProductoHandler productoHandler = new ProductoHandler();
                foreach (var producto in productoHandler.GetProducto(IdUsuario))
                {

                    var query = "SELECT PV.id, PV.Stock, PV.IdVenta FROM ProductoVendido as PV " +
                                "INNER JOIN Producto as Pro on Pro.id = PV.IdProducto " +
                                "WHERE Pro.Id = @Id";

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlConnection.Open();
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = producto.Id});
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    ProductoVendido productoVendido = new ProductoVendido();
                                    productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                    productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                    productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                    productoVendido.IdProducto.Id = producto.Id;
                                    productoVendido.IdProducto.Descripcion = producto.Descripcion;
                                    productoVendido.IdProducto.Costo = producto.Costo;
                                    productoVendido.IdProducto.PrecioVenta = producto.PrecioVenta;
                                    productoVendido.IdProducto.Stock = producto.Stock;
                                    productosVendidos.Add(productoVendido);
                                }
                            }
                        }
                        sqlConnection.Close();
                    }
                }
            }
            return productosVendidos;
        }
    }
}
