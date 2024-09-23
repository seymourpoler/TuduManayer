import { describe, beforeEach, afterEach, it, expect } from "vitest";
import { ConnectionFactory } from "../../../src/infra/database/ConnectionFactory";
import { Configuration } from "../../../src/infra/database/Configuration";
import { Todo } from "../../../src/domain/models/Todo";
import { PostgresFindTodosRepository } from "../../../src/infra/database/PostgresFindTodosRepository";
import { PostgresSaveTodoRepository } from "../../../src/infra/database/PostgresSaveTodoRepository";
import { DataBase } from "./DataBase";

describe("PostgresFindTodosRepository", () => {
    let connectionFactory: ConnectionFactory;
    let findRespository: PostgresFindTodosRepository;
    let saveRespository: PostgresSaveTodoRepository;
    let database: DataBase;

    describe("when finding todos are requested", () => {
        beforeEach(async () => {
            connectionFactory = new ConnectionFactory(new Configuration());
            findRespository = new PostgresFindTodosRepository(connectionFactory);
            saveRespository = new PostgresSaveTodoRepository(connectionFactory);
            database = new DataBase(connectionFactory);
            await database.clear();
        });

        it("should return a list of todos", async () => {
            const aTodo = Todo.createSafe("todo 1", false);
            await saveRespository.save(aTodo);
        
            const todos = await findRespository.find();
            
            expect(todos.length).toBe(1);
            expect(todos[0].description).toBe("todo 1");
            expect(todos[0].completed).toBe(false);
        });

        afterEach(async () => {
            await database.clear();
        });
    });

});