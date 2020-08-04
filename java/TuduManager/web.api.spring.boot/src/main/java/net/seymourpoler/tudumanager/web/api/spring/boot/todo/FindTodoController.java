package net.seymourpoler.tudumanager.web.api.spring.boot.todo;

import net.seymourpoler.tudumanager.domain.todo.find.IFindTodoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class FindTodoController {
    private final IFindTodoService findTodoService;

    @Autowired
    public FindTodoController(IFindTodoService findTodoService) {
        this.findTodoService = findTodoService;
    }

    @GetMapping("/api/todos/{todoId}")
    public ResponseEntity find(@PathVariable Integer todoId){
        var todoMaybe = findTodoService.find(todoId);
        if(!todoMaybe.isPresent()){
            return new ResponseEntity(HttpStatus.NOT_FOUND);
        }
        throw new RuntimeException();

    }
}
