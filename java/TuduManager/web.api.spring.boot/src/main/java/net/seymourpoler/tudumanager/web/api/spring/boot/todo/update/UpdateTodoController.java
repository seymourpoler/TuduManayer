package net.seymourpoler.tudumanager.web.api.spring.boot.todo.update;

import net.seymourpoler.tudumanager.domain.todo.update.IUpdateTodoService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class UpdateTodoController {
    private IUpdateTodoService updateTodoService;

    public UpdateTodoController(IUpdateTodoService updateTodoService) {
        this.updateTodoService = updateTodoService;
    }

    public ResponseEntity update(HttpTodoUpdatingRequest request){
        throw new RuntimeException();
    }
}
