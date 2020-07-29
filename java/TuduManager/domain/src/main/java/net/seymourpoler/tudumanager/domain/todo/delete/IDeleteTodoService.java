package net.seymourpoler.tudumanager.domain.todo.delete;

import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;

public interface IDeleteTodoService {
    ServiceExecutionResult delete(Integer todoId);
}
