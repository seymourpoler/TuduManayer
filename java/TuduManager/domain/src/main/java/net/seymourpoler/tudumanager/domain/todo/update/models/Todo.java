package net.seymourpoler.tudumanager.domain.todo.update.models;

import java.time.LocalDateTime;

public class Todo {
    private Integer id;
    public Integer id(){ return id;}
    public String title;
    public String title(){ return title; }
    public String description;
    public String description(){return description; }
    public LocalDateTime updatedDate;
    public LocalDateTime updatedDate(){ return updatedDate; }

    public Todo(Integer id, String title, String description) {
        this.id = id;
        this.title = title;
        this.description = description;
    }

    public Todo(Integer id, String title)  {
        this.id = id;
        this.title = title;
        this.description = "";
    }

    public void update(String title, String description) {
        this.title = title;
        this.description = description;
        this.updatedDate = LocalDateTime.now();
    }
}
