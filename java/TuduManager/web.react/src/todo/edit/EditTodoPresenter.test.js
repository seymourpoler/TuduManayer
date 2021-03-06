import { createEditTodoView } from './EditTodoView';
import { spyAllMethodsOf } from '../../Testing';
import { EditTodoPresenter } from './EditTodoPresenter';
import { EditTodoService } from './EditTodoService';
import { HttpStatusCode } from '../../HttpStatusCode';
import { createHttp } from '../../Http';

describe('EditTodoPresenter', () => {
    let view, service, http, presenter;

    beforeEach(() => {
        view = createEditTodoView();
        spyAllMethodsOf(view);
        http = createHttp();
        spyAllMethodsOf(http);
        service = new EditTodoService(http);
        presenter = new EditTodoPresenter(view, service);
    });

    describe('when load todo is requested', () => {
        it('shows spinner', () => {
            presenter.load();

            expect(view.showSpinner).toHaveBeenCalled();
        });

        it('cleans messages', () => {
            presenter.load();

            expect(view.cleanMessages).toHaveBeenCalled();
        });

        it('hides spinner', async () => {
            const someId = 1;
            http.get = () => {
                return { statusCode: HttpStatusCode.internalServerError };
            };

            await presenter.load(someId);

            expect(view.hideSpinner).toHaveBeenCalled();
        });

        it('shows an error if there is an internal server error', async () => {
            const todoId = 1;
            http.get = () => {
                return { statusCode: HttpStatusCode.internalServerError };
            };

            await presenter.load(todoId);

            expect(view.showInternalServerError).toHaveBeenCalled();
        });

        it('shows error if is not found', async () => {
            const todoId = 1;
            http.get = () => {
                return { statusCode: HttpStatusCode.notFound };
            };

            await presenter.load(todoId);

            expect(view.showNotFound).toHaveBeenCalled();
        });

        it('shows todo', async () => {
            const todoId = 1;
            const todo = {};
            http.get = () => {
                return { statusCode: HttpStatusCode.ok, body: todo };
            };

            await presenter.load(todoId);

            expect(view.showTodo).toHaveBeenCalledWith(todo);
        });
    });

    describe('when update todo is requested', () => {
        it('cleans messages', () => {
            presenter.update();

            expect(view.cleanMessages).toHaveBeenCalled();
        });

        it('shows spinner', () => {
            presenter.update();

            expect(view.showSpinner).toHaveBeenCalled();
        });

        it('hides spinner', async () => {
            http.put = () => {
                return { statusCode: HttpStatusCode.internalServerError };
            }
            await presenter.update();

            expect(view.hideSpinner).toHaveBeenCalled();
        });

        it('shows error if there is an internal server error', async () => {
            http.put = () => {
                return { statusCode: HttpStatusCode.internalServerError };
            }
            const todo = {title: 'a title', description:'a description'};

            await presenter.update(todo);

            expect(view.showInternalServerError).toHaveBeenCalled();
        });

        it('shows errors if there are errors', async () => {
            const errors = [];
            http.put = () => {
                return { statusCode: HttpStatusCode.badRequest, body: errors };
            }
            const todo = {title: 'a title', description:'a description'};

            await presenter.update(todo);

            expect(view.showErrors).toHaveBeenCalledWith(errors);
        });

        it('shows updated todo message', async() => {
            http.put = () => {
                return { statusCode: HttpStatusCode.ok };
            }
            const todo = {title: 'a title', description:'a description'};

            await presenter.update(todo);

            expect(view.showUpdatedTodoMessage).toHaveBeenCalled();
        });
    });

    describe('when cancel is requested', () => {
        it('returns to page before', () => {
            presenter.cancel();

            expect(view.redirectToPageBefore).toHaveBeenCalled();
        });
    });
});