import React from "react";

export class UserSignUpView extends React.Component {

    constructor(props){
        super(props);
        this.state = {};
    }

    render(){
        return(<div></div>);
    }

    showInternalServerError = () => {
        throw 'not implemented';
    }
}

export function createUserSignUpView(){
    return new UserSignUpView();
}