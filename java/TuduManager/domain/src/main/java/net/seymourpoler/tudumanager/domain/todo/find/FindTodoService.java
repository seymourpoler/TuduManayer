package net.seymourpoler.tudumanager.domain.todo.find;

import net.seymourpoler.tudumanager.domain.todo.delete.IExistTodoRepository;
import net.seymourpoler.tudumanager.domain.todo.find.models.Todo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.Optional;

@Component
public class FindTodoService implements IFindTodoService{
    private final IExistTodoRepository existTodoRepository;
    private final IFindTodoRepository findTodoRepository;

    @Autowired
    public FindTodoService(
            IExistTodoRepository existTodoRepository,
            IFindTodoRepository findTodoRepository) {
        this.existTodoRepository = existTodoRepository;
        this.findTodoRepository = findTodoRepository;
    }

    @Override
    public Optional<Todo> find(Integer todoId) {
        if(!existTodoRepository.exist(todoId)){
            return Optional.empty();
        }
        var todo = findTodoRepository.find(todoId);
        return Optional.of(todo);
    }
}
