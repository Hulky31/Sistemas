using MatrixCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace MatrixCrud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<EstacionamentoModel> Estacionamento { get; set; }

    }
   
}
