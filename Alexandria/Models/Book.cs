namespace AlexandriaEF.Models
{
    public class Book
    {
        public Book(string title, DateTime publishedYear, Guid authorId)
        {
            Id = Guid.NewGuid();
            Title = title;
            PublishedYear = publishedYear;
            AuthorId = authorId;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishedYear { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; }

        public static Book CreateBook(string title, DateTime publishedYear, Guid authorId)
        {
            if (title == null) throw new ArgumentNullException("Должно быть заполнено поле title"); 
            if (publishedYear > DateTime.UtcNow) throw new Exception("Дата не может превышать текущую");

            return new Book(title, publishedYear, authorId);
        }
    }
}
