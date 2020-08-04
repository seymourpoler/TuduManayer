package net.seymourpoler.tudumanager.repository.postgres.sql2o.todo.find;

import net.seymourpoler.tudumanager.domain.todo.find.IFindTodoRepository;
import net.seymourpoler.tudumanager.domain.todo.find.models.Todo;
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
        final String sql = "select id, title, description from public.todos where id = :id";

        try(var connection = dataBaseConnectionFactory.create()) {
            return connection
                    .createQuery(sql)
                    .addParameter("id", todoId)
                    .executeAndFetchFirst(net.seymourpoler.tudumanager.domain.todo.find.models.Todo.class);
        }
    }
}
