using BookstoreApp.Models;

namespace BookstoreApp.DTOs;

public static class BookHeaderExtensions
{
    public static BookHeader ToBookHeader(this Book book) =>
        new(book.Title, book.Authors.ToBookHeaderAuthorNames());

    private static string ToBookHeaderAuthorName(this Person? author) =>
        author is null ? string.Empty
        : author.LastName is null ? author.FirstName
        : $"{author.FirstName} {author.LastName}";

    private static string ToBookHeaderAuthorNames(this IEnumerable<Person> authors) =>
        authors.ToArray() switch
        {
            [] => string.Empty,
            [Person one] => one.ToBookHeaderAuthorName(),
            [..Person[] fore, Person last] => $"{string.Join(", ", fore.Select(a => a.ToBookHeaderAuthorName()))} and {last.ToBookHeaderAuthorName()}",
        };

    public static IEnumerable<BookHeader> ToBookHeaders(this IEnumerable<Book> books) =>
        books.Select(ToBookHeader);
}
