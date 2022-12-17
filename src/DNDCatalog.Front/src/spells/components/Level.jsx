import React from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';

import { useFormContext } from "react-hook-form";


export const Level = () =>{

  const { register } = useFormContext(); // retrieve all hook methods

  return (
      <div>
        <FormLabel>Рівень: </FormLabel>
        <br/>
        <FormControl as="select" {...register("level")} aria-label="spell-level" >
            <option value="0">Заговір</option>
            <option value="1">1-й</option>
            <option value="2">2-й</option>
            <option value="3">3-й</option>
            <option value="4">4-й</option>
            <option value="5">5-й</option>
            <option value="6">6-й</option>
            <option value="7">7-й</option>
            <option value="8">8-й</option>
            <option value="9">9-й</option>
        </FormControl>
      </div>
    );
  }

