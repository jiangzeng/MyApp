using Microsoft.EntityFrameworkCore;
using MyApp.DataModels;

namespace MyApp.DataModel
{
    public class MyAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=MyApp.db");
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=MyApp;User id = ****; password = ****;");
        }
    }



}