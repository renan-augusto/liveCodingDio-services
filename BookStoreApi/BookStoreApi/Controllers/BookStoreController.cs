using BookStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        private readonly ToDoContext _context;

        public BookStoreController(ToDoContext context)
        {
            try
            {   
                _context = context;
                _context.toDoProducts.Add(new Product { Id = "1", Name = "Book1", Price = 24.0, Quant = 1, Category = "Acao", Img = "img1" });
                _context.toDoProducts.Add(new Product { Id = "2", Name = "Book2", Price = 30.0, Quant = 3, Category = "Acao", Img = "img2" });
                _context.toDoProducts.Add(new Product { Id = "3", Name = "Book3", Price = 34.0, Quant = 5, Category = "Acao", Img = "img3" });
                _context.toDoProducts.Add(new Product { Id = "4", Name = "Book4", Price = 50.0, Quant = 2, Category = "Acao", Img = "img4" });
                _context.toDoProducts.Add(new Product { Id = "5", Name = "Book5", Price = 60.0, Quant = 10, Category = "Acao", Img = "img5" });

                _context.SaveChanges();
            }
            catch(Exception ex) 
            {
                throw ex;
            } 
            
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.toDoProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id) 
        {
            var item = await _context.toDoProducts.FindAsync(id.ToString());

            if(item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            _context.toDoProducts.Add(product);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);

        }    
    }
}
