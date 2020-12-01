import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from "react-router-dom";
import { Home } from './components/Home';
import { LandingPage } from './components/LandingPage';
import { CreateClient } from './components/CreateClient';
import { AddAccount } from './components/AddAccount';
import { CreateAccount } from './components/CreateAccount';
import { ViewTransactions } from './components/ViewTransactions';
import { CreateDeposit } from './components/CreateDeposit';
import { CreateWithdraw } from './components/CreateWithdraw';
import { PayBills } from './components/PayBills';
import { CloseAccount } from './components/CloseAccount';
import { ArchiveNotification } from './components/ArchiveNotification';
import { CreateNotification } from './components/CreateNotification';
import './custom.css'
import { Footer } from './components/Footer';
import { ViewExpenses } from './components/ViewExpenses';
import { FAQ } from './components/FAQ';
import { TransactionNotification } from './components/TransactionNotification';



export default class App extends Component {

  render () {
    return (
      <Router>
        <Route exact path='/' component={Home} />
        <Route exact path='/landing-page' component={LandingPage} />
        <Route exact path='/create-client' component={CreateClient} />
        <Route exact path='/add-account' component={AddAccount} />
        <Route exact path='/create-account' component={CreateAccount} />
        <Route exact path='/view-transactions' component={ViewTransactions} />
        <Route exact path='/create-deposit' component={CreateDeposit} />
        <Route exact path='/create-withdraw' component={CreateWithdraw} />
        <Route exact path='/pay-bills' component={PayBills} />
        <Route exact path='/close-account' component={CloseAccount} />
        <Route exact path='/archive-notification' component={ArchiveNotification} />
        <Route exact path='/create-notification' component={CreateNotification} />
        <Route exact path='/transaction-notification' component={TransactionNotification} />
        <Route exact path='/view-expenses' component={ViewExpenses} />
        <Route exact path='/faq' component={FAQ} />

        <Footer />
      </Router>
    );
  }
}
