import { Http } from "./Http";
import { Todo } from "./Todo";

export class TodoService {
    constructor(private http: Http) {}

    public async find(): Promise<Todo[]> {
        const todos = await this.http.get('api/todos');
        return todos.map((todo: any) =>  {
            const aTodo: Todo = {
            id : todo.id, 
            description : todo.description, 
            completed : todo.completed
            };
            return aTodo;   
        });
    }

    public async create(todo: Todo): Promise<void> {
        await this.http.post('api/todos', todo);
    }

    public async delete(id: number): Promise<void> {
        await this.http.delete(`api/todos/${id}`);
    }
}

export function createTodoService(): TodoService {
    const http = new Http();
    return new TodoService(http);
}