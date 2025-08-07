using Microsoft.Data.SqlClient;
using Dapper;

namespace TP06_ToDoList.Models;

public class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=ToDoList;Integrated Security=True;TrustServerCertificate=True;";

    public bool Registrarse(Usuario Usu)
    {
        if(!BuscarUsuario(Usu.username))
        {
            string query = "INSERT INTO Usuarios (Nombre, apellido, username, password, FechaUltimoLog, foto) VALUES (@pNombre, @papellido, @pusername, @ppassword, @pFechaUltimoLog, @pfoto)";

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new { pNombre = Usu.Nombre, papellido = Usu.apellido, pusername = Usu.username, ppassword = Usu.password, pFechaUltimoLog = Usu.FechaUltimoLog, pfoto = Usu.foto});
            }
            return true;
        }else{
            return false;
        }
    }
    
    public bool BuscarUsuario(string username)
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
    public Usuario Login(string Nombre, string password)
    {
       
        Usuario miUsuario = null;
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuario WHERE Nombre = @pNombre AND @password = @ppassword";
            if(query == null){

            } else{
                miUsuario = connection.QueryFirstOrDefault<Usuario>(query, new { pNombre = Nombre, ppassword = password});
            }
           
        }
        return miUsuario;
    }

    public List<Tarea> DevolverTareas(int IdUsuario)
    {
        List<Tarea> Lista = new List<Tarea>();

          using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE IdUsuario = @pIdusuario";
            if(query == null){

            } else{
                miUsuario = connection.QueryFirstOrDefault<Usuario>(query, new { pNombre = Nombre, ppassword = password});
            }
           
        }
    }

 
}