import React from 'react';
import { Spinner } from '../../Spinner';
import {createEditTodoPresenter} from "./EditTodoPresenter";

export class EditTodoView extends React.Component {

    constructor(props){
        super(props);

        this.state = {
            showSpinner: false,
            id: '',
            title: '',
            description: '',
            titleErrorMessage: '',
            errorMessage: '',
            message: ''
        }
    }

    presenter = createEditTodoPresenter(this);

    componentDidMount() {
        this.setState({id: this.props.match.params.todoId });
        this.presenter.load(this.props.match.params.todoId);
    }

    render(){
        return (<div>
            <Spinner show={this.state.showSpinner} />
            <p>Title: <input type='text' id='title' onChange={this.onTitleChangedHandler} value={this.state.title} /></p>
            <p id='titleErrorMessage'>{this.state.titleErrorMessage}</p>
            <p>Description: <input type='text' id='description' onChange={this.onDescriptionChangedHandler} value={this.state.description} /></p>
            <button id='save' onClick={this.onSaveClickedHandler}>Save</button>
            <button id='cancel' onClick={this.onCancelClickedHandler}>Cancel</button>
            <p id='errorMessage'>{this.state.errorMessage}</p>
            <p id='message'>{this.state.message}</p>
        </div>);
    }

    cleanMessages = () => {
        this.setState({
            titleErrorMessage: '',
            errorMessage: '',
            message: ''
        });
    }

    showSpinner = () => {
        this.setState({showSpinner: true});
    }

    hideSpinner = () => {
        this.setState({showSpinner: false});
    }

    showTodo = (todo) => {
        this.setState({title: todo.title});
        this.setState({description: todo.description});
    }

    showInternalServerError = () => {
        this.setState({errorMessage: 'There is an internal server error.'})
    }

    showNotFound = () => {
        this.setState({errorMessage: 'todo not found'});
    }

    showErrors = (errors) => {
        this.setState({errorMessage: 'there are some errors'});
    }

    showUpdatedTodoMessage = () => {
        this.setState({message: 'TODO updated'});
    }

    redirectToPageBefore = () => {
        this.props.history.push('/manage');
    }

    onTitleChangedHandler = (event) => {
        this.setState({ title: event.target.value });
    }

    onDescriptionChangedHandler = (event) => {
        this.setState({ description: event.target.value });
    }

    onSaveClickedHandler = (event) => {
        this.presenter.update({
            id: this.state.id,
            title: this.state.title,
            description: this.state.description
        });
    }

    onCancelClickedHandler = (event) => {
        this.presenter.cancel();
    }
}

export function createEditTodoView(){
    return new EditTodoView();
}