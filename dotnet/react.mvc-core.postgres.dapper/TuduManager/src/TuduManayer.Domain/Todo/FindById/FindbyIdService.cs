using System.Collections.Generic;

namespace TuduManayer.Domain.Todo.FindById
{
    
    public interface IFindByTodoIdService
    {
        ServiceExecutionResultWithModel<Models.Todo> Find(int id);
    }
}