import { HttpStatusCode } from "../../HttpStatusCode";
import {createSignUpUserService} from "./SignUpUserService";

export function SignUpUserPresenter(view, service){
    let self = this;
    
    self.signUp = async function(signUpUserRequest){
        const response = await service.signUp(signUpUserRequest);
        if(response.statusCode === HttpStatusCode.internalServerError){
            return view.showInternalServerError();
        }
        if(response.statusCode === HttpStatusCode.badRequest){
            return view.showErrors(response.errors);
        }
        if(response.statusCode === HttpStatusCode.ok){
            return view.showMessageUserIsSignedUp();
            
        }
    }
}

export function createSignUpUserPresenter(view){
    const service = createSignUpUserService();
    return new SignUpUserPresenter(view, service);
}