using MVC01.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC01.Controllers
{
    public class Productscontroller : Controller
    {
        public IActionResult index()
        {
             return View();
        }

        [HttpGet]

        public JsonResult GetProducts()
        {
            var products = new List<Product>()
            {
                new Product() { id = 10, name = "Laptop" },
                new Product() { id = 20, name = "Mobile" },
            };

            return Json(products);
        }
        public  IActionResult GetProductById(int id)
        {
            if (id < 0)
                return BadRequest();
            else if (id == 0)
                return RedirectToAction(nameof(Index));
            else if (id < 10)
                return NotFound();
            else
                return Json(new Product() { id = id, name = "Laptop" });
        }

        [HttpGet]
        public IActionResult FileAction()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("wwwroot/Files/Linq.Pdf");
            return File(fileBytes, "application/pdf", "sample.pdf");
        }

        public IActionResult JsonAction()
        {
            return Json("Hello From Json Action");
        }

        [HttpGet("ProductCode/{Code:int}")]
        public IActionResult GetProductByCode(int Code)
        {
            return Json(new Product { id = Code, name = "Product01" });
        }

        [HttpGet]
        public IActionResult Search(ProductsFilter filter)
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetById([FromQuery] int id, [FromQuery(Name = "id2")] int otherId)
        {
            return Json(new { source = "Query", id, otherId });
        }
    }
}
