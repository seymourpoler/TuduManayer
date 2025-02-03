import { describe, beforeEach, it, afterEach, expect } from "vitest";
import { PostgresFindTodosRepository } from "../../../src/infra/database/PostgresFindTodosRepository";
import { PostgresSaveTodoRepository } from "../../../src/infra/database/PostgresSaveTodoRepository";
import { ConnectionFactory } from "../../../src/infra/database/ConnectionFactory";
import { Configuration } from "../../../src/infra/database/Configuration";
import { DataBase } from "./DataBase";
import { Todo } from "../../../src/domain/Todo";

describe("PostgresSaveTodosRepository", () => {
    let connectionFactory: ConnectionFactory;
    let findTodosRepository: PostgresFindTodosRepository;
    let saveTodoRepository: PostgresSaveTodoRepository;
    let database: DataBase;


    describe("when finding todos are requested", () => {
        beforeEach(async () => {
            connectionFactory = new ConnectionFactory(new Configuration());
            findTodosRepository = new PostgresFindTodosRepository(connectionFactory);
            saveTodoRepository = new PostgresSaveTodoRepository(connectionFactory);
            database = new DataBase(connectionFactory);
            await database.clear();
        });

        it("should return a list of todos", async () => {
            const aTodo = Todo.createSafe('description', false);
            
            saveTodoRepository.save(aTodo);
    
            const todos = await findTodosRepository.find();
            expect(todos).toHaveLength(1);
            expect(todos[0].description).toBe('description');
            expect(todos[0].completed).toBeFalsy();
        });
    
        afterEach(async () => {
            await database.clear();
        });
    });
});