import React from "react";
import {createUserSignUpPresenter} from "./UserSignUpPresenter";
import {Spinner} from "../../Spinner";
import {ErrorMessages} from "../../ErrorMessages";

export class UserSignUpView extends React.Component {

    constructor(props){
        super(props);
        this.state = {
            showSpinner: false,
            email:'',
            emailErrorMessage: '',
            password: '',
            passwordErrorMessage: '',
            errorMessage: '',
            message: '',
        };
    }

    presenter = createUserSignUpPresenter(this);

    render(){
        return(<div>
            <Spinner show={this.state.showSpinner}/>
            <p>Email: <input type='text' id='txtEmail' onChange={this.onEmailChangedHandler} /></p>
            <p id='lblEmailErrorMessage'>{this.state.emailErrorMessage}</p>
            <p>Password: <input type='password' id='txtPassword' onChange={this.onPasswordChangedHandler} /></p>
            <p id='lblPasswordErrorMessage'>{this.state.passwordErrorMessage}</p>
            <button onClick={this.onSaveClickedHandler}>Save</button>
            <button onClick={this.onCancelClickedHandler}>Cancel</button>
            <p>{this.state.errorMessage}</p>
            <p>{this.state.message}</p>
        </div>);
    }

    cleanMessages = () => {
        this.setState({ message: '' });
        this.setState({ errorMessage: '' });
        this.setState({ emailErrorMessage: '' });
        this.setState({ passwordErrorMessage: '' });
    }

    showInternalServerError = () => {
        this.setState({ errorMessage: ErrorMessages.InternalServerError });
    }

    showErrors = (errors) => {
        errors.forEach(error => {
            const message = ErrorMessages[error.errorCode];
            if(error.fieldId === 'Email'){
                this.setState({ emailErrorMessage: message });
                return;
            }
            if(error.fieldId === 'Password'){
                this.setState({ passwordErrorMessage: message });
                return;
            }
            this.setState({ passwordErrorMessage: message });
        });
    }

    showSpinner = () => {
        this.setState({showSpinner: true});
    }

    hideSpinner = () => {
        this.setState({showSpinner: false});
    }

    onEmailChangedHandler = (event) => {
        this.setState({ email: event.target.value });
    }

    onPasswordChangedHandler = (event) => {
        this.setState({ password: event.target.value });
    }

    onSaveClickedHandler = (event) => {
        this.presenter.signUp({
            email: this.state.email,
            password: this.state.password });
    }

    onCancelClickedHandler = (event) => {
        this.props.history.push('/');
    }

    showUserSignedUp = () => {
        this.setState({message: 'user signed up.'});
    }
}

export function createUserSignUpView(){
    return new UserSignUpView();
}