import { TodoService, createTodoService } from './TodoService';
import App from './App';
import { Todo } from './Todo';

export class TodoPresenter {
    constructor(private readonly view: App, private readonly service: TodoService) {}

    public async findTodos(): Promise<void> {
        const todos = await this.service.find();
        this.view.showTodos(todos);
    }

    public async create(description: string): Promise<void> {
        const todo: Todo = { id:0, description, completed: false };
        await this.service.create(todo);
        this.view.cleanDescription();
        await this.findTodos();
    }

    public async delete(id: number): Promise<void> {
        await this.service.delete(id);
        await this.findTodos();
    }
}

export function createTodoPresenter(view: App): TodoPresenter {
    const service = createTodoService();
    return new TodoPresenter(view, service);
}