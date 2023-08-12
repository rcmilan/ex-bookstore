namespace BookstoreApp.Models
{
    public class Book
    {
        public int Id { get; private set; } = 0;
        public string Title { get; private set; } = string.Empty;

        private Book()
        {
            List<BookAuthor> ensureOrdered()
            {

                AuthorsCollection.Sort((a, b) => a.Ordinal.CompareTo(b.Ordinal));
                return AuthorsCollection;
            }

            SortedAuthors = new(ensureOrdered);
        }
        private readonly Lazy<List<BookAuthor>> SortedAuthors;
        private List<BookAuthor> AuthorsCollection = new();
        public IEnumerable<Person> Authors => SortedAuthors.Value.Select(a => a.Person);

        public static Book Create(string title) => new() { Title = title };
        public static Book Create(string title, params Person[] authors)
        {
            var authorsCollection = BookAuthor.CreateMany(Create(title), authors).ToList();

            return new() { Title = title, AuthorsCollection = authorsCollection };
        }

        public bool TryMoveAuthorUp(int ordinal)
        {
            int index = ordinal - 1;
            List<BookAuthor> authors = SortedAuthors.Value;

            if (index < 1 || index >= authors.Count) return false;

            (authors[index - 1], authors[index]) = (authors[index], authors[index - 1]);
            authors[index - 1].Ordinal = index;
            authors[index].Ordinal = index + 1;

            return true;
        }

    }
}
