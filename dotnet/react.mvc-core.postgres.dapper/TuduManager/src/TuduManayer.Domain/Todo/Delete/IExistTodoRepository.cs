namespace TuduManayer.Domain.Test.Todo.Delete
{
    internal interface IExistTodoRepository
    {
        bool Exist(int todoId);
    }
}