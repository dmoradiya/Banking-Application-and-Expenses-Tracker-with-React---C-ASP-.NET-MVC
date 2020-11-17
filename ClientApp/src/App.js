import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from "react-router-dom";
import { Home } from './components/Home';
import { LandingPage } from './components/LandingPage';
import { CreateClient } from './components/CreateClient';
import { CreateAccount } from './components/CreateAccount';
import { ViewTransaction } from './components/ViewTransactions';
import './custom.css'


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Router>
        <Route exact path='/' component={Home} />
        <Route exact path='/landing-page' component={LandingPage} />
        <Route exact path='/create-client' component={CreateClient} />
        <Route exact path='/create-account' component={CreateAccount} />
        <Route exact path='/view-transaction' component={ViewTransaction} />
      </Router>
    );
  }
}
