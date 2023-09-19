using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> option) : base(option) 
        {
        }

        public DbSet<Product> toDoProducts { get; set; }

    }
}
