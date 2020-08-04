package net.seymourpoler.tudumanager.web.api.spring.boot.todo;

import net.seymourpoler.tudumanager.domain.todo.find.IFindTodoService;
import net.seymourpoler.tudumanager.domain.todo.find.models.Todo;
import org.assertj.core.api.AssertionsForClassTypes;
import org.junit.Before;
import org.junit.Test;
import org.springframework.http.HttpStatus;

import java.util.Optional;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class FindTodoControllerShould {

    IFindTodoService findTodoService;
    FindTodoController controller;

    @Before
    public void setUp(){
        findTodoService = mock(IFindTodoService.class);
        controller = new FindTodoController(findTodoService);
    }

    @Test
    public void
    return_not_found_when_is_not_found(){
        var someId = 2;
        when(findTodoService.find(someId)).thenReturn(Optional.ofNullable(null));

        var response = controller.find(someId);

        assertThat(response.getStatusCode()).isEqualTo(HttpStatus.NOT_FOUND);
    }

    @Test
    public void
    return_todo(){
        var someId = 2;
        var todo = new Todo();
        when(findTodoService.find(someId)).thenReturn(Optional.of(todo));

        var response = controller.find(someId);

        assertThat(response.getStatusCode()).isEqualTo(HttpStatus.OK);
        AssertionsForClassTypes.assertThat(response.getBody()).isEqualTo(todo);
    }
}
