namespace TodoApp.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
