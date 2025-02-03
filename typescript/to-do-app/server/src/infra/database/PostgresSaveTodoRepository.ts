import { Todo } from "../../domain/Todo";
import { ConnectionFactory } from "./ConnectionFactory";

export class PostgresSaveTodoRepository {
    constructor(private readonly connectionFactory: ConnectionFactory) {}

    public async save(todo: Todo): Promise<void> {
        const sql = 'INSERT INTO public.Todos (Description, Completed, Created) VALUES ($1, $2, $3)';
        const connection = this.connectionFactory.create();
        await connection.query(sql, [todo.description, todo.completed, todo.created]);
        await connection.end();
    }
}