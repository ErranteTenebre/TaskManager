namespace MyApi.Dtos
{
    public class TaskCreateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime endDate { get; set; }
        public int UserId { get; set; }
    }
}
