import React from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';

import { useFormContext } from "react-hook-form";


export const Level = () =>{

  const { register } = useFormContext(); // retrieve all hook methods

  return (
      <div>
        <FormLabel>Level: </FormLabel>
        <br/>
        <FormControl as="select" {...register("level")} aria-label="spell-level" >
            <option value="0">Cantrip</option>
            <option value="1">1st</option>
            <option value="2">2nd</option>
            <option value="3">3rd</option>
            <option value="4">4th</option>
            <option value="5">5th</option>
            <option value="6">6th</option>
            <option value="7">7th</option>
            <option value="8">8th</option>
            <option value="9">9th</option>
            <option value="10">10th</option>
            <option value="11">11th</option>
            <option value="12">12th</option>
            <option value="13">13th</option>
            <option value="14">14th</option>
            <option value="15">15th</option>
            <option value="16">16th</option>
            <option value="17">17th</option>
            <option value="18">18th</option>
            <option value="19">19th</option>
            <option value="20">20th</option>
        </FormControl>
      </div>
    );
  }

