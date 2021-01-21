package net.seymourpoler.tudumanager.domain.user.signUp.Models;

public class User {
    public final String email;
    public final String password;

    public User(String email, String password) {
        this.email = email;
        this.password = password;
    }
}
