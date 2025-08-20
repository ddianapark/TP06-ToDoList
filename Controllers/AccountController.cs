using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_ToDoList.Models;

namespace TP06_ToDoList.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public AccountController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult LogIn()
    {        
        return View("Login");
    }

    public IActionResult LogInGuardar(string username, string password)
    {        
        Usuario usu = BD.Login(username, password);
        return RedirectToAction("VerTareas", "Home", new { IdUsuario = usu.IdUsuario });
    }

     public IActionResult Registrarse()
    {        
        return View("Registro");
    }

    public IActionResult RegistroGuardar(string nombre, string apellido, string username, string password, DateTime fechaUltimoLog, string foto)
    {        
        BD.Registrarse(nombre, apellido, username, password, fechaUltimoLog, foto);
        return RedirectToAction("Index", "Home");
    }
    
}
