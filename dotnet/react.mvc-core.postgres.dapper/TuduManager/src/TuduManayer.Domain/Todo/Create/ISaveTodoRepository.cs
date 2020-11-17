namespace TuduManayer.Domain.Todo.Create
{
    public  interface ISaveTodoRepository
    {
        void Save(Models.Todo todo);
    }
}