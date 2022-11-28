import React  from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const AttackType = () =>{

    const { register } = useFormContext(); // retrieve all hook methods

    return (
      <div>
        <FormLabel>Attack: </FormLabel>
        <br/>
        <FormControl as="select" {...register("attackType")} aria-label="attackType" >
            <option>---</option>
            <option value="0">Melee</option>
            <option value="1">Ranged</option>
        </FormControl>
      </div>
    );
  }

