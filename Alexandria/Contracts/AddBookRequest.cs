namespace AlexandriaEF.Contracts
{
    public record AddBookRequest(
        string title,
        DateTime publishedYear,
        string authorsName);
}
