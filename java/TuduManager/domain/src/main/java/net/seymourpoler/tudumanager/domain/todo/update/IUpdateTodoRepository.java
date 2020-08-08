package net.seymourpoler.tudumanager.domain.todo.update;

import net.seymourpoler.tudumanager.domain.todo.update.models.Todo;

public interface IUpdateTodoRepository {
    void update(Todo todo);
}
