import React from 'react';
import { FormControl, FormLabel} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const DamageType = () =>{
    const { register } = useFormContext(); // retrieve all hook methods

    return (
      <div>
        <FormLabel>Damage Type: </FormLabel>
        <br/>
        <FormControl as="select" {...register("damageType")} aria-label="damageType" >
            <option>---</option>
            <option value="1">Acid</option>
            <option value="2">Bludgeoning</option>
            <option value="3">Cold</option>
            <option value="4">Fire</option>
            <option value="5">Force</option>
            <option value="6">Lightning</option>
            <option value="7">Necrotic</option>
            <option value="8">Piercing</option>
            <option value="9">Poison</option>
            <option value="10">Psychic</option>
            <option value="11">Radiant</option>
            <option value="12">Slashing</option>
            <option value="13">Thunder</option>
        </FormControl>
      </div>
    );
  }

