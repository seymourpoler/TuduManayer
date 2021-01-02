import { spyAllMethodsOf } from '../../Testing';
import {HttpStatusCode} from "../../HttpStatusCode";
import {UserSignUpPresenter} from "./UserSignUpPresenter";
import {createHttp} from "../../Http";
import {UserSignUpService} from "./UserSignUpService";
import {createUserSignUpView} from "./UserSignUpView";

describe('User SignUp Presenter', () =>{

    let view, service, presenter, http;

    beforeEach(() => {
        view = createUserSignUpView();
        spyAllMethodsOf(view);
        http = createHttp();
        spyAllMethodsOf(http);
        service = new UserSignUpService(http);
        presenter = new UserSignUpPresenter(view, service);
    });

    describe('when signUp is requested', () => {
        it('shows error if there is an internal server error', async () =>{
            const userSigningUpRequest = {email: 'e@mail.com', password: 'password'};
            http.post = () => {
                return { statusCode: HttpStatusCode.internalServerError };
            };

            await presenter.signUp(userSigningUpRequest);

            expect(view.showInternalServerError).toHaveBeenCalled();
        });

        it('shows error if there is any error', async () =>{
            const userSigningUpRequest = {email: '', password: 'password'};
            const errors = [{fieldId: 'Email', errorCode: 'Required'}];
            http.post = () => {
                return {
                    statusCode: HttpStatusCode.badRequest,
                    body: errors };
            };

            await presenter.signUp(userSigningUpRequest);

            expect(view.showErrors).toHaveBeenCalledWith(errors);
        });

        it('return user signed up', async () =>{
            const userSigningUpRequest = {email: 'e@mail.com', password: 'password'};
            http.post = () => {
                expect(view.cleanMessages).toHaveBeenCalled();
                expect(view.showSpinner).toHaveBeenCalled();
                return { statusCode: HttpStatusCode.ok };
            };

            await presenter.signUp(userSigningUpRequest);

            expect(view.hideSpinner).toHaveBeenCalled();
            expect(view.showUserSignedUp).toHaveBeenCalled();
        });
    });
});