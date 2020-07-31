package net.seymourpoler.tudumanager.web.api.spring.boot.todo;

import net.seymourpoler.tudumanager.domain.todo.delete.IDeleteTodoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class DeleteTodoController {
    private final IDeleteTodoService deleteTodoService;

    @Autowired
    public DeleteTodoController(IDeleteTodoService deleteTodoService) {
        this.deleteTodoService = deleteTodoService;
    }

    @DeleteMapping("/api/todos")
    public ResponseEntity delete(@RequestParam("todoId") Integer todoId){
        var executionResult = deleteTodoService.delete(todoId);
        if(executionResult.isOk()) {
            return new ResponseEntity(HttpStatus.OK);
        }
        return new ResponseEntity(HttpStatus.NOT_FOUND);
    }
}
