namespace TuduManayer.Domain.Todo.Delete
{
    public interface IExistTodoRepository
    {
        bool Exist(int todoId);
    }
}