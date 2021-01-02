package net.seymourpoler.tudumanager.domain.user.signUp;

import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import org.springframework.stereotype.Component;

@Component
public class UserSignUpService implements IUserSignUpService {
    @Override
    public ServiceExecutionResult signUp(UserSigningUpArgs args){
            throw new RuntimeException();
        }
}
