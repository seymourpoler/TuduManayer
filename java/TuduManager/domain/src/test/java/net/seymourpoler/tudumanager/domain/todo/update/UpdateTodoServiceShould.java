package net.seymourpoler.tudumanager.domain.todo.update;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.todo.delete.IExistTodoRepository;
import net.seymourpoler.tudumanager.domain.todo.update.models.Todo;
import org.junit.Before;
import org.junit.Test;
import org.mockito.ArgumentCaptor;

import java.util.Random;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.*;

public class UpdateTodoServiceShould {

    IExistTodoRepository existTodoRepository;
    IFindTodoRepository findTodoRepository;
    IUpdateTodoRepository updateTodoRepository;
    IUpdateTodoService updateTodoService;

    @Before
    public void setUp(){
        existTodoRepository = mock(IExistTodoRepository.class);
        findTodoRepository = mock(IFindTodoRepository.class);
        updateTodoRepository = mock(IUpdateTodoRepository.class);
        updateTodoService = new UpdateTodoService(existTodoRepository, findTodoRepository, updateTodoRepository);
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
        final int letter_a = 97;
        final int letter_z = 122;
        Random random = new Random();
        StringBuilder buffer = new StringBuilder(numberOfCharacters);
        for (int i = 0; i < numberOfCharacters; i++) {
            int randomLimitedInt = letter_a + (int)(random.nextFloat() * (letter_z - letter_a + 1));
            buffer.append((char) randomLimitedInt);
        }
        return buffer.toString();
    }

    @Test
    public void update_todo(){
        final Integer someId = 3;
        when(existTodoRepository.exist(someId)).thenReturn(true);
        var todo = new Todo(someId, "title", "");
        when(findTodoRepository.find(someId)).thenReturn(todo);
        var argumentCaptor = ArgumentCaptor.forClass(Todo.class);
        final String description = "description";
        var request = new TodoUpdatingRequest(someId, "title", description);

        var result = updateTodoService.update(request);

        verify(updateTodoRepository).update(argumentCaptor.capture());
        assertThat(argumentCaptor.getValue().description).isEqualTo(description);
    }
}
