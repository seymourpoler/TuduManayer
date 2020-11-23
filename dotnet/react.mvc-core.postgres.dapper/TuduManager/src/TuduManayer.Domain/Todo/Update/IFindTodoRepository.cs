namespace TuduManayer.Domain.Todo.Update
{
    public interface IFindTodoRepository
    {
        Update.Models.Todo FindById(int todoId);
    }
}