package net.seymourpoler.tudumanager.web.api.spring.boot.todo.update;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import net.seymourpoler.tudumanager.domain.todo.update.IUpdateTodoService;
import net.seymourpoler.tudumanager.domain.todo.update.TodoUpdatingRequest;
import org.junit.Before;
import org.junit.Test;
import org.springframework.http.HttpStatus;

import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class UpdateTodoControllerShould {
    IUpdateTodoService updateTodoService;
    UpdateTodoController controller;

    @Before
    public void setUp(){
        updateTodoService = mock(IUpdateTodoService.class);
        controller = new UpdateTodoController(updateTodoService);
    }

    @Test
    public void
    return_not_found_when_is_not_found(){
        var request = new HttpTodoUpdatingRequest();
        var errors = List.of(new net.seymourpoler.tudumanager.domain.Error("email", ErrorCodes.NotFound));
        var errorResult = ServiceExecutionResult.of(errors);
        when(updateTodoService.update(any())).thenReturn(errorResult);

        var response = controller.update(request);

        assertThat(response.getStatusCode()).isEqualTo(HttpStatus.NOT_FOUND);
    }

    @Test
    public void
    return_bad_request_when_there_is_an_error(){
        var request = new HttpTodoUpdatingRequest();
        var errors = List.of(new net.seymourpoler.tudumanager.domain.Error("email", ErrorCodes.Required));
        var errorResult = ServiceExecutionResult.of(errors);
        when(updateTodoService.update(any())).thenReturn(errorResult);

        var response = controller.update(request);

        assertThat(response.getStatusCode()).isEqualTo(HttpStatus.BAD_REQUEST);
        assertThat(response.getBody()).isEqualTo(errors);
    }
}
