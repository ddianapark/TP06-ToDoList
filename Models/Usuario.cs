namespace TP06_ToDoList.Models;

public class Usuario
{
    public int IdUsuario { get; set; }
    public string Nombre { get; set; }
    public string apellido { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public DateTime FechaUltimoLog { get; set; }
    public string foto { get; set; }

    public Usuario (){}
    public Usuario (string Nombre, string apellido, string username, string password, DateTime fechaUltimoLogin, string foto)
    {
        this.Nombre = Nombre;
        this.apellido = apellido;
        this.username = username;
        this.password = password;
        this.FechaUltimoLog = fechaUltimoLogin;
        this.foto = foto;
    }
}