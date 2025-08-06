namespace TP06_ToDoList.Models;

public class Usuario
{
    int IdUsuarios { get; set; }
    string Nombre { get; set; }
    string apellido { get; set; }
    string username { get; set; }
    string password { get; set; }
    DateTime FechaUltimoLog { get; set; }
    string foto { get; set; }

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