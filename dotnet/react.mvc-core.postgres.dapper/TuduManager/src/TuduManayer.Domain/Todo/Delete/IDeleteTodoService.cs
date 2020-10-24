namespace TuduManayer.Domain.Todo.Delete
{
    public interface IDeleteTodoService
    {
        ServiceExecutionResult Delete(int todoId);
    }
}