import {HttpStatusCode} from "../../HttpStatusCode";

export function UserSignUpPresenter(view, service){
    let self = this;

    self.signUp = async function(userSigningUpRequest){
        const response = await service.signUp(userSigningUpRequest);
        if(response.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerError();
            return;
        }
        throw 'not implemented';
    }
}
