namespace TuduManayer.Domain.Todo.FindById
{
    public interface IFindByTodoIdRepository
    {
        Models.Todo Find(int id);
    }
}