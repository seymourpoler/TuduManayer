package net.seymourpoler.tudumanager.domain.todo.find;

import net.seymourpoler.tudumanager.domain.todo.find.models.Todo;

import java.util.Optional;

public interface IFindTodoRepository {
    Optional<Todo> find(Integer todoId);
}
