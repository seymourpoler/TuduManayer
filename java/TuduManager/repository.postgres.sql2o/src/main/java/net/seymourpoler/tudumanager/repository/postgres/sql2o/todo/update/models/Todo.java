package net.seymourpoler.tudumanager.repository.postgres.sql2o.todo.update.models;

import java.time.LocalDateTime;

public class Todo {
    public Integer id;
    public String title;
    public String description;
    public LocalDateTime updated_date;
}
