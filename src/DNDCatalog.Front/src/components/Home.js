import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, advanturer!</h1>
        <p>Welcome to DND.Catalog...</p>
        <ul>
          <li><a href='/spells'>Spells</a></li>
        </ul>
      </div>
    );
  }
}
