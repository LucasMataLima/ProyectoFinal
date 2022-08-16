using System.Data;
using Lucas_Mata.Class;
using System.Data.SqlClient;

namespace Lucas_Mata.DataBase
{
    public class InicioSesion : DBHandler
    {
        public Usuario Sesion(string NombreUsuario, string Contraseña)
        {
            Usuario usuario = new Usuario();
            // el ConnectionString se encuientra en DBHandler
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
                            usuario.Id = Convert.ToInt32(dataReader["id"]);
                            usuario.Nombre = dataReader["Nombre"].ToString();
                            usuario.Apellido = dataReader["Apellido"].ToString();
                            usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                            usuario.Mail = dataReader["Mail"].ToString();
                            usuario.Contraseña = dataReader["Contraseña"].ToString();
                        }
                        else
                        {
                            usuario.Id = 0;
                        }
                    }
                }
                sqlConnection.Close();
             }
            return usuario;
        }
    }
}
