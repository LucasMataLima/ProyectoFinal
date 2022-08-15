using Lucas_Mata.Class;
using System.Data.SqlClient;

namespace Lucas_Mata.DataBase
{
    public class VentasHandler : DBHandler
    {
        public List<Venta> GetVentas()
        {
            List<Venta> Ventas = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Stock"].ToString();
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return Ventas;
        }
    }
}
