export class SaveTodoArg{
    constructor(
        public readonly description: string,
        public readonly completed: boolean
    ){}
}