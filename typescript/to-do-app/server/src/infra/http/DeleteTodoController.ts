import { Request, Response } from 'express';
import { PostgresDeleteTodoRepository } from "../database/PostgresDeleteTodoRepository";

export class DeleteTodoController{
    constructor(private readonly repository: PostgresDeleteTodoRepository) {}

    public async delete(request: Request, response: Response): Promise<void> {
        const { id } = request.body;
        
        await this.repository.delete(id);

        response.status(200);
        response.setHeader('Content-Type', 'application/json');
        response.send();
    }
}