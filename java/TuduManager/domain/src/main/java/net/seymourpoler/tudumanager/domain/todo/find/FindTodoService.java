package net.seymourpoler.tudumanager.domain.todo.find;

import net.seymourpoler.tudumanager.domain.todo.delete.IExistTodoRepository;
import net.seymourpoler.tudumanager.domain.todo.find.models.Todo;

import java.util.Optional;

public class FindTodoService implements IFindTodoService{
    private final IExistTodoRepository existTodoRepository;
    private final IFindTodoRepository findTodoRepository;

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
