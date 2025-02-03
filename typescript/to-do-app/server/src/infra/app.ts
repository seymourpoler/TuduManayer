import Express from 'express'
import { ConnectionFactory } from './database/ConnectionFactory';
import { Configuration } from './database/Configuration';
import { PostgresFindTodosRepository } from './database/PostgresFindTodosRepository';
import { PostgresSaveTodoRepository } from './database/PostgresSaveTodoRepository';
import { FindTodosController } from './http/FindTodosController';
import { CreateTodoController } from './http/CreateTodoController';
import { DeleteTodoController } from './http/DeleteTodoController';
import { CreateTodoService } from '../application/CreateTodoService';
import { PostgresDeleteTodoRepository } from './database/PostgresDeleteTodoRepository';

const connectionFactory = new ConnectionFactory(new Configuration);
const findRepository = new PostgresFindTodosRepository(connectionFactory);
const findController = new FindTodosController(findRepository);
const saveRepository = new PostgresSaveTodoRepository(connectionFactory);
const createTodoService = new CreateTodoService(saveRepository);
const createController = new CreateTodoController(createTodoService);
const deleteRepository = new PostgresDeleteTodoRepository(connectionFactory);
const deleteController = new DeleteTodoController(deleteRepository);

const app = Express()

app.use(Express.json())
app.use(Express.urlencoded({ extended: false }))


app.get('/ping', (req, res) => {
    res.status(200);
    res.send('pong!')
});

app.get('/api/todos', (req, res) => {
    return findController.find(req, res);
});

app.post('/api/todos', (req, res) => {
    return createController.create(req, res);
});

app.delete('/api/todos/:id', (req, res) => {
    return deleteController.delete(req, res);
});

export default app;