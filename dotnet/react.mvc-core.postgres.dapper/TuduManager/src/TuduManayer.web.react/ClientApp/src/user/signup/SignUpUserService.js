import { createHttp } from "../../Http";
import { HttpStatusCode } from "../../HttpStatusCode";

export function SignUpUserService(http){
    let self = this;
    
    self.signUp = async function (signUpUserRequest){
        const url = 'api/users';
        const response = await http.post(url, signUpUserRequest);
        if(response.statusCode === HttpStatusCode.internalServerError) {
            return { statusCode: HttpStatusCode.internalServerError };
        }
        if(response.statusCode === HttpStatusCode.badRequest) {
            return { 
                statusCode: HttpStatusCode.badRequest, 
                errors: response.body
            }
        }
        throw 'not implemented';
    }
}
export function createSignUpUserService(){
    const http = createHttp();
    return new SignUpUserService(http);
}