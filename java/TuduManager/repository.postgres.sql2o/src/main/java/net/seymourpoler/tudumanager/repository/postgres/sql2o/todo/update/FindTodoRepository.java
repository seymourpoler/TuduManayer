package net.seymourpoler.tudumanager.repository.postgres.sql2o.todo.update;

import net.seymourpoler.tudumanager.domain.todo.update.IFindTodoRepository;
import net.seymourpoler.tudumanager.domain.todo.update.models.Todo;
import net.seymourpoler.tudumanager.repository.postgres.sql2o.DataBaseConnectionFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class FindTodoRepository implements IFindTodoRepository {
    private final DataBaseConnectionFactory dataBaseConnectionFactory;

    @Autowired
    public FindTodoRepository(DataBaseConnectionFactory dataBaseConnectionFactory) {
        this.dataBaseConnectionFactory = dataBaseConnectionFactory;
    }

    @Override
    public Todo find(Integer todoId) {
        final String sql = "select id, title, description, updated_date from public.todos where id = :id";

        try(var connection = dataBaseConnectionFactory.create()) {
            var todo = connection
                    .createQuery(sql)
                    .addParameter("id", todoId)
                    .executeAndFetchFirst(net.seymourpoler.tudumanager.repository.postgres.sql2o.todo.update.models.Todo.class);
            return new Todo(todo.id, todo.title, todo.description, todo.updated_date);
        }
    }
}
