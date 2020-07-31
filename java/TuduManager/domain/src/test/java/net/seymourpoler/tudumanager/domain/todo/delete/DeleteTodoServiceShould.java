package net.seymourpoler.tudumanager.domain.todo.delete;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import org.assertj.core.api.AssertionsForClassTypes;
import org.junit.Before;
import org.junit.Test;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;
import static org.mockito.Mockito.*;

public class DeleteTodoServiceShould {

    private IDeleteTodoService service;
    private IExistTodoRepository existTodoRepository;
    private IDeleteTodoRepository deleteTodoRepository;

    @Before
    public void setUp(){
        existTodoRepository = mock(IExistTodoRepository.class);
        deleteTodoRepository = mock(IDeleteTodoRepository.class);
        service = new DeleteTodoService(existTodoRepository, deleteTodoRepository);
    }

    @Test
    public void
    return_error_when_is_not_found(){
        final Integer todoId = 3;
        when(existTodoRepository.exist(todoId)).thenReturn(false);

        var result = service.delete(todoId);

        AssertionsForClassTypes.assertThat(result.errors().get(0).errorCode)
            .isEqualTo(ErrorCodes.NotFound);
    }

    @Test
    public void
    delete_todo(){
        final Integer todoId = 3;
        when(existTodoRepository.exist(todoId)).thenReturn(true);

        var result = service.delete(todoId);

        assertThat(result.isOk()).isTrue();
        verify(deleteTodoRepository).delete(todoId);
    }
}
