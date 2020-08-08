package net.seymourpoler.tudumanager.domain.todo.update;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import net.seymourpoler.tudumanager.domain.todo.delete.IExistTodoRepository;

import java.util.List;

public class UpdateTodoService implements  IUpdateTodoService{
    private final IExistTodoRepository existTodoRepository;
    public UpdateTodoService(IExistTodoRepository existTodoRepository) {
        this.existTodoRepository = existTodoRepository;
    }

    @Override
    public ServiceExecutionResult update(TodoUpdatingRequest request) {
        if(!existTodoRepository.exist(request.id())){
            var errors = List.of(new net.seymourpoler.tudumanager.domain.Error("email", ErrorCodes.NotFound));
            return ServiceExecutionResult.of(errors);
        }
        throw new RuntimeException();
    }
}
