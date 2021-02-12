package net.seymourpoler.tudumanager.domain.todo.create.models;

import java.time.LocalDateTime;

public class Todo {
    public final String title;
    public final String description;
    public final LocalDateTime creationDate;

    public Todo(String title, String description) {
        this.title = title;
        this.description = description;
        creationDate = LocalDateTime.now();
    }
}
