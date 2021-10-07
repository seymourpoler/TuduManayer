import { createSignUpUserView } from './SignUpUserView';
import { spyAllMethodsOf } from '../../Testing';
import {SignUpUserService} from './SignUpUserService';
import { createHttp } from "../../Http";
import { HttpStatusCode } from "../../HttpStatusCode";
import { SignUpUserPresenter } from "./SignUpUserPresenter";

describe('SignUp Presenter', async function (){
    let view, presenter, service, http;
    
    beforeEach(function(){
        view =  createSignUpUserView();
        spyAllMethodsOf(view);
        http = createHttp();
        spyAllMethodsOf(http);
        service = new SignUpUserService(http);
        presenter = new SignUpUserPresenter(view, service);
    });
    
    describe('when signing up is requested', async function(){
        it('shows an error if there is an internal server error', async function(){
            http.post = () => {return { statusCode: HttpStatusCode.internalServerError }};
            const request = {};
            
            await presenter.signUp(request);
            
            expect(view.showInternalServerError).toHaveBeenCalled();
        });
        it('shows an error if there is an error', async function(){
            const errors = [];
            http.post = () => {return { statusCode: HttpStatusCode.badRequest, body: errors }};
            const request = {};

            await presenter.signUp(request);

            expect(view.showErrors).toHaveBeenCalledWith(errors);
        });
        it('shows message if user is signed up', async function(){
            http.post = () => {return { statusCode: HttpStatusCode.ok }};
            const request = {};

            await presenter.signUp(request);

            expect(view.showMessageUserIsSignedUp).toHaveBeenCalled();
        });
    });
});