import React from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';

import { useFormContext } from "react-hook-form";


export const Rarity = () =>{

  const { register } = useFormContext(); // retrieve all hook methods

  return (
      <div>
        <FormLabel>Рідкість: </FormLabel>
        <br/>
        <FormControl as="select" {...register("rarity")} aria-label="magictItem-rarity" >
            <option value="1">Звичайна</option>
            <option value="2">Не звичайна</option>
            <option value="3">Рідкісний</option>
            <option value="4">Дуже рідкісний</option>
            <option value="5">Легендарний</option>
            <option value="6">Артефакт</option>
            <option value="7">Різна рідкість</option>
            <option value="8">Не визначена</option>
        </FormControl>
      </div>
    );
  }

