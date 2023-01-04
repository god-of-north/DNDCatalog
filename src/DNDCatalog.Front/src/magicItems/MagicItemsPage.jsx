import React from 'react';
import { MagicItemsList } from './components/MagicItemsList';
import {Helmet} from "react-helmet";

export const MagicItemsPage = () => {

    return (
      <div>
        <Helmet>
          <title>Магічні предмети / DND.Catalog</title>
        </Helmet>
        <h1>🔮Магічні предмети</h1>
        <MagicItemsList/>
      </div>
    );
}
