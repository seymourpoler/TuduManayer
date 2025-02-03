import { describe, it, beforeEach, expect, vi } from "vitest";
import * as TypeMoq from "typemoq";
import { Request, Response } from 'express';
import { Either } from "@leanmind/monads";
import { createRequest, createResponse, MockRequest, MockResponse } from 'node-mocks-http';
import { CreateTodoController } from "../../../src/infra/http/CreateTodoController";
import { CreateTodoService } from "../../../src/application/CreateTodoService";
import { CreateTodoArg } from "../../../src/application/CreateTodoArgs";
import { Error } from "../../../src/domain/Error";

describe('SaveTodoController', () => {
    let service: TypeMoq.IMock<CreateTodoService>;
    let controller: CreateTodoController;

    beforeEach(() => {
        service = TypeMoq.Mock.ofType<CreateTodoService>();
        controller = new CreateTodoController(service.object);
    });

    describe('When saving a todo is requested', () => {
        it('should save a todo', async () => {
            service.setup(x => x.create(TypeMoq.It.isAny())).returns(async () => Promise.resolve(Either.right(null)));
            const anyRequest: MockRequest<Request> = createRequest({ body: { description: 'todo', completed: false } });
            const anyResponse: MockResponse<Response> = createResponse();
            anyResponse.status = vi.fn().mockReturnValue(anyResponse);
            anyResponse.send = vi.fn();
    
            await controller.create(anyRequest, anyResponse);
    
            service.verify(x => x.create(TypeMoq.It.is<CreateTodoArg>(x => x.completed == false && x.description == 'todo')), TypeMoq.Times.once());
            expect(anyResponse.status).toHaveBeenCalledWith(201);
            expect(anyResponse.send).toHaveBeenCalled();
        });

        it('should return 400 when description is not provided', async () => {
            service.setup(x => x.create(TypeMoq.It.isAny())).returns(async () => Promise.resolve(Either.left(new Error('description', 'Description is required'))));
            const anyRequest: MockRequest<Request> = createRequest({ body: { completed: false } });
            const anyResponse: MockResponse<Response> = createResponse();
            anyResponse.status = vi.fn().mockReturnValue(anyResponse);
            anyResponse.send = vi.fn();
    
            await controller.create(anyRequest, anyResponse);
    
            expect(anyResponse.status).toHaveBeenCalledWith(400);
            expect(anyResponse.send).toHaveBeenCalledWith(new Error('description', 'Description is required'));
        });

        it('should return 400 when completed is not provided', async () => {
            service.setup(x => x.create(TypeMoq.It.isAny())).returns(async () => Promise.resolve(Either.left(new Error('completed', 'Completed is required'))));
            const anyRequest: MockRequest<Request> = createRequest({ body: { Description: 'a description' } });
            const anyResponse: MockResponse<Response> = createResponse();
            anyResponse.status = vi.fn().mockReturnValue(anyResponse);
            anyResponse.send = vi.fn();
    
            await controller.create(anyRequest, anyResponse);
    
            expect(anyResponse.status).toHaveBeenCalledWith(400);
            expect(anyResponse.send).toHaveBeenCalledWith(new Error('completed', 'Completed is required'));
        });
    });
});