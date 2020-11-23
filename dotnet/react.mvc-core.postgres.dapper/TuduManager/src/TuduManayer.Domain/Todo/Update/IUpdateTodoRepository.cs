namespace TuduManayer.Domain.Todo.Update
{
    public interface IUpdateTodoRepository
    {
        void Update(Models.Todo todo);
    }
}