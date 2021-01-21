package net.seymourpoler.tudumanager.domain.user.signUp;

import net.seymourpoler.tudumanager.domain.user.signUp.Models.User;

public interface ISaveUserRepository {
    void save(User user);
}
