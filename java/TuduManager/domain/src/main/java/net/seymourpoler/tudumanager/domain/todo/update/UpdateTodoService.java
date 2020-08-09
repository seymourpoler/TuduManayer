package net.seymourpoler.tudumanager.domain.todo.update;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import net.seymourpoler.tudumanager.domain.todo.delete.IExistTodoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class UpdateTodoService implements  IUpdateTodoService{
    private final IExistTodoRepository existTodoRepository;
    private final IFindTodoByIdRepository findTodoRepository;
    private final IUpdateTodoRepository updateTodoRepository;

    @Autowired
    public UpdateTodoService(
            IExistTodoRepository existTodoRepository,
            IFindTodoByIdRepository findTodoRepository,
            IUpdateTodoRepository updateTodoRepository) {
        this.existTodoRepository = existTodoRepository;
        this.findTodoRepository = findTodoRepository;
        this.updateTodoRepository = updateTodoRepository;
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

        var todo = findTodoRepository.find(request.id());
        todo.update(request.title(), request.description());
        updateTodoRepository.update(todo);

        return ServiceExecutionResult.ok();
    }
}
