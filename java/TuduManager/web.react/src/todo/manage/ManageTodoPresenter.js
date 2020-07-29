import { createManageTodoService } from './ManageTodoService';
import { HttpStatusCode } from '../../HttpStatusCode';

export function manageTodoPresenter(view, manageTodoService = createManageTodoService()) {
    let self = {};
    let todos = [];

    self.search = async (textSearch) => {
        view.cleanMessages();
        view.showSpinner();
        const result = await manageTodoService.search(textSearch);
        view.hideSpinner();

        if(result.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerError();
            return;
        }
        todos = result.todos;
        view.showTodos(result.todos);
    }

    self.createNewTodo = () => {
        view.redirectToCreateNewTodo();
    }

    self.editTodo = (todoId) => {
        view.redirectToEditTodo(todoId);
    }

    self.deleteTodo = async function(todoId) {
        view.cleanMessages();
        view.showSpinner();

        const response = await manageTodoService.delete(todoId);
        view.hideSpinner();

        if(response.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerError();
            return;
        }
        if(response.statusCode === HttpStatusCode.notFound){
            view.showNotFound();
            return;
        }

        todos = todos.filter(x => x.id !== todoId);
        view.showTodos(todos);
    }

    return self;
}