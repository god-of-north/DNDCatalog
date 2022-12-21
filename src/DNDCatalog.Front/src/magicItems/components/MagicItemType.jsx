import React from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';

import { useFormContext } from "react-hook-form";


export const MagicItemType = () =>{

  const { register } = useFormContext(); // retrieve all hook methods

  return (
      <div>
        <FormLabel>Вид предмета: </FormLabel>
        <br/>
        <FormControl as="select" {...register("type")} aria-label="magictItem-type" >
            <option value="1">🥋обладунок</option>
            <option value="2">⚗зілля</option>
            <option value="3">💍кільце</option>
            <option value="4">⚔зброя</option>
            <option value="5">⚚жезл</option>
            <option value="6">📜сувій</option>
            <option value="7">🩼палиця</option>
            <option value="8"> 	🪄чарівна паличка</option>
            <option value="9">🔮чудодійний предмет</option>
            <option value="10">🗡рукопашна зброя</option>
            <option value="11">🏹далекобійна зброя</option>
            <option value="12">🛡щит</option>
            <option value="13">⚒амуніція</option>
        </FormControl>
      </div>
    );
  }

