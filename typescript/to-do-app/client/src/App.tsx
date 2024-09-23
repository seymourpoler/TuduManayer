import React, { Component } from 'react';
import logo from './logo.svg';
import { TodoPresenter, createTodoPresenter } from './TodoPresenter';
import { Todo } from './Todo';

interface AppState {
  todos: Todo[];
  description: string;
}

class App extends Component<{}, AppState> {
  private presenter: TodoPresenter;

  constructor(props: any) {
    super(props);
    this.state = {
      todos: [],
      description: ''
    };
    
    this.presenter = createTodoPresenter(this);
  }

  componentDidMount(): void {
      this.presenter.findTodos();
  }

  public showTodos(todos: Todo[]): void {
    this.setState({ todos });
  }

  public cleanDescription(): void {
    this.setState({ description: '' });
  }

  onCreateTodoHandler = async (): Promise<void> => {
    await this.presenter.create(this.state.description);

  };

  onChangeHandler = (event: React.ChangeEvent<HTMLInputElement>): void => {
      this.setState({ description: event.target.value });
  };  

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <label>create a to-do</label>
          <input type="text" value={this.state.description} onChange={this.onChangeHandler} />
          <button onClick={this.onCreateTodoHandler}>create</button>

          <ul>
            {this.state.todos.map(todo => (
              <li key={todo.id}>{todo.description}</li>
            ))}
          </ul>
        </header>
      </div>
    );
  }
}

export default App;
