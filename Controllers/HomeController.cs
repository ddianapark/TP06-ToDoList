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

        return View("VerTareas");
    }

    public IActionResult CrearTarea()
    {        
        return View("CrearTarea");
    }

    public IActionResult CrearTareaGuardar(Tarea tarea)
    {        
        BD.CrearTarea(tarea);
        return View("VerTareas");
    }

    public IActionResult EditarTarea()
    {        
        return View("ModificarTarea");
    }

    public IActionResult EditarTareaGuardar(Tarea tarea)
    {        
        BD.ModificarTarea(tarea);
        return View("VerTareas");
    }

    public IActionResult FinalizarTarea(int IdTarea)
    {        
        BD.FinalizarTarea(IdTarea);
        return View("VerTareas");
    }
    public IActionResult EliminarTarea(int IdTarea){

        BD.EliminarTarea(IdTarea);

        return View("VerTareas");
    }
}
