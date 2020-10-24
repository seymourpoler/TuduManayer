namespace TuduManayer.Domain.Todo.Delete
{
    public interface IDeleteTodoRepository
    {
        void Delete(int todoId);
    }
}