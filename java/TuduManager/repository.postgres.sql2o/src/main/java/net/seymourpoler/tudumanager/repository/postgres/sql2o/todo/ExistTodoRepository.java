package net.seymourpoler.tudumanager.repository.postgres.sql2o.todo;

import net.seymourpoler.tudumanager.domain.todo.delete.IExistTodoRepository;
import net.seymourpoler.tudumanager.repository.postgres.sql2o.DataBaseConnectionFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class ExistTodoRepository implements IExistTodoRepository {
    private final DataBaseConnectionFactory dataBaseConnectionFactory;

    @Autowired
    public ExistTodoRepository(DataBaseConnectionFactory dataBaseConnectionFactory) {
        this.dataBaseConnectionFactory = dataBaseConnectionFactory;
    }

    @Override
    public Boolean exist(Integer todoId) {
        final String sql = "SELECT COUNT(1) public.todos WHERE Id = :todoId";

        try (var connection = dataBaseConnectionFactory.create()) {
            var scalar = connection
                    .createQuery(sql)
                    .addParameter("todoId", todoId)
                    .executeScalar();
            return ((scalar != null) && ((Integer)scalar > 0));
        }
    }
}
