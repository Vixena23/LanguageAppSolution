using LanguageApp.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace LanguageApp.Api.Data
{
    public class LanguageAppDbContext: DbContext
    {
        public LanguageAppDbContext(DbContextOptions<LanguageAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Category
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Umiem",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                Name = "Uczę się",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 3,
                Name = "Do nauki",
            });

            //Tags
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                Id = 1,
                Name = "test1",
                Color = "red",
                Description = "test tag 1"
            });
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                Id = 2,
                Name = "test2",
                Color = "green",
                Description = "test tag 2"
            });

            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<SentencesTag> SentencesTags { get; set; }
    }
}
