import { SignUpUserPresenter } from './SignUpUserPresenter';
import { createSignUpUserView } from './SignUpUserView';
import { spyAllMethodsOf } from '../../Testing';
import { createSignUpUserService } from './SignUpUserService';
import { createHttp } from "../../Http";
import {HttpStatusCode} from "../../HttpStatusCode";

describe('SignUp Presenter', function (){
    let view, presenter, service, http;
    
    beforeEach(function(){
        view =  createSignUpUserView();
        spyAllMethodsOf(view);
        http = createHttp();
        spyAllMethodsOf(http);
        service = createSignUpUserService(http);
        spyAllMethodsOf(service);
        presenter = new SignUpUserPresenter(view, service);        
    });
    
    describe('when signing up is requested', function(){
        it('shows an error if there is an internal server error', function(){
            http.post = () => {httpStatusCode: HttpStatusCode.internalServerError};
            const request = {};
            
            presenter.signUp(request);
            
            expect(view.showInternalServerError).toHaveBeenCalled();
        });
    });
});