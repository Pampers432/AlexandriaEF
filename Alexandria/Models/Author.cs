namespace AlexandriaEF.Models
{
    public class Author
    {
        public Author() { }

        private Author(string name, DateTime dateOfBirth)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Book> Books { get; } = new();

        public static Author CreateAuthor(string name, DateTime dateOfBirth)
        {
            if (name == null) throw new ArgumentNullException("Поле Name должно быть заполнено");
            if (dateOfBirth > DateTime.UtcNow) throw new Exception("Дата не может превышать текущую");

            return new Author(name, dateOfBirth);
        }
    }
}
