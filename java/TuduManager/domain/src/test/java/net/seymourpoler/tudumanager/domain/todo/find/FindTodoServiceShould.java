package net.seymourpoler.tudumanager.domain.todo.find;

import net.seymourpoler.tudumanager.domain.todo.delete.IExistTodoRepository;
import org.junit.Before;
import org.junit.Test;

import java.util.Optional;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class FindTodoServiceShould {
    IExistTodoRepository existTodoRepository;
    IFindTodoRepository findTodoRepository;
    IFindTodoService findTodoService;

    @Before
    public void setUp(){
        existTodoRepository = mock(IExistTodoRepository.class);
        findTodoRepository = mock(IFindTodoRepository.class);
        findTodoService = new FindTodoService(existTodoRepository, findTodoRepository);
    }

    @Test
    public void
    return_empty_when_is_not_found(){
        final Integer someId = 4;
        when(existTodoRepository.exist(someId)).thenReturn(false);

        var result = findTodoService.find(someId);

        assertThat(result).isEqualTo(Optional.empty());
    }
}
