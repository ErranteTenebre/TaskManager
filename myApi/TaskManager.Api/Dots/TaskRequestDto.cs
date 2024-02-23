namespace TaskManager.Api.Dots;

public record TaskRequestDto(
    string Title,
    string Description,
    DateTime EndDate,
    int UserId,
    int StatusId);