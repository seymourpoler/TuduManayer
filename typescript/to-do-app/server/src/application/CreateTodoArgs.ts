export class CreateTodoArg {
    constructor(
        public readonly description: string,
        public readonly completed: boolean
    ){}
}