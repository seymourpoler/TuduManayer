package net.seymourpoler.tudumanager.domain.todo.update;

public class TodoUpdatingRequest {
    private Integer id;
    public Integer id(){
        return id;
    }

    private String title;
    public String title(){
        return title;
    }

    private String description;
    public String description(){
        return description;
    }

    public TodoUpdatingRequest(Integer id, String title, String description) {
        this.id = id;
        this.title = title;
        this.description = description;
    }
}
