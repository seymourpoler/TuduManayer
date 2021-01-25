import { createHttp} from "../../Http";

function SignUpUserService(http){
    let self = this;
    
    self.signUp = function (signUpUserRequest){
        throw 'not implemented';
    }
}
export function createSignUpUserService(){
    const http = createHttp();
    return new SignUpUserService(http);
}