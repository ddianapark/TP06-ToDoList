using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_ToDoList.Models;

namespace TP06_ToDoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult VerTareas(int IdUsuario)
    {
        ViewBag.Tareas = BD.DevolverTareas(IdUsuario);
        ViewBag.IdUsuario = IdUsuario;

        return View("VerTareas");
    }

    public IActionResult CrearTarea(int IdUsuario)
    {     
        ViewBag.IdUsuario = IdUsuario;
        return View("CrearTarea");
    }

    public IActionResult CrearTareaGuardar(string titulo, string descripcion, DateTime fecha, bool finalizada, int IdUsuario)
    {        
        BD.CrearTarea(titulo,  descripcion,  fecha,  finalizada, IdUsuario);
        return RedirectToAction("VerTareas", "Home");
    }

    public IActionResult EditarTarea(int IdUsuario, int IdTarea)
    {        
        ViewBag.IdUsuario = IdUsuario;
        ViewBag.IdTarea = IdTarea;
        return View("ModificarTarea");
    }

    public IActionResult EditarTareaGuardar(int IdTareas , string titulo, string descripcion, DateTime fecha, bool finalizada, int IdUsuario)
    {        
        BD.ModificarTarea(IdTareas, titulo, descripcion, fecha, finalizada, IdUsuario);
        return RedirectToAction("VerTareas", "Home");
    }

    public IActionResult FinalizarTarea(int IdTarea)
    {        
        BD.FinalizarTarea(IdTarea);
        return RedirectToAction("VerTareas", "Home");
    }
    public IActionResult EliminarTarea(int IdTarea){

        BD.EliminarTarea(IdTarea);

        return RedirectToAction("VerTareas", "Home");
    }
}
