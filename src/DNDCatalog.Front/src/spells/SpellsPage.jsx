import React from 'react';
import { SpellList } from './components/SpellList';
import {Helmet} from "react-helmet";

export const SpellsPage = () => {

    return (
      <div>
        <Helmet>
          <title>Заклинання / DND.Catalog</title>
        </Helmet>
        <h1>✨Заклинання</h1>
        <SpellList/>
      </div>
    );
}
