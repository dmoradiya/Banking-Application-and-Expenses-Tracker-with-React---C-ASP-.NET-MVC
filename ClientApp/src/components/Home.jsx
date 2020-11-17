import React, { Component } from 'react';
import { Login } from './Login';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <Login/>
      </div>
    );
  }
}
