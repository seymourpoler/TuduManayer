import Express from 'express'
import { ConnectionFactory } from './database/ConnectionFactory';
import { Configuration } from './database/Configuration';
import { PostgresFindTodosRepository } from '../infra/database/PostgresFindTodosRepository';
import { PostgresSaveTodoRepository } from '../infra/database/PostgresSaveTodoRepository';
import { FindTodosController } from '../infra/http/FindTodosController';
import { SaveTodoController } from './http/SaveTodoController';
import { DeleteTodoController } from './http/DeleteTodoController';
import { SaveTodoService } from '../application/SaveTodoService';
import { PostgresDeleteTodoRepository } from './database/PostgresDeleteTodoRepository';

const connectionFactory = new ConnectionFactory(new Configuration);
const findRepository = new PostgresFindTodosRepository(connectionFactory);
const findController = new FindTodosController(findRepository);
const saveRepository = new PostgresSaveTodoRepository(connectionFactory);
const saveTodoService = new SaveTodoService(saveRepository);
const saveController = new SaveTodoController(saveTodoService);
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
    return saveController.save(req, res);
});

app.delete('/api/todos/:id', (req, res) => {
    return deleteController.delete(req, res);
});

export default app;