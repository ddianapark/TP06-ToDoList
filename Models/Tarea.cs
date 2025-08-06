namespace TP06_ToDoList.Models;

public class Tarea
{
    int IdTareas { get; set; }
    string titulo { get; set; }
    string descripcion { get; set; }
    DateTime fecha { get; set; }
    bool finalizada { get; set; }
    int IdUsuario { get; set; }
    public Tarea(){}
    public Tarea (string titulo, string descripcion, DateTime fecha, bool finalizada, int IdUsuario)
    {
        this.titulo = titulo;
        this.descripcion = descripcion;
        this.fecha = fecha;
        this.finalizada = finalizada;
        this.IdUsuario = IdUsuario;
    }
}