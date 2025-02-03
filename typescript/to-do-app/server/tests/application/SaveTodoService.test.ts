import { describe, beforeEach,  it, expect } from "vitest";
import * as TypeMoq from "typemoq";
import { Either } from "@leanmind/monads";
import { SaveTodoService } from "../../src/application/SaveTodoService";
import { PostgresSaveTodoRepository } from "../../src/infra/database/PostgresSaveTodoRepository";
import { Error } from "../../src/domain/Error";
import { SaveTodoArg } from "../../src/application/SaveTodoArgs";

describe('SaveTodoService', () => {
    let repository: TypeMoq.IMock<PostgresSaveTodoRepository>;
    let service: SaveTodoService;

    beforeEach(() => {
        repository = TypeMoq.Mock.ofType<PostgresSaveTodoRepository>();
        service = new SaveTodoService(repository.object);
    });

    describe('When saving a to-do is requested', () => {
        it('should return 400 when description is null', async () => {
            const args = new SaveTodoArg(null, false);
            
            const result = await service.save(args);

            repository.verify(r => r.save(TypeMoq.It.isAny()), TypeMoq.Times.never());
            expect(result).toEqual(Either.left(new Error('description', 'Description is required')));
        });

        it('should return 400 when description is undefined', async () => {
            const args = new SaveTodoArg(undefined, false);
            
            const result = await service.save(args);

            repository.verify(r => r.save(TypeMoq.It.isAny()), TypeMoq.Times.never());
            expect(result).toEqual(Either.left(new Error('description', 'Description is required')));
        });

        it('should return 400 when completed is null', async () => {
            const args = new SaveTodoArg('description', null);
            
            const result = await service.save(args);

            repository.verify(r => r.save(TypeMoq.It.isAny()), TypeMoq.Times.never());
            expect(result).toEqual(Either.left(new Error('completed', 'Completed is required')));
        });

        it('should return 400 when completed is undefined', async () => {
            const args = new SaveTodoArg('description', undefined);
            
            const result = await service.save(args);

            repository.verify(r => r.save(TypeMoq.It.isAny()), TypeMoq.Times.never());
            expect(result).toEqual(Either.left(new Error('completed', 'Completed is required')));
        });

        it('should save a user', async () => {
            const args = new SaveTodoArg('description', false);
            
            const result = await service.save(args);

            repository.verify(r => r.save(TypeMoq.It.isAny()), TypeMoq.Times.once());
            expect(result).toEqual(Either.right(null));
        });
    });
});