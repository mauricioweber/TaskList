using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Models;

namespace TaskList.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
    }
}