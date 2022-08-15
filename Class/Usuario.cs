namespace Lucas_Mata.Class
{
    public class Usuario
    {
        //---- Property 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string Mail { get; set; }
        public List<Producto> producto { get; set; }
    }
}
