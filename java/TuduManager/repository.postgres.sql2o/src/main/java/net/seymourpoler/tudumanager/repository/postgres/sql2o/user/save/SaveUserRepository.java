package net.seymourpoler.tudumanager.repository.postgres.sql2o.user.save;

import net.seymourpoler.tudumanager.domain.user.signUp.ISaveUserRepository;
import net.seymourpoler.tudumanager.domain.user.signUp.Models.User;
import net.seymourpoler.tudumanager.repository.postgres.sql2o.DataBaseConnectionFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class SaveUserRepository implements ISaveUserRepository {

    private final DataBaseConnectionFactory dataBaseConnectionFactory;

    @Autowired
    public SaveUserRepository(DataBaseConnectionFactory dataBaseConnectionFactory) {
        this.dataBaseConnectionFactory = dataBaseConnectionFactory;
    }

    @Override
    public void save(User user) {
        final String sql = "INSERT INTO public.users (email, passord) VALUES (:email, :password, :creation_date)";
        var dbModel = buildFrom(user);
        try (var connection = dataBaseConnectionFactory.create()) {
            connection
                .createQuery(sql)
                .bind(dbModel)
                .executeUpdate();
        }
    }

    private net.seymourpoler.tudumanager.repository.postgres.sql2o.user.save.models.User buildFrom(User user) {
        var result = new net.seymourpoler.tudumanager.repository.postgres.sql2o.user.save.models.User();
        result.email = user.email;
        result.password = user.password;
        result.creation_date = user.creationDate;
        return result;
    }
}
