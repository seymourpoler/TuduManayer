import { describe, beforeEach,  it, expect } from "vitest";
import * as TypeMoq from "typemoq";
import { Either } from "@leanmind/monads";
import { CreateTodoService } from "../../src/application/CreateTodoService";
import { PostgresSaveTodoRepository } from "../../src/infra/database/PostgresSaveTodoRepository";
import { Error } from "../../src/domain/Error";
import { CreateTodoArg } from "../../src/application/CreateTodoArgs";

describe('Create Todo Service should', () => {
    let repository: TypeMoq.IMock<PostgresSaveTodoRepository>;
    let service: CreateTodoService;

    beforeEach(() => {
        repository = TypeMoq.Mock.ofType<PostgresSaveTodoRepository>();
        service = new CreateTodoService(repository.object);
    });

    it('should return error when description is null', async () => {
        const args = new CreateTodoArg(null, false);

        const result = await service.create(args);

        repository.verify(r => r.save(TypeMoq.It.isAny()), TypeMoq.Times.never());
        expect(result).toEqual(Either.left(new Error('description', 'Description is required')));
    });

    it('should return error when description is undefined', async () => {
        const args = new CreateTodoArg(undefined, false);

        const result = await service.create(args);

        repository.verify(r => r.save(TypeMoq.It.isAny()), TypeMoq.Times.never());
        expect(result).toEqual(Either.left(new Error('description', 'Description is required')));
    });

    it('should return error when completed is null', async () => {
        const args = new CreateTodoArg('description', null);

        const result = await service.create(args);

        repository.verify(r => r.save(TypeMoq.It.isAny()), TypeMoq.Times.never());
        expect(result).toEqual(Either.left(new Error('completed', 'Completed is required')));
    });

    it('should return error when completed is undefined', async () => {
        const args = new CreateTodoArg('description', undefined);

        const result = await service.create(args);

        repository.verify(x => x.save(TypeMoq.It.isAny()), TypeMoq.Times.never());
        expect(result).toEqual(Either.left(new Error('completed', 'Completed is required')));
    });

    it('should create a user', async () => {
        const args = new CreateTodoArg('description', false);

        const result = await service.create(args);

        repository.verify(x => x.save(TypeMoq.It.isAny()), TypeMoq.Times.once());
        result.match(
            todo => expect(todo).toBeNull(),
            error => expect(error).toBeNull()
        );
    });
});