using Alexandria.Models;

namespace Alexandria.Data
{
    public class DbContext
    {
        public static List<Author> authors = new List<Author> { };

        public static List<Book> books = new List<Book> { };

        public static void Fill()
        {
            var author1 = Author.CreateAuthor("Александр Пушкин", new DateTime(1799, 6, 6));
            var author2 = Author.CreateAuthor("Лев Толстой", new DateTime(1828, 9, 9));
            var author3 = Author.CreateAuthor("Фёдор Достоевский", new DateTime(1821, 11, 11));

            authors = new List<Author> { author1, author2, author3 };

            books.Add(Book.CreateBook("Евгений Онегин", new DateTime(1833, 1, 1), author1.Id));
            books.Add(Book.CreateBook("Капитанская дочка", new DateTime(1836, 1, 1), author1.Id));

            books.Add(Book.CreateBook("Война и мир", new DateTime(1869, 1, 1), author2.Id));
            books.Add(Book.CreateBook("Анна Каренина", new DateTime(1877, 1, 1), author2.Id));

            books.Add(Book.CreateBook("Преступление и наказание", new DateTime(1866, 1, 1), author3.Id));
            books.Add(Book.CreateBook("Братья Карамазовы", new DateTime(1880, 1, 1), author3.Id));
        }
    }
}
