import * as TypeMoq from "typemoq";
import { Request, Response } from 'express';
import { createRequest, createResponse, MockRequest, MockResponse } from 'node-mocks-http';
import { describe, beforeEach, it, expect, vi } from "vitest";
import { DeleteTodoController } from "../../../src/infra/http/DeleteTodoController";
import { PostgresDeleteTodoRepository } from "../../../src/infra/database/PostgresDeleteTodoRepository";

describe('DeleteTodoController', () => {
    let repository: TypeMoq.IMock<PostgresDeleteTodoRepository>;
    let controller: DeleteTodoController;

    describe('When deleting a todo is requested', () => {
        beforeEach(() => {
            repository = TypeMoq.Mock.ofType<PostgresDeleteTodoRepository>();
            controller = new DeleteTodoController(repository.object);
        });

        it('should delete a todo', async () => {
            const anyId = 14287;
            const anyRequest: MockRequest<Request> = createRequest({ body: { id: anyId } });
            const anyResponse: MockResponse<Response> = createResponse();
            anyResponse.status = vi.fn().mockReturnValue(anyResponse);
            anyResponse.send = vi.fn();

            await controller.delete(anyRequest, anyResponse);

            repository.verify(x => x.delete(anyId), TypeMoq.Times.once());
            expect(anyResponse.status).toHaveBeenCalledWith(200);
            expect(anyResponse.send).toHaveBeenCalled();
        });
    });
});