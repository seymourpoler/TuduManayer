import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { ManageTodoView } from "./todo/manage/ManageTodoView";
import { CreateTodoView } from "./todo/create/CreateTodoView";

import './custom.css'
import {EditTodoView} from "./todo/edit/EditTodoView";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/manage' component={ManageTodoView} />
        <Route path='/create' component={CreateTodoView} />
        <Route path='/todos/:todoId' component={EditTodoView} />
          
      </Layout>
    );
  }
}
