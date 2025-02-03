import request from 'supertest';
import { describe, expect, beforeAll, afterAll, beforeEach, afterEach, it } from 'vitest';
import { Server } from 'http';
import app from '../../src/infra/app';
import { ConnectionFactory } from '../../src/infra/database/ConnectionFactory';
import { Configuration } from '../../src/infra/database/Configuration';
import { PostgresSaveTodoRepository } from '../../src/infra/database/PostgresSaveTodoRepository';
import { Todo } from '../../src/domain/Todo';
import { DataBase } from './database/DataBase';

describe('app',() => {
  let connectionFactory: ConnectionFactory;
  let saveRepository: PostgresSaveTodoRepository;
  let database: DataBase;
  let server: Server;

  beforeAll(async () => {
    server = app.listen(4000);
  });
  
  beforeEach(async () => {
    connectionFactory = new ConnectionFactory(new Configuration());
    saveRepository = new PostgresSaveTodoRepository(connectionFactory);
    database = new DataBase(connectionFactory);
    await database.clear();
  });

  describe('GET /ping', () => {
    it('should return pong', async () => {
      const response = await request(server).get('/ping');
      
      expect(response.status).toBe(200);
      expect(response.text).toBe('pong!');
    });
  });

  describe('GET /api/todos', () => {
    it('should return all todos', async () => {
      await saveRepository.save(Todo.createSafe('error', false));
  
      const response = await request(server).get('/api/todos').expect(200);
      
      expect(response.status).toBe(200);
      expect(response.body.length).toBe(1);
      expect(response.body[0].description).toBe('error');
      expect(response.body[0].completed).toBeFalsy();
      expect(response.body[0].created).toBeDefined();     
    });
  });

  describe('POST /api/todos', () => {
    it('should create a new todo', async () => {
      const response = await request(server)
        .post('/api/todos')
        .send({ description: 'error', completed: false });
      
      expect(response.status).toBe(201);
    });
  });

  describe('DELETE /api/todos', () => {
    it('should delete a todo', async () => {
      const todo = Todo.createSafe('error', false); 
      await saveRepository.save(todo);
  
      const response = await request(server).delete(`/api/todos/${todo.id}`);
      
      expect(response.status).toBe(200);
    });
  });

  afterAll(async () => {
    server.close();
  });

  afterEach(async () => {
    await database.clear();
  });

});  

