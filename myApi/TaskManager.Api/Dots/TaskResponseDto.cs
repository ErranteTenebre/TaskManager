namespace TaskManager.Api.Dots
{
    public record TaskResponseDto(
        string Title,
        string Description,
        DateTime EndDate,
        int UserId,
        int StatusId);
}
