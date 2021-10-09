package net.seymourpoler.tudumanager.web.api.spring.boot.user.singUp;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import net.seymourpoler.tudumanager.domain.user.signUp.IUserSignUpService;
import net.seymourpoler.tudumanager.web.api.spring.boot.user.signUp.HttpUserSignUpRequest;
import net.seymourpoler.tudumanager.web.api.spring.boot.user.signUp.UserSignUpController;
import org.junit.Before;
import org.junit.Test;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class UserSignUpControllerShould {

    IUserSignUpService service;
    UserSignUpController controller;

    @Before
    public void setUp(){
        service= mock(IUserSignUpService.class);
        controller = new UserSignUpController(service);
    }

    @Test
    public void return_bad_request_when_there_is_an_error(){
        var errors = List.of(new net.seymourpoler.tudumanager.domain.Error("email", ErrorCodes.Required));
        var errorResult = ServiceExecutionResult.of(errors);
        when(service.signUp(any())).thenReturn(errorResult);
        var request = new HttpUserSignUpRequest();

        var response = controller.signUp(request);

        assertThat(response.getStatusCode()).isEqualTo(HttpStatus.BAD_REQUEST);
        assertThat(response.getBody()).isEqualTo(errors);
    }

    @Test
    public void user_signed_up(){
        var serviceExecutionResult = ServiceExecutionResult.ok();
        when(service.signUp(any())).thenReturn(serviceExecutionResult);
        final String email = "e@mail.com";
        var request = new HttpUserSignUpRequest();
        request.email = email;
        request.password = "password";

        var response = controller.signUp(request);

        assertThat(response.getStatusCode()).isEqualTo(HttpStatus.OK);
        assertThat(getCookieFrom(response)).contains(email);
    }

    private String getCookieFrom(ResponseEntity responseEntity){
        return responseEntity.getHeaders().getFirst(HttpHeaders.SET_COOKIE);
    }
}
