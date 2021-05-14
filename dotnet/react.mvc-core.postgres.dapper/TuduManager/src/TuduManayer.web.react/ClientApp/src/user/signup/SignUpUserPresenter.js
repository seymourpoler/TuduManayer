import { HttpStatusCode } from "../../HttpStatusCode";

export function SignUpUserPresenter(view, service){
    let self = this;
    
    self.signUp = async function(signUpUserRequest){
        const response = await service.signUp(signUpUserRequest);
        if(response.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerError();
            return;
        }
        throw 'not implemented';
    }
}