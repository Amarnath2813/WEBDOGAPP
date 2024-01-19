using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace EXAMAPPLICATION.Models
{
    public class Appdbcontext: DbContext
    {
        public Appdbcontext()
        { }
        public Appdbcontext(DbContextOptions<Appdbcontext> options)
              : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=MYDB;Integrated Security=True;");
            }
        }
        public DbSet<DOG> DOGs { get; set; }
        public DbSet<BuyerInfo> BuyerInfos { get; set; }
    }
}

