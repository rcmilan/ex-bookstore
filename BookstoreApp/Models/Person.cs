namespace BookstoreApp.Models
{
    public class Person
    {
        public int Id { get; private set; } = 0;

        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;

        private Person() { }

        public static Person Create(string firstName) => new() { FirstName = firstName };
        public static Person Create(string firstName, string lastName) => new() { FirstName = firstName, LastName = lastName };
    }
}
