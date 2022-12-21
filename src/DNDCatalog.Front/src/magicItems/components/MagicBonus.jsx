import React from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';

import { useFormContext } from "react-hook-form";


export const MagicBonus = () =>{

  const { register } = useFormContext(); // retrieve all hook methods

  return (
      <div>
        <FormLabel>Магічний бонус: </FormLabel>
        <br/>
        <FormControl as="select" {...register("magicBonus")} aria-label="magictItem-magicBonus" >
            <option value="---">🐖💨🤷‍♀️🤷‍♂️</option>
            <option value="1">+1</option>
            <option value="2">+2</option>
            <option value="3">+3</option>
        </FormControl>
      </div>
    );
  }

