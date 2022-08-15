using System.Data;
using System.Data.SqlClient;

namespace Lucas_Mata.DataBase
{
    public class InicioSesion : DBHandler
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        public bool Sesion()
        {
            bool respuesta = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var query = @"SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario and Contraseña = @Contraseña";

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = NombreUsuario });
                        sqlCommand.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = Contraseña });
                        sqlCommand.ExecuteNonQuery();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                respuesta = true;
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception)
            {
                return respuesta;
            }
            return respuesta;
        }
    }
}
