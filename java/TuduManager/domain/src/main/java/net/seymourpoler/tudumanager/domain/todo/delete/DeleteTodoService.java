package net.seymourpoler.tudumanager.domain.todo.delete;

import net.seymourpoler.tudumanager.domain.Error;
import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class DeleteTodoService implements IDeleteTodoService {
    private final IExistTodoRepository existTodoRepository;
    private final IDeleteTodoRepository deleteTodoRepository;

    @Autowired
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
