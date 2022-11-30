import React from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const SavingThrowType = () =>{
    const { register } = useFormContext(); // retrieve all hook methods

    return (
      <div>
        <FormLabel>Кидок рятунку: </FormLabel>
        <br/>
        <FormControl as="select" {...register("savingThrowType")} aria-label="savingThrowType" >
            <option value="---">🐖💨🤷‍♀️🤷‍♂️</option>
            <option value="0">Вправність</option>
            <option value="1">Статура</option>
            <option value="2">Сила</option>
            <option value="3">Мудрість</option>
            <option value="4">Харизма</option>
            <option value="5">Інтелект</option>
        </FormControl>
      </div>
    );
  }

