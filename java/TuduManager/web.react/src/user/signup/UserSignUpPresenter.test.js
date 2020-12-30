import { spyAllMethodsOf } from '../../Testing';
import {HttpStatusCode} from "../../HttpStatusCode";
import {UserSignUpPresenter} from "./UserSignUpPresenter";
import {createHttp} from "../../Http";
import {UserSignUpService} from "./UserSignUpService";
import {createUserSignUpView} from "./UserSignUpView";

describe('User SignUp Pesenter', () =>{

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
    });
});