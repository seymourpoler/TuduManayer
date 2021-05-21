import React from "react";
import {Spinner} from "../../Spinner";
import {createSignUpUserPresenter} from "./SignUpUserPresenter";

export class SignUpUserView extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            showSpinner: false,
            email: '',
            password: '',
            errorMessage: '',
            message: ''
        }
    }

    presenter = createSignUpUserPresenter(this);

    render(){
        return (<div>
            <Spinner show={this.state.showSpinner} />
            <p>Email: <input type='text' id='email' onChange={this.onTitleChangedHandler} value={this.state.email} /></p>
            <p id='emailErrorMessage'>{this.state.titleErrorMessage}</p>
            <p>Password: <input type='text' id='password' onChange={this.onPasswordChangedHandler} value={this.state.password} /></p>
            <button id='signUp' onClick={this.onSignUpClickedHandler}>SingUp</button>
            <button id='cancel' onClick={this.onCancelClickedHandler}>Cancel</button>
            <p id='errorMessage'>{this.state.errorMessage}</p>
            <p id='message'>{this.state.message}</p>
        </div>);
    }

    showSpinner = () => {
        this.setState({showSpinner: true});
    }

    hideSpinner = () => {
        this.setState({showSpinner: false});
    }

    showInternalServerError = () => {
        this.setState({errorMessage: 'There is an internal server error.'})
    }

    showErrors = (errors) => {throw 'not implemented';}

    showMessageUserIsSignedUp = ()=> { throw 'not implemented';}

    onSignUpClickedHandler = (event) => {
        this.presenter.signUp({
            email: this.state.email,
            password: this.state.password
        });
    }

    onCancelClickedHandler = (event) => {
        this.presenter.cancel();
    }

    onPasswordChangedHandler = (event) =>{
        
    }
}

export function createSignUpUserView(){
    return new SignUpUserView();
}