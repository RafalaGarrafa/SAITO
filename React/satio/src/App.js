import React from 'react';
import {BrowserRouter as Router, Route} from "react-router-dom"
import ClassComponent from './components/ClassComponent';
import FunctionalComponent from './components/FunctionalComponent';
import { formatMs } from '@material-ui/core';

import Index from './components/Index';
import UsersIndex from './components/users/Index'

function App() {
  return (
    <Router>

      <Route exact path = '/' component = {Index}></Route>
      <Route exact path = '/Index' component = {Index}></Route>
      <Route exact path = '/users' component = {UsersIndex}></Route>


    </Router>
  );
}


export default App;
