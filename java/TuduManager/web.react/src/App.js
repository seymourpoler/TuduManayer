import React, { Component } from 'react';
import './App.css';
import Home from './Home';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { UserView } from './user/UserView';
import { ManageTodoView } from './todo/manage/ManageTodoView';
import { CreateTodoView } from './todo/create/CreateTodoView';
import { EditTodoView } from './todo/edit/EditTodoView';
import { UserSignUpView } from "./user/signup/UserSignUpView";

class App extends Component {
  render() {
    return (
      <Router>
        <Switch>
          <Route path='/' exact={true} component={Home}/>
          <Route path='/users' exact={true} component={UserView}/>
          <Route path='/manage' exact={true} component={ManageTodoView}/>
          <Route path='/create' exact={true} component={CreateTodoView}/>
          <Route path='/todos/:todoId' exact={true} component={EditTodoView}/>
          <Route path='/users/signup' exact={true} component={UserSignUpView}/>
        </Switch>
      </Router>
    )
  }
}

export default App;