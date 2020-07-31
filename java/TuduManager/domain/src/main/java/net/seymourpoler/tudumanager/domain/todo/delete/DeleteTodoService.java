package net.seymourpoler.tudumanager.domain.todo.delete;

import net.seymourpoler.tudumanager.domain.Error;
import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;

import java.util.List;

public class DeleteTodoService implements IDeleteTodoService {
    private final IExistTodoRepository existTodoRepository;

    public DeleteTodoService(IExistTodoRepository existTodoRepository) {
        this.existTodoRepository = existTodoRepository;
    }

    @Override
    public ServiceExecutionResult delete(Integer todoId) {
        if(existTodoRepository.exist(todoId)) {
            throw new RuntimeException();
        }
        return ServiceExecutionResult.of(
            List.of(new Error("todoId", ErrorCodes.NotFound)));
    }
}
