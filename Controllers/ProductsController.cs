using CMSMVCApp.DataAccess;
using CMSMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMSMVCApp.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
       ProductDataAccess proda = new ProductDataAccess();
       IEnumerable<Product> lstpro = proda.DisplayAll();
        return View(lstpro);
    }
     public IActionResult Details(int id)
    {
       ProductDataAccess proda = new ProductDataAccess();
       Product pro = proda.GetById(id);
       return View(pro);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Product pro)
    {
       ProductDataAccess proda = new ProductDataAccess();
       proda.AddProd(pro);
       return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        ProductDataAccess proda = new ProductDataAccess();
       Product pro = proda.GetById(id);
       return View(pro);
    }
    [HttpPost]
    public IActionResult Edit(Product pro)
    {
       ProductDataAccess proda = new ProductDataAccess();
       proda.UpdateProd(pro);
       return RedirectToAction("Index");
    }
    
}