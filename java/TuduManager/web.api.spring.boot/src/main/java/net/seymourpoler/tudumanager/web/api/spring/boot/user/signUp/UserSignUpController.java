package net.seymourpoler.tudumanager.web.api.spring.boot.user.signUp;

import net.seymourpoler.tudumanager.domain.user.signUp.IUserSignUpService;
import net.seymourpoler.tudumanager.domain.user.signUp.UserSigningUpArgs;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseCookie;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class UserSignUpController {
    private final IUserSignUpService userSignUpService;

    @Autowired
    public UserSignUpController(IUserSignUpService userSignUpService) {

        this.userSignUpService = userSignUpService;
    }

    @PostMapping("/api/users")
    public ResponseEntity signUp(@RequestBody HttpUserSignUpRequest request){
        var userSignUpResult = userSignUpService.signUp(
                new UserSigningUpArgs(request.email, request.password));

        if(userSignUpResult.isOk()){
            /*
        Cookie loginCookie=new Cookie("mouni","user.getUsername()");
            loginCookie.setMaxAge(30*5);
-----

            final String favColour = "steelblue";
            var cookie = ResponseCookie.from("fav-col", favColour).build();
            return ResponseEntity.ok()
                    .header(HttpHeaders.SET_COOKIE, cookie.toString())
                    .build();

            //throw new RuntimeException();
             */
            var cookie = ResponseCookie.from("signup", request.email).build();
            return ResponseEntity.ok()
                    .header(HttpHeaders.SET_COOKIE, cookie.toString())
                    .build();
        }
        return new ResponseEntity(userSignUpResult.errors(), HttpStatus.BAD_REQUEST);

    }
/*
    @PostMapping("/api/users")
    public void signUp(
            @RequestBody HttpUserSignUpRequest httpUserSignUpRequest,
            HttpServletRequest request,
            HttpServletResponse response){

        /*
        Cookie loginCookie=new Cookie("mouni","user.getUsername()");
            loginCookie.setMaxAge(30*5);
            response.addCookie(session);
-----
        final String favColour = "steelblue";
        var cookie = ResponseCookie.from("fav-col", favColour).build();
        return ResponseEntity.ok()
                .header(HttpHeaders.SET_COOKIE, cookie.toString())
                .build();

        throw new RuntimeException();
    }
 */
}
