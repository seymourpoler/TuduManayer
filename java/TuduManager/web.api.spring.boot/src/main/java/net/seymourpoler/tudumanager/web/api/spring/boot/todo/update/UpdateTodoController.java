package net.seymourpoler.tudumanager.web.api.spring.boot.todo.update;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.todo.update.IUpdateTodoService;
import net.seymourpoler.tudumanager.domain.todo.update.TodoUpdatingRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class UpdateTodoController {
    private IUpdateTodoService updateTodoService;

    @Autowired
    public UpdateTodoController(IUpdateTodoService updateTodoService) {
        this.updateTodoService = updateTodoService;
    }

    @PutMapping("/api/todos")
    public ResponseEntity update(@RequestBody HttpTodoUpdatingRequest httpTodoUpdatingRequest){
        var todoUpdatingRequest = new TodoUpdatingRequest(
                httpTodoUpdatingRequest.id,
                httpTodoUpdatingRequest.title,
                httpTodoUpdatingRequest.description);
        var executionResult = updateTodoService.update(todoUpdatingRequest);
        if(executionResult.isOk()){
            return new ResponseEntity(HttpStatus.OK);    
        }
        if(executionResult.errors().stream().findFirst().get().errorCode == ErrorCodes.NotFound){
            return new ResponseEntity(HttpStatus.NOT_FOUND);
        }
        return new ResponseEntity(executionResult.errors(), HttpStatus.BAD_REQUEST);
    }
}
