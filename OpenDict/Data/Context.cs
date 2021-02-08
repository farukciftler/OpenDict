using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;

namespace OpenDict.Data
{
    public class Context : DbContext
    {

        private readonly string _connectionString;

        public Context (DbContextOptions<Context> options )
            
        {
            Database.EnsureCreated();
        }

        public DbSet<OpenDict.Models.LanguageModel> Language { get; set; }
        public DbSet<OpenDict.Models.LocaleStringResourcesModel> LocaleStringResources { get; set; }
        public DbSet<OpenDict.Models.UserModel> Users { get; set; }
        public DbSet<OpenDict.Models.UserGroupModel> UserGroup { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySQL(connectionString);
        }

    }
}
