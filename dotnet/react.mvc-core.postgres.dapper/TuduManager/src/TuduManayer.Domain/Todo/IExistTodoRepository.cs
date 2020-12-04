namespace TuduManayer.Domain.Todo
{
    public interface IExistTodoRepository
    {
        bool Exist(int todoId);
    }
}