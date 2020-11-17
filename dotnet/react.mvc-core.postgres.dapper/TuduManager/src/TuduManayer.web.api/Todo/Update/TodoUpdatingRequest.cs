namespace TuduManayer.web.api.Todo.Update
{
    public class TodoUpdatingRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}