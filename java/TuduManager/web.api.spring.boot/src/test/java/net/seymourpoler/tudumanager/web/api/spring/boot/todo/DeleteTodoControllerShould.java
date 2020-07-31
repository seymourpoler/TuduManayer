package net.seymourpoler.tudumanager.web.api.spring.boot.todo;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import net.seymourpoler.tudumanager.domain.todo.delete.IDeleteTodoService;
import org.junit.Before;
import org.junit.Test;
import org.springframework.http.HttpStatus;

import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class DeleteTodoControllerShould {

    private IDeleteTodoService service;
    private DeleteTodoController controller;

    @Before
    public void setUp(){
        service = mock(IDeleteTodoService.class);
        controller = new DeleteTodoController(service);
    }

    @Test
    public void return_not_found_when_todo_is_not_found(){
        var errors = List.of(new net.seymourpoler.tudumanager.domain.Error("id", ErrorCodes.NotFound));
        var errorResult = ServiceExecutionResult.of(errors);
        final Integer someId = 23;
        when(service.delete(someId)).thenReturn(errorResult);

        var response = controller.delete(someId);

        assertThat(response.getStatusCode()).isEqualTo(HttpStatus.NOT_FOUND);
    }

    @Test
    public void return_ok_when_todo_is_deleted(){
        var executionResult = ServiceExecutionResult.ok();
        final Integer someId = 23;
        when(service.delete(someId)).thenReturn(executionResult);

        var response = controller.delete(someId);

        assertThat(response.getStatusCode()).isEqualTo(HttpStatus.OK);
    }
}
