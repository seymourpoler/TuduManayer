import { ConnectionFactory } from "./ConnectionFactory";

export class PostgresDeleteTodoRepository {
    constructor(private readonly connectionFactory: ConnectionFactory) {}
        
    public async delete(id: Number): Promise<void> {
        const sql = 'DELETE FROM public.Todos WHERE Id = $1';
        const connection = this.connectionFactory.create();
        await connection.query(sql, [id]);
        await connection.end();
    }
}