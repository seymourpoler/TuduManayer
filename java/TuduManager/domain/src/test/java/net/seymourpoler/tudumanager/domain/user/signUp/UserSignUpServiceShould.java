package net.seymourpoler.tudumanager.domain.user.signUp;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import net.seymourpoler.tudumanager.domain.StringGenerator;
import org.junit.Before;
import org.junit.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class UserSignUpServiceShould {
    UserSignUpService service;

    @Before
    public void setUp(){
        service = new UserSignUpService();
    }

    @Test
    public void return_error_when_email_is_null(){
        var signUpArgs = new UserSigningUpArgs(null, "password");

        var result = service.signUp(signUpArgs);

        assertThatIsFalse(result, "email", ErrorCodes.Required);
    }

    @Test
    public void return_error_when_email_is_string_empty(){
        var signUpArgs = new UserSigningUpArgs("", "password");

        var result = service.signUp(signUpArgs);
        assertThatIsFalse(result, "email", ErrorCodes.Required);
    }

    @Test
    public void return_error_when_email_is_white_space(){
        var signUpArgs = new UserSigningUpArgs("    ", "password");

        var result = service.signUp(signUpArgs);

        assertThatIsFalse(result, "email", ErrorCodes.Required);
    }

    @Test
    public void return_error_when_email_is_invalid(){
        var signUpArgs = new UserSigningUpArgs("@mail.com", "password");

        var result = service.signUp(signUpArgs);

        assertThatIsFalse(result, "email", ErrorCodes.InvalidFormat);
    }

    @Test
    public void return_error_when_email_is_longer_than_maximum_number_of_characters(){
        final String email = StringGenerator.generate(service.MaximumNumberOfCharactersForEmail + 1);
        var signUpArgs = new UserSigningUpArgs(email, "password");

        var result = service.signUp(signUpArgs);

        assertThatIsFalse(result, "email", ErrorCodes.InvalidLength);
    }


    private void assertThatIsFalse(ServiceExecutionResult result, String fieldlId, ErrorCodes errorCode){
        assertThat(result.isOk()).isFalse();
        assertThat(result.errors().get(0).fieldId).isEqualTo(fieldlId);
        assertThat(result.errors().get(0).errorCode).isEqualTo(errorCode);
    }

}
