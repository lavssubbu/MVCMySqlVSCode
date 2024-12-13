using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CMSMVCApp.Models;

namespace CMSMVCApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public ViewResult Index()
    {
        //Pass data from controller to view page
        ViewBag.Message = "Welcome to Day1 of Dotnet Core"; //Dynamic Object for passing data
        ViewData["Today"]=DateTime.Now.ToShortDateString();//Dictionary like object
       
       //Tempdata - pass data to the next request
       TempData["Name"]="CMS";
        return View();
    }

    public IActionResult Privacy()
    {
       string cliname = TempData["Name"] as string;
        ViewBag.RetrievedName = $"Hi, {cliname}";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
