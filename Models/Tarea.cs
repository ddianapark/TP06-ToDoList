namespace TP06_ToDoList.Models;

public class Tarea
{
    public int IdTareas { get; set; }
    public string titulo { get; set; }
    public string descripcion { get; set; }
    public DateTime fecha { get; set; }
    public bool finalizada { get; set; }
    public int IdUsuario { get; set; }
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