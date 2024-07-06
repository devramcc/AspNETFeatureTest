using AspNETFeatureTest.Models;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Product1", Price = 10.0M },
        new Product { Id = 2, Name = "Product2", Price = 20.0M },
        new Product { Id = 3, Name = "Product1", Price = 10.0M },
        new Product { Id = 4, Name = "Product2", Price = 20.0M },
    };

    public ActionResult Index()
    {
        return View(products);
    }

    [HttpPost]
    public JsonResult UpdateProduct(int id, string name, decimal price)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            product.Name = name;
            product.Price = price;
            return Json(new { success = true });
        }
        return Json(new { success = false });
    }

    [HttpPost]
    public JsonResult DeleteProduct(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            products.Remove(product);
            return Json(new { success = true });
        }
        return Json(new { success = false });
    }

    [HttpPost]
    public JsonResult AddProduct(string name, decimal price)
    {
        int newId = products.Max(p => p.Id) + 1;
        var newProduct = new Product { Id = newId, Name = name, Price = price };
        products.Add(newProduct);
        return Json(new { success = true, product = newProduct });
    }
}
