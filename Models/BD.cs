using Microsoft.Data.SqlClient;
using Dapper;

namespace TP06_ToDoList.Models;

public class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=ToDoList;Integrated Security=True;TrustServerCertificate=True;";

    public bool Registrarse(string Nombre, string username, string apellido, string password, string foto, DateTime FechaUltimoLog){
      Usuario Registrado = null;
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

 
}