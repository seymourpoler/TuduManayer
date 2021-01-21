package net.seymourpoler.tudumanager.domain.user.signUp;

import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;

public interface IUserSignUpService {
    ServiceExecutionResult signUp(UserSigningUpArgs args);
}
