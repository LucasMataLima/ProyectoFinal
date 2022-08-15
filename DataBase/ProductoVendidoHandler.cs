using Lucas_Mata.Class;
using System.Data.SqlClient;

namespace Lucas_Mata.DataBase
{
    public class ProductoVendidoHandler : DBHandler
    {
        public List<ProductoVendido> GetProductoVendido()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return productosVendidos;
        }
    }
}
