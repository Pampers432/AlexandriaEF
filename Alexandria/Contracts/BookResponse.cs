namespace AlexandriaEF.Contracts
{
    public record BookResponse(
        string title,
        DateTime publishedYear,
        string AuthorName
        );
}
