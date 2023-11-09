using Microsoft.EntityFrameworkCore;
using Teste_DVP.entities;

namespace Teste_DVP.Data
{
    public class DataContext : DbContext
    {
 public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
       
        public DbSet<Users> Users { get; set; }

        public DbSet<Persons> Persons { get; set; }


    }
}
