package net.seymourpoler.tudumanager.web.api.spring.boot.todo.delete;

import net.seymourpoler.tudumanager.domain.todo.delete.IDeleteTodoService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class DeleteTodoController {

    private final IDeleteTodoService deleteTodoService;

    public DeleteTodoController(IDeleteTodoService deleteTodoService) {
        this.deleteTodoService = deleteTodoService;
    }

    public ResponseEntity delete(@RequestParam("todoId") Integer todoId){
        return new ResponseEntity(HttpStatus.NOT_FOUND);
    }
}
