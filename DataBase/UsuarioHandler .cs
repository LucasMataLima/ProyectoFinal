using Lucas_Mata.Class;
using System.Data.SqlClient;

namespace Lucas_Mata.DataBase
{
    public class UsuarioHandler : DBHandler
    {
        public List<Usuario> GetUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dataReader["ID"]);
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Contrasenia = dataReader["Contrasenia"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();
                                usuarios.Add(usuario);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return usuarios;
        }
    }
}
