import { beforeEach, describe, expect, it } from "vitest";
import * as TypeMoq from "typemoq";
import { Http } from "../src/Http";
import { TodoService } from "../src/TodoService";
import { Todo } from "../src/Todo";


describe("TodoService", () => {
    let http: TypeMoq.IMock<Http>;
    let service: TodoService;

    beforeEach(() => {
        http = TypeMoq.Mock.ofType<Http>();
        service = new TodoService(http.object);
    });

    describe("when finding todos are requested", () => {
        it("should return the todos", async () => {
            const anyTodos:Todo[] = [{ id: 1, description: "todo 1", completed: false },{ id: 2, description: "todo 2", completed: true }];
            http.setup((x) => x.get("api/todos")).returns(async () => anyTodos);

            const todos = await service.find();

            expect(todos).toEqual(anyTodos);
        });
    });

    describe("when creating a todo is requested", () => {
        it("should create the todo", async () => {
            const todo: Todo = { id: 0, description: "new todo", completed: false };

            await service.create(todo);

            http.verify((x) => x.post("api/todos", todo), TypeMoq.Times.once());
        });
    });

    describe("when deleting a todo is requested", () => {
        it("should delete the todo", async () => {
            const id = 1;
            http.setup((x) => x.delete(`api/todos/${id}`)).returns(async () => {});

            await service.delete(id);

            http.verify((x) => x.delete(`api/todos/${id}`), TypeMoq.Times.once());
        });
    });
});


