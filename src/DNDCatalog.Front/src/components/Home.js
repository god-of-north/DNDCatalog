import React, { Component } from 'react';
import {Helmet} from "react-helmet";

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <Helmet>
          <title>DND.Catalog</title>
        </Helmet>
        <h1>Вітаю друже!</h1>
        <p>Сайт під чарами розробки...</p>
        <p>Лише відважний шукач пригод зможе допомогти перекласти стародавні манускрипти і зняти чари...</p>
        <a href="https://t.me/kyiv_blues">🧙‍♂️Прийняти виклик!</a>
      </div>
    );
  }
}
