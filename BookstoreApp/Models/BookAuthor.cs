namespace BookstoreApp.Models
{
    public class BookAuthor
    {
        public int Ordinal { get; set; } = 0;
        public Person Person { get; private set; } = null!;
        public Book Book { get; private set; } = null!;

        public static IEnumerable<BookAuthor> CreateMany(Book book, IEnumerable<Person> authors) =>
            authors.Select((person, i) => new BookAuthor
            {
                Book = book,
                Ordinal = i + 1,
                Person = person
            });
    }
}
