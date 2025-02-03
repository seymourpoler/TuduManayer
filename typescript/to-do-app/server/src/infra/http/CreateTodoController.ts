import { Request, Response } from 'express';
import { CreateTodoService } from '../../application/CreateTodoService';
import { CreateTodoArg } from '../../application/CreateTodoArgs';

export class CreateTodoController {
    constructor(private readonly service: CreateTodoService) {}
    
    public async create(request: Request, response: Response): Promise<void> {
        const { description, completed } = request.body;

        const result = await this.service.create(new CreateTodoArg(description, completed));
        
        result.match(
            () => {
                response.status(201);
                response.send();
            },
            (error) => {
                response.status(400);
                response.setHeader('Content-Type', 'application/json');
                response.send(error);
            });
    }
}