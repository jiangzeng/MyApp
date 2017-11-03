using Microsoft.EntityFrameworkCore;
using MyApp.DataModels;
using MyApp.Utils;

namespace MyApp.DataModel
{
    public class MyAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string DataSource = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=MyApp;User id = " + MyCredentials.DBUserName + "; password = " + MyCredentials.DBPasswword + ";";
            //string DataSource = "Data Source=MyApp.db"
            optionsBuilder.UseSqlServer(DataSource);
        }
    }



}