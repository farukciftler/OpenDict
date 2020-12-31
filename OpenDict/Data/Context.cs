using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using OpenDict.Models;
using Microsoft.Extensions.Configuration;


namespace OpenDict.Data
{
    public class Context : DbContext
    {
        public IConfiguration Configuration { get; }


        public Context (DbContextOptions<Context> options, IConfiguration configuration)
            
        {
            Database.EnsureCreated();
            Configuration = configuration;

        }

        public DbSet<OpenDict.Models.LanguageModel> Language { get; set; }
        public DbSet<OpenDict.Models.LocaleStringResourcesModel> LocaleStringResources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=OpenDict;Uid=root;");
        }

    }
}
