package net.seymourpoler.tudumanager.domain.user.signUp;

import net.seymourpoler.tudumanager.domain.Error;
import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class UserSignUpService implements IUserSignUpService {
    public static final Integer MaximumNumberOfCharacters = 255;

    @Override
    public ServiceExecutionResult signUp(UserSigningUpArgs args){
        var errors = new ArrayList<Error>();
        if(args.email == null || args.email == "" || args.email.trim().isEmpty()){
            errors.add(new Error("email", ErrorCodes.Required));
        }
        else if(args.email.length() > MaximumNumberOfCharacters){
            errors.add(new Error("email", ErrorCodes.InvalidLength));
        }
        else if(isNotValidFormat(args.email)){
            errors.add(new Error("email", ErrorCodes.InvalidFormat));
        }
        if(args.password == null || args.password == "" || args.password.trim().isEmpty()){
            errors.add(new Error("password", ErrorCodes.Required));
        }
        else if(args.password.length() > MaximumNumberOfCharacters){
            errors.add(new Error("password", ErrorCodes.InvalidLength));
        }
        if(errors.isEmpty()){
            throw new RuntimeException();
        }
        return ServiceExecutionResult.of(errors);
    }

    private Boolean isNotValidFormat(String email){
        final String regex = "^[\\w-_\\.+]*[\\w-_\\.]\\@([\\w]+\\.)+[\\w]+[\\w]$";
        return !email.matches(regex);
    }
}
