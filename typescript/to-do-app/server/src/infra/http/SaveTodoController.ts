import { Request, Response } from 'express';
import { SaveTodoService } from '../../application/SaveTodoService';
import { SaveTodoArg } from '../../application/SaveTodoArgs';

export class SaveTodoController {
    constructor(private readonly service: SaveTodoService) {}
    
    public async save(request: Request, response: Response): Promise<void> {
        const { description, completed } = request.body;

        const result = await this.service.save(new SaveTodoArg(description, completed));
        
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