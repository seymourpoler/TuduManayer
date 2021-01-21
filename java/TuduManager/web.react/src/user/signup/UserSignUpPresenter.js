import {HttpStatusCode} from "../../HttpStatusCode";
import {createUserSignUpService} from "./UserSignUpService";

export function UserSignUpPresenter(view, service){
    let self = this;

    self.signUp = async function(userSigningUpRequest){
        view.cleanMessages();
        view.showSpinner();
        const response = await service.signUp(userSigningUpRequest);
        view.hideSpinner();
        if(response.statusCode === HttpStatusCode.internalServerError){
            return view.showInternalServerError();
        }
        if(response.statusCode === HttpStatusCode.badRequest){
            return view.showErrors(response.errors);
        }
        view.showUserSignedUp();
    }
}

export function createUserSignUpPresenter(view){
    const service = createUserSignUpService();
    return new UserSignUpPresenter(view, service);

}
