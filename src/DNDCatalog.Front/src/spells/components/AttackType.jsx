import React  from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const AttackType = () =>{

    const { register } = useFormContext(); // retrieve all hook methods

    return (
      <div>
        <FormLabel>Атака: </FormLabel>
        <br/>
        <FormControl as="select" {...register("attackType")} aria-label="attackType" >
            <option value="---">🐖💨🤷‍♀️🤷‍♂️</option>
            <option value="0">Рукопашна</option>
            <option value="1">Далекосяжна</option>
        </FormControl>
      </div>
    );
  }

