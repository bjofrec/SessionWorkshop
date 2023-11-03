using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    [Route("Juego")]
    public IActionResult Juego(){
        return View("Juego");
    }

    [HttpPost]
    [Route("procesa/juego")]
    public IActionResult ProcesaJuego(string Nombre){
   
        HttpContext.Session.SetString("UserName", Nombre);
        HttpContext.Session.SetInt32("Number", 21);
            
        return RedirectToAction("Juego");
    }

    public IActionResult Cleaner(string Nombre){
        
        HttpContext.Session.Clear();
    

        return RedirectToAction("Index");
    }


    public IActionResult Sumar()
    {
        int num = (Int32) HttpContext.Session.GetInt32("Number");
        int suma = num + 1;
        HttpContext.Session.SetInt32("Number", suma);
        return View("Juego");
    }

    public IActionResult Restar()
    {
        int num = (Int32) HttpContext.Session.GetInt32("Number");
        int resta =num - 1;
        HttpContext.Session.SetInt32("Number", resta);
        return View("Juego");
    }

     public IActionResult Multiplicar()
    {
        int num = (Int32) HttpContext.Session.GetInt32("Number");
        int multiplicacion = num * 2;
        HttpContext.Session.SetInt32("Number", multiplicacion);
        return View("Juego");
    }


    public IActionResult Aleatorio()
    {
        Random rand = new Random();
        int numrand = rand.Next(1,11);
        int num =(Int32) HttpContext.Session.GetInt32("Number");
        int multiplicacion = num * numrand;
        HttpContext.Session.SetInt32("Number", multiplicacion);
        return View("Juego");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
