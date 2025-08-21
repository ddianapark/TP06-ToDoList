using Microsoft.Data.SqlClient;
using Dapper;

namespace TP06_ToDoList.Models;

public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=ToDoList;Integrated Security=True;TrustServerCertificate=True;";

    public static bool Registrarse(string Nombre, string apellido, string username, string password, DateTime fechaUltimoLog, string foto)
    {
        if(!BuscarUsuario(username))
        {
            string query = "INSERT INTO Usuarios (Nombre, apellido, username, password, FechaUltimoLog, foto) VALUES (@pNombre, @papellido, @pusername, @ppassword, @pfechaUltimoLog, @pfoto)";

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new { pNombre = Nombre, papellido = apellido, pusername = username, ppassword = password, pfechaUltimoLog = fechaUltimoLog, pfoto = foto});
            }
            return true;
        }else{
            return false;
        }
    }
    
    public static bool BuscarUsuario(string username)
    {
        Usuario miUsuario;
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE username = @pusername";
            miUsuario = connection.QueryFirstOrDefault<Usuario>(query, new { pusername = username});
        }
        if(miUsuario == null)
        {
            return false;
        }else{
            return true;
        }
    }
    public static Usuario Login(string username, string password)
    {
       
        Usuario miUsuario = null;
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE username = @pusername AND password = @ppassword";
            if(query == null){

            } else{
                miUsuario = connection.QueryFirstOrDefault<Usuario>(query, new { pusername = username, ppassword = password});
            }
           
        }
        return miUsuario;
    }

    public static List<Tarea> DevolverTareas(int IdUsuario)
    {
        List<Tarea> Lista = new List<Tarea>();

          using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE IdUsuario = @pIdusuario";
            
                Lista = connection.Query<Tarea>(query, new {pIdusuario = IdUsuario}). ToList();
           
           return Lista;
        }
    }
    public static Tarea DevolverTarea( int IdTareas)
    {
         Tarea Tarea = null;

          using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE IdTareas = @pIdTareas";
         
                Tarea = connection.QueryFirstOrDefault<Tarea>(query, new {pIdTareas = IdTareas});

           return Tarea;
        }

    }
     public static bool BuscarTarea(int IdTarea)
    {
        Tarea Tarea;
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE IdTarea = @pIdTarea";
            Tarea = connection.QueryFirstOrDefault<Tarea>(query, new { pIdTarea = IdTarea});
        }
        if(Tarea == null)
        {
            return false;
        }else{
            return true;
        }
    }
    public static void ModificarTarea(int IdTareas, string titulo, string descripcion, DateTime fecha, bool finalizada, int IdUsuario)
    {
        
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
           string query = "UPDATE Tareas SET titulo = @ptitulo, descripcion = @pdescripcion, fecha = @pfecha, finalizada = @pfinalizada, IdUsuario = @pIdUsuario WHERE IdTareas = @pIdTareas";
           connection.Execute(query, new { ptitulo = titulo, pdescripcion = descripcion, pfecha = fecha, pfinalizada = finalizada, pIdUsuario = IdUsuario, pIdTareas = IdTareas});
        }

    }
    public static void EliminarTarea(int IdTareas)
    {
         using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "DELETE FROM Tareas WHERE IdTareas = @pIdTareas";

            connection.Execute(query, new { pIdTareas = IdTareas});
        }

    }
    public static void CrearTarea(string titulo, string descripcion, DateTime fecha, bool finalizada, int IdUsuario)
    {
        
            string query = "INSERT INTO Tareas (titulo, descripcion, fecha, finalizada, IdUsuario) VALUES (@ptitulo, @pdescripcion, @pfecha, @pfinalizada, @pIdUsuario)";

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new { ptitulo = titulo, pdescripcion = descripcion, pfecha = fecha, pfinalizada = finalizada, pIdUsuario = IdUsuario});             
            }
    } 


    public static void FinalizarTarea( int IdTareas)
    {

         using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tareas SET finalizada = 1 WHERE IdTareas = @pIdTareas";

            connection.Execute(query, new { pIdTareas = IdTareas});
        }

    }
    public static void ActLogin(int IdUsuarios)
    {
             using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Usuarios SET username, password WHERE IdUsuarios = @pUsusarios";

            connection.Execute(query, new { pUsuarios = IdUsuarios});
        }

    }
 
}