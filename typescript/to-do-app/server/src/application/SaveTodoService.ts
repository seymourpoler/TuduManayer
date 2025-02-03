import { Either} from '@leanmind/monads';
import { Error } from '../domain/Error';
import { Todo } from '../domain/Todo';
import { PostgresSaveTodoRepository } from '../infra/database/PostgresSaveTodoRepository';
import { SaveTodoArg } from './SaveTodoArgs';

export class SaveTodoService {
    constructor(private readonly repository: PostgresSaveTodoRepository) {}

    public async save(arg: SaveTodoArg): Promise<Either<Error, null>> {
        
        if(!arg.description) {
            return Either.left(new Error('description', 'Description is required')); 
        }

        if(arg.completed == null || arg.completed == undefined) {
            return Either.left(new Error('completed', 'Completed is required')); 
        }
        
        await this.repository.save(Todo.createSafe(arg.description, arg.completed));
        return Either.right(null);
    }
}