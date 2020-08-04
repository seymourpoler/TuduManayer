package net.seymourpoler.tudumanager.domain.todo.find;

import net.seymourpoler.tudumanager.domain.todo.find.models.Todo;

public interface IFindTodoRepository {
    Todo find(Integer todoId);
}
