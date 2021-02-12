package net.seymourpoler.tudumanager.domain.user.signUp.Models;

import java.time.LocalDateTime;

public class User {
    public final String email;
    public final String password;
    public final LocalDateTime creationDate;

    public User(String email, String password) {
        this.email = email;
        this.password = password;
        this.creationDate = LocalDateTime.now();
    }
}