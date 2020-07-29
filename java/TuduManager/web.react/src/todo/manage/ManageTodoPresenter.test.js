import { createManageTodoView } from './ManageTodoView';
import { ManageTodoService, createManageTodoService } from './ManageTodoService';
import { createManageTodoPresenter } from './CreateManageTodoPresenter';
import { spyAllMethodsOf } from '../../Testing';
import { Http, createHttp } from '../../Http';
import { HttpStatusCode } from '../../HttpStatusCode';

describe('Manage Todo Presenter', () => {
    let view, service, presenter, http;

     beforeEach(() => {
        http = createHttp();
        spyAllMethodsOf(http);
        view = createManageTodoView();
        spyAllMethodsOf(view);
        service = new ManageTodoService(http);
        presenter = new createManageTodoPresenter(view, service);
     });

    describe('when search is requested', () => {
        it('cleans all messages', async () => {
            const searchText = 'tonight';
            http.get = () => { return { statusCode: HttpStatusCode.internalServerError }; };

            await presenter.search(searchText);

            expect(view.cleanMessages).toHaveBeenCalled();
        });

        it('shows spinner', async () => {
            const searchText = 'tonight';
            http.get = () => { return { statusCode: HttpStatusCode.internalServerError }; };

            await presenter.search(searchText);

            expect(view.showSpinner).toHaveBeenCalled();
        });

        it('shows error if there is an internal server error', async () => {
            const searchText = 'tonight';
            http.get = () => { return { statusCode: HttpStatusCode.internalServerError }; };

            await presenter.search(searchText);

            expect(view.showInternalServerError).toHaveBeenCalled();
        });

        it('shows todos', async () => {
            const todos = [{id:1, title: 'a title'}, {id:2, title: 'another title'}];
            const searchText = 'tonight';
            http.get = () => {
                return { statusCode: HttpStatusCode.ok, body: todos };
            };

            await presenter.search(searchText);

            expect(view.hideSpinner).toHaveBeenCalled();
            expect(view.showTodos).toHaveBeenCalledWith(todos);
        });

        describe('when todos are loaded', () => {
            beforeEach(async () => {
                const todos = [{id:1, title: 'a title'}];
                const searchText = 't';
                http.get = () => {
                    return { statusCode: HttpStatusCode.ok, body: todos };
                };
                await presenter.search(searchText);
            });

            describe('when delete is requested', () => {
                it('cleans messages', () => {
                    const someId = 3;

                    presenter.deleteTodo(someId);

                    expect(view.cleanMessages).toHaveBeenCalled();
                });

                it('shows spinner', () => {
                    const someId = 3;

                    presenter.deleteTodo(someId);

                    expect(view.showSpinner).toHaveBeenCalled();
                });

                it('shows error if there is an internal server error', async () => {
                    const  someId = 3;
                    http.delete = () => {
                        return { statusCode: HttpStatusCode.internalServerError };
                    }

                    await presenter.deleteTodo(someId);

                    expect(view.showInternalServerError).toHaveBeenCalled();
                });

                it('shows error message if is not found', async () => {
                    const  someId = 3;
                    http.delete = () => {
                        return { statusCode: HttpStatusCode.notFound };
                    }

                    await presenter.deleteTodo(someId);

                    expect(view.showNotFound).toHaveBeenCalled();
                });

                it('shows todos without deleted todo', async () =>{
                    const todoId = 1;
                    http.delete = () => {
                        return { statusCode: HttpStatusCode.ok };
                    }

                    await presenter.deleteTodo(todoId);

                    expect(view.showTodos).toHaveBeenCalledWith([]);
                });
            });
        });
    });

    describe('when edit is requested', () => {
        it('redirects to edit todo', () => {
            const someId = 2;

            presenter.editTodo(someId);

            expect(view.redirectToEditTodo).toHaveBeenCalledWith(someId);
        });
    });

    describe('when creation a new todo is requested', () => {
        it('redirects to a creation of a new todo', () => {
            presenter.createNewTodo();

            expect(view.redirectToCreateNewTodo).toHaveBeenCalled();
        });
    });
});