using Asm1_WebMVC_vinhttph19362.DatabaseContext;
using Asm1_WebMVC_vinhttph19362.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asm1_WebMVC_vinhttph19362.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbContextAsm dbContextAsm;

        public ProductController(DbContextAsm dbContextAsm)
        {
            this.dbContextAsm = dbContextAsm;
        }

        //public async Task <IActionResult> Index()
        //{
        //    var product = await dbContextAsm.Products.ToListAsync();
        //    return View(product);
        //}
        public async Task<IActionResult> Index()
        {
            var products = await dbContextAsm.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var products = new Product()
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                CreatedAt = product.CreatedAt,
                Brand = product.Brand,
                Size = product.Size,
                ImageUrl = product.ImageUrl,
                Status = product.Status,
            };
            await dbContextAsm.Products.AddAsync(product);
            await dbContextAsm.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var product = await dbContextAsm.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                var viewmodel = new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    CreatedAt = product.CreatedAt,
                    Brand = product.Brand,
                    Size = product.Size,
                    ImageUrl = product.ImageUrl,
                    Status = product.Status,
                };

                // Trả về viewmodel nếu sản phẩm được tìm thấy
                return await Task.Run(() => View("View", viewmodel));
            }

            // Nếu sản phẩm không được tìm thấy, chuyển hướng đến action Index
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(Product update)
        {
            var products = await dbContextAsm.Products.FindAsync(update.Id);
            if (products != null)
            {

                products.Id = update.Id;
                products.Name = update.Name;
                products.Description = update.Description;
                products.Price = update.Price;
                products.Quantity = update.Quantity;
                products.CreatedAt = update.CreatedAt;
                products.Brand = update.Brand;
                products.Size = update.Size;
                products.ImageUrl = update.ImageUrl;
                products.Status = update.Status;
                await dbContextAsm.SaveChangesAsync();
               
                return RedirectToAction("Index");


            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Product delete)
        {
            var products = await dbContextAsm.Products.FindAsync(delete.Id);
            if (products != null)
            {
                dbContextAsm.Products.Remove(products);
               await dbContextAsm.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
       
        
    }
}
