namespace AlexandriaEF.Contracts
{
    public record AuthorResponse(
        string Name, 
        DateTime DateOfBirth, 
        List<string> BookTitles
        );
}
