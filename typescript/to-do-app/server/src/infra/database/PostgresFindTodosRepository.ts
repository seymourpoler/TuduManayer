import { Todo } from '../../domain/Todo';
import { ConnectionFactory } from './ConnectionFactory';

export class PostgresFindTodosRepository {
  constructor(private readonly connectionFactory: ConnectionFactory) {}

  public async find(): Promise<Todo[]> {
    const sql = 'SELECT id, description, completed, created FROM public.todos';
    const connection = this.connectionFactory.create();
    const result = await connection.query(sql);
    await connection.end();
    return result.rows
      .map((row: any) => 
        Todo.createUnsafe(row.id, row.description, row.completed, new Date(row.created))
      );
  }
}