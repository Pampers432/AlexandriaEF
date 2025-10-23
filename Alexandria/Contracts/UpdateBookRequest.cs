namespace AlexandriaEF.Contracts
{
    public record UpdateBookRequest(
        Guid id, 
        string newTitle, 
        DateTime newPublishDate);
}
