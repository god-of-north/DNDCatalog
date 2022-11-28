import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import { Layout } from './components/Layout';

import './custom.css';
import { Home } from "./components/Home";
import { SpellsPage } from './spells/SpellsPage';
import { SpellEditPage } from './spells/SpellEditPage';
import { LoginPage } from './auth/LoginPage';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Routes>
          <Route path='/' element={<Home/>} />
          <Route path='/spells/edit/:spellId' element={<SpellEditPage/>} />
          <Route path='/spells' element={<SpellsPage/>} exact />
          <Route path='/login' element={<LoginPage/>} exact />
        </Routes>
      </Layout>
    );
  }
}
