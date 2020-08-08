package net.seymourpoler.tudumanager.web.api.spring.boot.todo.update;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.todo.update.IUpdateTodoService;
import net.seymourpoler.tudumanager.domain.todo.update.TodoUpdatingRequest;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class UpdateTodoController {
    private IUpdateTodoService updateTodoService;

    public UpdateTodoController(IUpdateTodoService updateTodoService) {
        this.updateTodoService = updateTodoService;
    }

    public ResponseEntity update(HttpTodoUpdatingRequest httoTodoUpdatingRequest){
        var todoUpdatingRequest = new TodoUpdatingRequest(
                httoTodoUpdatingRequest.id,
                httoTodoUpdatingRequest.title,
                httoTodoUpdatingRequest.description);
        var executionResult = updateTodoService.update(todoUpdatingRequest);
        if(!executionResult.isOk()){
            if(executionResult.errors().stream().findFirst().get().errorCode == ErrorCodes.NotFound){
                return new ResponseEntity(HttpStatus.NOT_FOUND);
            }
            return new ResponseEntity(executionResult.errors(), HttpStatus.BAD_REQUEST);
        }

        throw new RuntimeException();
    }


}
