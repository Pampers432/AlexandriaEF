using Alexandria.Models;
using Microsoft.EntityFrameworkCore;

namespace Alexandria.Data
{
    public class AlexandriaDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public AlexandriaDbContext(DbContextOptions<AlexandriaDbContext> options) : base(options)
        {
        }

        public static void Fill(AlexandriaDbContext context)
        {
            var author1 = Author.CreateAuthor("Александр Пушкин", new DateTime(1799, 6, 6));
            var author2 = Author.CreateAuthor("Лев Толстой", new DateTime(1828, 9, 9));
            var author3 = Author.CreateAuthor("Фёдор Достоевский", new DateTime(1821, 11, 11));

            context.Authors.AddRange(author1, author2, author3);

            context.Books.AddRange(
                Book.CreateBook("Евгений Онегин", new DateTime(1833, 1, 1), author1.Id),
                Book.CreateBook("Капитанская дочка", new DateTime(1836, 1, 1), author1.Id),

                Book.CreateBook("Война и мир", new DateTime(1869, 1, 1), author2.Id),
                Book.CreateBook("Анна Каренина", new DateTime(1877, 1, 1), author2.Id),

                Book.CreateBook("Преступление и наказание", new DateTime(1866, 1, 1), author3.Id),
                Book.CreateBook("Братья Карамазовы", new DateTime(1880, 1, 1), author3.Id)
            );

            context.SaveChanges();
        }

    }
}
