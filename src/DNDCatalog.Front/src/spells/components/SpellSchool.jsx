import React from 'react';
import { FormControl, FormLabel} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const SpellSchool = () =>{
    const { register } = useFormContext(); // retrieve all hook methods

    return (
      <div>
        <FormLabel>School: </FormLabel>
        <br/>
        <FormControl as="select" {...register("school")} aria-label="school" >
            <option value="1">Abjuration</option>
            <option value="2">Conjuration</option>
            <option value="3">Divination</option>
            <option value="4">Enchantment</option>
            <option value="5">Evocation</option>
            <option value="6">Illusion</option>
            <option value="7">Necromancy</option>
            <option value="8">Transmutation</option>
        </FormControl>
      </div>
    );
  }

