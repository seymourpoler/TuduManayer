package net.seymourpoler.tudumanager.repository.postgres.sql2o.todo;

import net.seymourpoler.tudumanager.domain.todo.delete.IDeleteTodoRepository;
import net.seymourpoler.tudumanager.repository.postgres.sql2o.DataBaseConnectionFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class DeleteTodoRepository implements IDeleteTodoRepository {
    private final DataBaseConnectionFactory dataBaseConnectionFactory;

    @Autowired
    public DeleteTodoRepository(DataBaseConnectionFactory dataBaseConnectionFactory) {
        this.dataBaseConnectionFactory = dataBaseConnectionFactory;
    }

    @Override
    public void delete(Integer todoId) {
        final String sql = "DELETE public.todos WHERE Id = :todoId";
        try (var connection = dataBaseConnectionFactory.create()) {
            connection
                    .createQuery(sql)
                    .addParameter("todoId", todoId)
                    .executeUpdate();
        }
    }
}
