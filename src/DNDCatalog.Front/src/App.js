import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import { Layout } from './components/Layout';

import './custom.css';
import { Home } from "./components/Home";
import { SpellsPage } from './spells/SpellsPage';
import { SpellEditPage } from './spells/SpellEditPage';
import { LoginPage } from './auth/LoginPage';
import { applyLoginPolicy } from './auth/LoginPolicies'

import './App.scss'
import { MagicItemsPage } from './magicItems/MagicItemsPage';
import { MagicItemEditPage } from './magicItems/MagicItemEditPage';

export default class App extends Component {
  static displayName = App.name;
  
  constructor(props) {
    super(props);

    applyLoginPolicy();
  }


  render() {
    return (
      <Layout>
        <Routes>
          <Route path='/' element={<Home/>} />

          <Route path='/spells/edit/:spellName' element={<SpellEditPage/>} />
          <Route path='/spells' element={<SpellsPage/>} exact />

          <Route path='/magic-items/edit/:magicItemId' element={<MagicItemEditPage/>} />
          <Route path='/magic-items' element={<MagicItemsPage/>} exact />

          <Route path='/login' element={<LoginPage/>} exact />
        </Routes>
      </Layout>
    );
  }
}
