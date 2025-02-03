import { describe, it, expect } from "vitest";
import { Todo } from "../../src/domain/Todo";
import { Error } from "../../src/domain/Error";

describe('TODO should', () =>{

    it('return error when description is null', () => {
        const result = Todo.create(null, false);

        result.match(
            todo => expect(todo).toBeNull(),
            error => {
                expect(error).toBeInstanceOf(Error);
                expect(error.fieldId).toEqual('description');
                expect(error.message).toEqual('Description is required');
            }
        );
    });

    it('return error when description is empty', () => {
        const result = Todo.create('', false);

        result.match(
            todo => expect(todo).toBeNull(),
            error => {
                expect(error).toBeInstanceOf(Error);
                expect(error.fieldId).toEqual('description');
                expect(error.message).toEqual('Description is required');
            });
    });

    it('return error when completed is null', () => {
        const result = Todo.create('description', null);

        result.match(
            todo => expect(todo).toBeNull(),
            error => {
                expect(error).toBeInstanceOf(Error);
                expect(error.fieldId).toEqual('completed');
                expect(error.message).toEqual('Completed is required');
            });
    })

    it('return error when completed is undefined', () => {
        const result = Todo.create('description', undefined);

        result.match(
            todo => expect(todo).toBeNull(),
            error => {
                expect(error).toBeInstanceOf(Error);
                expect(error.fieldId).toEqual('completed');
                expect(error.message).toEqual('Completed is required');
            });
    })

    it('create a Todo', ()=>{
        const result = Todo.create('description', false);

        result.match(
            todo => {
                expect(todo).toBeInstanceOf(Todo);
                expect(todo.description).toBe('description');
                expect(todo.completed).toBeFalsy();
                expect(todo.created).not.toBeNull();
            },
            error => expect(error).toBeNull()
        );
    });
});