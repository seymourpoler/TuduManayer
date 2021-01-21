package net.seymourpoler.tudumanager.domain.user.signUp;

public class UserSigningUpArgs {

    public final String email;
    public final String password;

    public UserSigningUpArgs(String email, String password) {
        this.email = email;
        this.password = password;
    }

}
