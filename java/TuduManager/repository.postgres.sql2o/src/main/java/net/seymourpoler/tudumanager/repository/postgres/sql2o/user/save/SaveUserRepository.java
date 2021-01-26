package net.seymourpoler.tudumanager.repository.postgres.sql2o.user.save;

import net.seymourpoler.tudumanager.domain.user.signUp.ISaveUserRepository;
import net.seymourpoler.tudumanager.domain.user.signUp.Models.User;

public class SaveUserRepository implements ISaveUserRepository {
    @Override
    public void save(User user) {
       throw new RuntimeException();
    }
}
