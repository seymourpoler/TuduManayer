package net.seymourpoler.tudumanager.domain.todo.update;

import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;

public interface IUpdateTodoService {
    ServiceExecutionResult update(TodoUpdatingRequest request);
}
