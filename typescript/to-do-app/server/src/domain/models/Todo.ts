export class Todo{
    public readonly id: number|null;
    public readonly description: string;
    public readonly completed: boolean;
    public readonly created: Date;

    private constructor(id: number|null, description: string, completed: boolean, created: Date) {
        this.id = id;
        this.description = description;
        this.completed = completed;
        this.created = created;
}

    public static createSafe(description: string, completed: boolean) : Todo {
        return new Todo(null, description, completed, new Date());
    }

    public static createUnsafe(id: number, description: string, completed: boolean, created: Date) : Todo{
        return new Todo(id, description, completed, new Date(created));
    }
}