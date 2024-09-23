import { describe, it, beforeEach, expect, vi } from "vitest";
import * as TypeMoq from "typemoq";
import { Request, Response } from 'express';
import { Either } from "@leanmind/monads";
import { createRequest, createResponse, MockRequest, MockResponse } from 'node-mocks-http';
import { SaveTodoController } from "../../../src/infra/http/SaveTodoController";
import { SaveTodoService } from "../../../src/domain/services/SaveTodoService";
import { SaveTodoArg } from "../../../src/domain/services/SaveTodoArgs";
import { Error } from "../../../src/domain/models/Error";

describe('SaveTodoController', () => {
    let service: TypeMoq.IMock<SaveTodoService>;
    let controller: SaveTodoController;

    beforeEach(() => {
        service = TypeMoq.Mock.ofType<SaveTodoService>();
        controller = new SaveTodoController(service.object);
    });

    describe('When saving a todo is requested', () => {
        it('should save a todo', async () => {
            service.setup(x => x.save(TypeMoq.It.isAny())).returns(async () => Promise.resolve(Either.right(null)));
            const anyRequest: MockRequest<Request> = createRequest({ body: { description: 'todo', completed: false } });
            const anyResponse: MockResponse<Response> = createResponse();
            anyResponse.status = vi.fn().mockReturnValue(anyResponse);
            anyResponse.send = vi.fn();
    
            await controller.save(anyRequest, anyResponse);
    
            service.verify(x => x.save(TypeMoq.It.is<SaveTodoArg>(x => x.completed == false && x.description == 'todo')), TypeMoq.Times.once());
            expect(anyResponse.status).toHaveBeenCalledWith(201);
            expect(anyResponse.send).toHaveBeenCalled();
        });

        it('should return 400 when description is not provided', async () => {
            service.setup(x => x.save(TypeMoq.It.isAny())).returns(async () => Promise.resolve(Either.left(new Error('description', 'Description is required'))));
            const anyRequest: MockRequest<Request> = createRequest({ body: { completed: false } });
            const anyResponse: MockResponse<Response> = createResponse();
            anyResponse.status = vi.fn().mockReturnValue(anyResponse);
            anyResponse.send = vi.fn();
    
            await controller.save(anyRequest, anyResponse);
    
            expect(anyResponse.status).toHaveBeenCalledWith(400);
            expect(anyResponse.send).toHaveBeenCalledWith(new Error('description', 'Description is required'));
        });

        it('should return 400 when completed is not provided', async () => {
            service.setup(x => x.save(TypeMoq.It.isAny())).returns(async () => Promise.resolve(Either.left(new Error('completed', 'Completed is required'))));
            const anyRequest: MockRequest<Request> = createRequest({ body: { Description: 'a description' } });
            const anyResponse: MockResponse<Response> = createResponse();
            anyResponse.status = vi.fn().mockReturnValue(anyResponse);
            anyResponse.send = vi.fn();
    
            await controller.save(anyRequest, anyResponse);
    
            expect(anyResponse.status).toHaveBeenCalledWith(400);
            expect(anyResponse.send).toHaveBeenCalledWith(new Error('completed', 'Completed is required'));
        });
    });
});