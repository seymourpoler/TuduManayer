package net.seymourpoler.tudumanager.domain.todo.update;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.todo.delete.IExistTodoRepository;
import org.junit.Before;
import org.junit.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class UpdateTodoServiceShould {

    IExistTodoRepository existTodoRepository;
    IUpdateTodoService updateTodoService;

    @Before
    public void setUp(){
        existTodoRepository = mock(IExistTodoRepository.class);
        updateTodoService = new UpdateTodoService(existTodoRepository);
    }

    @Test
    public void
    return_error_when_is_not_found(){
        final Integer someId = 3;
        when(existTodoRepository.exist(someId)).thenReturn(false);
        var request = new TodoUpdatingRequest(someId, "title", "description");

        var result = updateTodoService.update(request);

        assertThat(result.isOk()).isFalse();
        assertThat(result.errors().stream().findFirst().get().errorCode).isEqualTo(ErrorCodes.NotFound);
    }

    @Test
    public void
    return_error_when_title_is_null(){
        final Integer someId = 3;
        when(existTodoRepository.exist(someId)).thenReturn(true);
        var request = new TodoUpdatingRequest(someId, null, "description");

        var result = updateTodoService.update(request);

        assertThat(result.isOk()).isFalse();
        assertThat(result.errors().stream().findFirst().get().errorCode).isEqualTo(ErrorCodes.Required);
        assertThat(result.errors().stream().findFirst().get().fieldId).isEqualTo("title");
    }

    @Test
    public void
    return_error_when_title_is_string_empty(){
        final Integer someId = 3;
        when(existTodoRepository.exist(someId)).thenReturn(true);
        var request = new TodoUpdatingRequest(someId, "", "description");

        var result = updateTodoService.update(request);

        assertThat(result.isOk()).isFalse();
        assertThat(result.errors().stream().findFirst().get().errorCode).isEqualTo(ErrorCodes.Required);
        assertThat(result.errors().stream().findFirst().get().fieldId).isEqualTo("title");
    }

    @Test
    public void
    return_error_when_title_is_white_space(){
        final Integer someId = 3;
        when(existTodoRepository.exist(someId)).thenReturn(true);
        var request = new TodoUpdatingRequest(someId, "    ", "description");

        var result = updateTodoService.update(request);

        assertThat(result.isOk()).isFalse();
        assertThat(result.errors().stream().findFirst().get().errorCode).isEqualTo(ErrorCodes.Required);
        assertThat(result.errors().stream().findFirst().get().fieldId).isEqualTo("title");
    }

    @Test
    public void
    return_error_when_title_has_invalid_characters_length(){
        final Integer someId = 3;
        when(existTodoRepository.exist(someId)).thenReturn(true);
        var request = new TodoUpdatingRequest(someId, generateStringWithRandomCharacters(500), "description");

        var result = updateTodoService.update(request);

        assertThat(result.isOk()).isFalse();
        assertThat(result.errors().stream().findFirst().get().errorCode).isEqualTo(ErrorCodes.InvalidLength);
        assertThat(result.errors().stream().findFirst().get().fieldId).isEqualTo("title");
    }

    private String generateStringWithRandomCharacters(Integer numberOfCharacters){
        var result = new StringBuilder();
        for (var position=0; position<numberOfCharacters; position++){
            result.append("q");
        }
        return result.toString();
    }
}
