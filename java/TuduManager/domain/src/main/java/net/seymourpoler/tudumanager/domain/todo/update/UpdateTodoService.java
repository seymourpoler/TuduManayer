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
            var errors = List.of(new net.seymourpoler.tudumanager.domain.Error("id", ErrorCodes.NotFound));
            return ServiceExecutionResult.of(errors);
        }
        if(request.title() == null || request.title().trim().equals("")){
            var errors = List.of(new net.seymourpoler.tudumanager.domain.Error("title", ErrorCodes.Required));
            return ServiceExecutionResult.of(errors);
        }
        final Integer maximumNumberOfCharacters = 250;
        if(request.title().length() > maximumNumberOfCharacters){
            var errors = List.of(new net.seymourpoler.tudumanager.domain.Error("title", ErrorCodes.InvalidLength));
            return ServiceExecutionResult.of(errors);
        }
        throw new RuntimeException();
    }
}
