import { beforeEach, describe, it, expect } from "vitest";
import * as TypeMoq from "typemoq";
import { Request, Response } from 'express';
import { createRequest, createResponse, MockRequest, MockResponse } from 'node-mocks-http';
import { FindTodosController } from "../../../src/infra/http/FindTodosController";
import { PostgresFindTodosRepository } from "../../../src/infra/database/PostgresFindTodosRepository";
import { Todo } from "../../../src/domain/Todo";

describe("FindTodosController", () => {
    let controller: FindTodosController;
    let repository: TypeMoq.IMock<PostgresFindTodosRepository>;

    beforeEach(() => {
        repository = TypeMoq.Mock.ofType<PostgresFindTodosRepository>();
        controller = new FindTodosController(repository.object);
    });

    describe("when finding todos are requested", () => {
        it("returns all todos", async () => {
            const expectedTodos = [Todo.createSafe('any_description', false), Todo.createSafe('another_any_description', true)];
            repository.setup(x => x.find()).returns(() => Promise.resolve<Todo[]>(expectedTodos));
            const anyRequest: MockRequest<Request> = createRequest();
            const anyResponse: MockResponse<Response> = createResponse();
            
            const response = await controller.find(anyRequest, anyResponse);

            expect(response.statusCode).toBe(200);
            const todos = response._getJSONData();
            expect(todos[0].description).toEqual(expectedTodos[0].description);
            expect(todos[0].completed).toEqual(expectedTodos[0].completed);
            expect(todos[0].created).toEqual(expectedTodos[0].created.toISOString());
        });
    });
});