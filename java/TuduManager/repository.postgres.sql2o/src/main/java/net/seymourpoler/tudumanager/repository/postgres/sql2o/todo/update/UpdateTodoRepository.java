package net.seymourpoler.tudumanager.repository.postgres.sql2o.todo.update;

import net.seymourpoler.tudumanager.domain.todo.update.IUpdateTodoRepository;
import net.seymourpoler.tudumanager.domain.todo.update.models.Todo;
import net.seymourpoler.tudumanager.repository.postgres.sql2o.DataBaseConnectionFactory;

public class UpdateTodoRepository implements IUpdateTodoRepository {
    private final DataBaseConnectionFactory dataBaseConnectionFactory;

    public UpdateTodoRepository(DataBaseConnectionFactory dataBaseConnectionFactory) {
        this.dataBaseConnectionFactory = dataBaseConnectionFactory;
    }

    @Override
    public void update(Todo todo) {
        final String sql = "UPDATE public.todos SET title = :title, description = :description, updated_date = :updated_date WHERE id = :id";
        var dbModel = buildFrom(todo);
        try (var connection = dataBaseConnectionFactory.create()) {
            connection
                    .createQuery(sql)
                    .bind(dbModel)
                    .executeUpdate();
        }
    }

    private net.seymourpoler.tudumanager.repository.postgres.sql2o.todo.update.models.Todo buildFrom(net.seymourpoler.tudumanager.domain.todo.update.models.Todo todo) {
        var result = new net.seymourpoler.tudumanager.repository.postgres.sql2o.todo.update.models.Todo();
        result.id = todo.id();
        result.title = todo.title();
        result.description = todo.description;
        result.updated_date = todo.updatedDate();
        return result;
    }
}
