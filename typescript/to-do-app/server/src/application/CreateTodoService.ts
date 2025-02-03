import { Either} from '@leanmind/monads';
import { Error } from '../domain/Error';
import { Todo } from '../domain/Todo';
import { PostgresSaveTodoRepository } from '../infra/database/PostgresSaveTodoRepository';
import { CreateTodoArg } from './CreateTodoArgs';

export class CreateTodoService {
    constructor(private readonly repository: PostgresSaveTodoRepository) {}

    public async create(arg: CreateTodoArg): Promise<Either<Error, null>> {
        return Todo
            .create(arg.description, arg.completed)
            .match(
                async todo =>{
                    await this.repository.save(todo);
                    return Either.right(null);
                },
                error => Either.left(error)
        );
    }
}