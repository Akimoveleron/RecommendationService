using Microsoft.EntityFrameworkCore;

namespace Recomendation.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet <KitchenGargen> KitchenGargen { get; set; }
        public DbSet<InfoGardering> InfoGardering { get; set;}
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            //Database.EnsureDeleted();

            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }

}

