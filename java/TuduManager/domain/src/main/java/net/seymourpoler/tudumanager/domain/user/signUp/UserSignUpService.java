package net.seymourpoler.tudumanager.domain.user.signUp;

import net.seymourpoler.tudumanager.domain.Error;
import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class UserSignUpService implements IUserSignUpService {
    public static final Integer MaximumNumberOfCharactersForEmail = 255;

    @Override
    public ServiceExecutionResult signUp(UserSigningUpArgs args){
        if(args.email == null || args.email == "" | args.email.trim().isEmpty()){
            return ServiceExecutionResult.of(
                List.of(new Error("email", ErrorCodes.Required)));
        }
        if(args.email.length() > MaximumNumberOfCharactersForEmail){
            return ServiceExecutionResult.of(
                    List.of(new Error("email", ErrorCodes.InvalidLength)));
        }
        if(isNotValidFormat(args.email)){
            return ServiceExecutionResult.of(
                    List.of(new Error("email", ErrorCodes.InvalidFormat)));
        }

        throw new RuntimeException();
    }

    private Boolean isNotValidFormat(String email){
        final String regex = "^[\\w-_\\.+]*[\\w-_\\.]\\@([\\w]+\\.)+[\\w]+[\\w]$";
        return !email.matches(regex);
    }
}
