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
            string query = "SELECT * FROM Usuario WHERE username = @pusername";
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
            string query = "SELECT * FROM Usuario WHERE username = @pusername AND password = @ppassword";
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
            
                Lista = connection.Query<Tarea>(query). ToList();
           
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
    public static void ModificarTarea(Tarea tarea)
    {
        
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tareas SET titulo, descripcion, fecha, finalizada, IdUsuario WHERE IdTareas = @pIdTareas";

            connection.Execute(query, new { pIdTareas = tarea.IdTareas});
        }

    }
    public static void EliminarTarea(int IdTareas)
    {
         using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "DELETE Tareas WHERE IdTareas = @pIdTareas";

            connection.Execute(query, new { pIdTareas = IdTareas});
        }

    }
    public static void CrearTarea(Tarea tarea)
    {
        
            string query = "INSERT INTO Tarea (titulo, descripcion, fecha, finalizada, IdUsuario) VALUES (@ptitulo, @pdescripcion, @pfecha, @pfinalizada, @pIdUsuario)";

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new { ptitulo = tarea.titulo, pdescripcion = tarea.descripcion, pfecha = tarea.fecha, pfinalizada = tarea.finalizada, pIdUsuario = tarea.IdUsuario});
                
            }
    } 


    public static void FinalizarTarea( int IdTareas)
    {

         using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tareas SET finalizada WHERE IdTareas = @pIdTareas";

            connection.Execute(query, new { pIdTareas = IdTareas});
        }

    }
    public static void ActLogin(int IdUsuarios)
    {
             using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tareas SET username, password WHERE IdUsuarios = @pUsusarios";

            connection.Execute(query, new { pUsuarios = IdUsuarios});
        }

    }
 
}