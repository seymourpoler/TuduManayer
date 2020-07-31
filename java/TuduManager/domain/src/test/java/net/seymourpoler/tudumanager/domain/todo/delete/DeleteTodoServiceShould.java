package net.seymourpoler.tudumanager.domain.todo.delete;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import org.assertj.core.api.AssertionsForInterfaceTypes;
import org.junit.Before;
import org.junit.Test;

import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class DeleteTodoServiceShould {

    private IDeleteTodoService service;
    private IExistTodoRepository existTodoRepository;

    @Before
    public void setUp(){
        existTodoRepository = mock(IExistTodoRepository.class);
        service = new DeleteTodoService(existTodoRepository);
    }

    @Test
    public void
    return_error_when_is_not_found(){
        final Integer todoId = 3;
        when(existTodoRepository.exist(todoId)).thenReturn(false);

        var result = service.delete(todoId);

        AssertionsForInterfaceTypes
            .assertThat(result.errors().get(0).errorCode)
            .isEqualTo(ErrorCodes.NotFound);
    }
}
