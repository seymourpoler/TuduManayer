package net.seymourpoler.tudumanager.domain.todo.delete;

import net.seymourpoler.tudumanager.domain.Error;
import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;

import java.util.List;

public class DeleteTodoService implements IDeleteTodoService {
    private final IExistTodoRepository existTodoRepository;
    private final IDeleteTodoRepository deleteTodoRepository;

    public DeleteTodoService(
            IExistTodoRepository existTodoRepository,
            IDeleteTodoRepository deleteTodoRepository) {
        this.existTodoRepository = existTodoRepository;
        this.deleteTodoRepository = deleteTodoRepository;
    }

    @Override
    public ServiceExecutionResult delete(Integer todoId) {
        if(existTodoRepository.exist(todoId)) {
            deleteTodoRepository.delete(todoId);
            return ServiceExecutionResult.ok();
        }
        return ServiceExecutionResult.of(
            List.of(new Error("todoId", ErrorCodes.NotFound)));
    }
}
