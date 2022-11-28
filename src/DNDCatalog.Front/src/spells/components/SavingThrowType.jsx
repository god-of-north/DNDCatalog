import React from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const SavingThrowType = () =>{
    const { register } = useFormContext(); // retrieve all hook methods

    return (
      <div>
        <FormLabel>Saving Throw: </FormLabel>
        <br/>
        <FormControl as="select" {...register("savingThrowType")} aria-label="savingThrowType" >
            <option>---</option>
            <option value="0">Dexterity</option>
            <option value="1">Constitution</option>
            <option value="2">Strength</option>
            <option value="3">Wisdom</option>
            <option value="4">Charisma</option>
            <option value="5">Intelligence</option>
        </FormControl>
      </div>
    );
  }

