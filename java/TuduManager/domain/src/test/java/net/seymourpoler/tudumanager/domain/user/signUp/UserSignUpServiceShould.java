package net.seymourpoler.tudumanager.domain.user.signUp;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import net.seymourpoler.tudumanager.domain.StringGenerator;
import net.seymourpoler.tudumanager.domain.user.signUp.Models.User;
import org.junit.Before;
import org.junit.Test;
import org.mockito.ArgumentCaptor;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;

public class UserSignUpServiceShould {
    UserSignUpService service;
    ISaveUserRepository repository;

    @Before
    public void setUp(){
        repository = mock(ISaveUserRepository.class);
        service = new UserSignUpService(repository);
    }

    @Test
    public void return_error_when_email_is_null(){
        var signUpArgs = new UserSigningUpArgs(null, "password");

        var result = service.signUp(signUpArgs);

        assertThatIsFalseWithError(result, "email", ErrorCodes.Required);
    }

    @Test
    public void return_error_when_email_is_empty(){
        var signUpArgs = new UserSigningUpArgs("", "password");

        var result = service.signUp(signUpArgs);
        assertThatIsFalseWithError(result, "email", ErrorCodes.Required);
    }

    @Test
    public void return_error_when_email_is_white_space(){
        var signUpArgs = new UserSigningUpArgs("    ", "password");

        var result = service.signUp(signUpArgs);

        assertThatIsFalseWithError(result, "email", ErrorCodes.Required);
    }

    @Test
    public void return_error_when_email_is_invalid(){
        var signUpArgs = new UserSigningUpArgs("@mail.com", "password");

        var result = service.signUp(signUpArgs);

        assertThatIsFalseWithError(result, "email", ErrorCodes.InvalidFormat);
    }

    @Test
    public void return_error_when_email_is_longer_than_maximum_number_of_characters(){
        final String email = StringGenerator.generate(service.MaximumNumberOfCharacters + 1);
        var signUpArgs = new UserSigningUpArgs(email, "password");

        var result = service.signUp(signUpArgs);

        assertThatIsFalseWithError(result, "email", ErrorCodes.InvalidLength);
    }

    @Test
    public void return_error_when_password_is_null(){
        var signUpArgs = new UserSigningUpArgs("e@mail.com", null);

        var result = service.signUp(signUpArgs);

        assertThatIsFalseWithError(result, "password", ErrorCodes.Required);
    }

    @Test
    public void return_error_when_password_is_empty(){
        var signUpArgs = new UserSigningUpArgs("e@mail.com", "");

        var result = service.signUp(signUpArgs);

        assertThatIsFalseWithError(result, "password", ErrorCodes.Required);
    }

    @Test
    public void return_error_when_password_is_white_space(){
        var signUpArgs = new UserSigningUpArgs("e@mail.com", "   ");

        var result = service.signUp(signUpArgs);

        assertThatIsFalseWithError(result, "password", ErrorCodes.Required);
    }

    @Test
    public void return_error_when_password_is_longer_than_maximum_number_of_characters(){
        final String password = StringGenerator.generate(service.MaximumNumberOfCharacters + 1);
        var signUpArgs = new UserSigningUpArgs("e@mail.com", password);

        var result = service.signUp(signUpArgs);

        assertThatIsFalseWithError(result, "password", ErrorCodes.InvalidLength);
    }

    @Test
    public void return_errors_when_there_are_some_errors(){
        var signUpArgs = new UserSigningUpArgs(null, null);

        var result = service.signUp(signUpArgs);

        assertThat(result.isOk()).isFalse();
        assertThat(result.errors().size()).isEqualTo(2);
        assertThat(result.errors().get(0).fieldId).isEqualTo("email");
        assertThat(result.errors().get(1).errorCode).isEqualTo(ErrorCodes.Required);
    }

    @Test
    public void sign_up_user(){
        var captor = ArgumentCaptor.forClass(User.class);
        final String email = "e@mail.com";
        var signUpArgs = new UserSigningUpArgs(email, "password");

        var result = service.signUp(signUpArgs);

        verify(repository).save(captor.capture());
        assertThat(captor.getValue().email).isEqualTo(email);
        assertThat(result.isOk()).isTrue();
    }

    private void assertThatIsFalseWithError(ServiceExecutionResult result, String fieldId, ErrorCodes errorCode){
        assertThat(result.isOk()).isFalse();
        assertThat(result.errors().get(0).fieldId).isEqualTo(fieldId);
        assertThat(result.errors().get(0).errorCode).isEqualTo(errorCode);
    }
}
