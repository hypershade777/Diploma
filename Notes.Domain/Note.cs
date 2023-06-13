namespace Notes.Domain
{
    public class Note
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
    }
}
