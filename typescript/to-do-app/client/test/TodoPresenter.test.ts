import { describe, beforeEach, it, expect } from "vitest";
import { TodoPresenter } from "../src/TodoPresenter";
import { TodoService } from "../src/TodoService";
import { Todo } from "../src/Todo";
import * as TypeMoq from "typemoq";
import App from "../src/App";

describe("TodoPresenter", () => {
    let view: TypeMoq.IMock<App>;
    let service: TypeMoq.IMock<TodoService>;
    let presenter: TodoPresenter;

    beforeEach(() => {
        view = TypeMoq.Mock.ofType<App>();
        service = TypeMoq.Mock.ofType<TodoService>();
        presenter = new TodoPresenter(view.object, service.object);
    });

    describe("when finding todos are requested", () => {
        it("should return the todos", async () => {
            const anyTodos:Todo[] = [{ id: 1, description: "todo 1", completed: false },{ id: 2, description: "todo 2", completed: true }];
            service.setup((x) => x.find()).returns(async () => anyTodos);

            await presenter.findTodos();

            view.verify((x) => x.showTodos(anyTodos), TypeMoq.Times.once());
        });
    });

    describe("when creating a todo is requested", () => {
        it("should create a todo", async () => {
            const anyTodos:Todo[] = [{ id: 1, description: "todo 1", completed: false },{ id: 2, description: "todo 2", completed: true }];
            service.setup((x) => x.find()).returns(async () => anyTodos);
            
            await presenter.create("new todo");

            view.verify((x) => x.showTodos(anyTodos), TypeMoq.Times.once());
            view.verify((x) => x.cleanDescription(), TypeMoq.Times.once());
            service.verify((x) => x.create(TypeMoq.It.is<Todo>(x => x.description == "new todo" && x.completed == false)), TypeMoq.Times.once());
        });
    })

    describe("when deleting a todo is requested", () => {
        it("should delete a todo", async () => {
            const anyTodos:Todo[] = [{ id: 1, description: "todo 1", completed: false },{ id: 2, description: "todo 2", completed: true }];
            service.setup((x) => x.find()).returns(async () => anyTodos);
            await presenter.delete(1);

            service.verify((x) => x.delete(1), TypeMoq.Times.once());
            view.verify((x) => x.showTodos(anyTodos), TypeMoq.Times.once());
        });
    });
});