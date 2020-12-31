using Microsoft.EntityFrameworkCore;


namespace OpenDict.Data
{
    public class Context : DbContext
    {


        public Context (DbContextOptions<Context> options)
            
        {
            Database.EnsureCreated();

        }

        public DbSet<OpenDict.Models.LanguageModel> Language { get; set; }
        public DbSet<OpenDict.Models.LocaleStringResourcesModel> LocaleStringResources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=OpenDict;Uid=root;");
        }

    }
}
