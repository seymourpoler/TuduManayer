import { Request, Response } from 'express';
import { PostgresFindTodosRepository } from "../database/PostgresFindTodosRepository";

export class FindTodosController {
    constructor(private readonly findTodosRepository: PostgresFindTodosRepository) { }
    
    public async find(request: Request, response: Response): Promise<Response> {
        const todos = await this.findTodosRepository.find();
        response.statusCode = 200;
        response.setHeader('Content-Type', 'application/json');
        response.json(todos);
        return response;
    }
}