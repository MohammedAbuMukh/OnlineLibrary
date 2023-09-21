using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContext: DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
               : base(options)
        { }

        public DbSet<Books> Books { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Section>().HasData(
                new Section { SectionId = 1, Name = "History" },
                new Section { SectionId = 2, Name = "Engineering" },
                new Section { SectionId = 3, Name = "Mathmatics" },
                new Section { SectionId = 4, Name = "Medical" },
                new Section { SectionId = 5, Name = "Fantasy" },
                new Section { SectionId = 6, Name = "Physics" }

                );

            modelBuilder.Entity<Books>().HasData(
                new Books
                {
                    BookId = 01,
                    Name = "Art of war",
                    Price = 40,
                    Serial = "0001",
                    SectionId = 1
                },
                new Books
                {
                    BookId = 02,
                    Name = "Basics of engineering",
                    Price = 20,
                    Serial = "0002",
                    SectionId = 2

                },
                new Books
                {
                    BookId = 03,
                    Name = "Physics I",
                    Price = 15,
                    Serial = "0003",
                    SectionId = 6

                },
                new Books
                {
                    BookId = 04,
                    Name = "History of rome",
                    Price = 55,
                    Serial = "0004",
                    SectionId = 1
                },
                new Books
                {
                    BookId = 05,
                    Name = "The song of the cell ",
                    Price = 60,
                    Serial = "0005",
                    SectionId = 4
                },
                new Books
                {
                    BookId = 06,
                    Name = "Harry potter",
                    Price = 80,
                    Serial = "0006",
                    SectionId = 5

                }

            );

            modelBuilder.Entity<User>().HasData(

                new User { Id = 1, 
                           Name= "adam",
                           Password="12345"}




                );

        }



     }
}
