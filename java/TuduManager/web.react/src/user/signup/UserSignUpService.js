import {createHttp} from "../../Http";
import {HttpStatusCode} from "../../HttpStatusCode";

export function UserSignUpService(http){
    let self = this;

    self.signUp = async function(signUpArgs){
        const url = '/api/users';
        const response = await http.post(url, signUpArgs);
        if(response.statusCode === HttpStatusCode.internalServerError) {
            return { statusCode: HttpStatusCode.internalServerError };
        }
        if(response.statusCode === HttpStatusCode.badRequest) {
            return { statusCode: HttpStatusCode.badRequest, errors: response.body };
        }
        return { statusCode: response.statusCode };
    }
}

export function createUserSignUpService(){
    const http = createHttp();
    return new UserSignUpService(http);
}