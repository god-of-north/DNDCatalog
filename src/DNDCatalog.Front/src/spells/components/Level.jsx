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
            <option value="0">Заговор</option>
            <option value="1">1-й</option>
            <option value="2">2-й</option>
            <option value="3">3-й</option>
            <option value="4">4-й</option>
            <option value="5">5-й</option>
            <option value="6">6-й</option>
            <option value="7">7-й</option>
            <option value="8">8-й</option>
            <option value="9">9-й</option>
            <option value="10">10-й</option>
            <option value="11">11-й</option>
            <option value="12">12-й</option>
            <option value="13">13-й</option>
            <option value="14">14-й</option>
            <option value="15">15-й</option>
            <option value="16">16-й</option>
            <option value="17">17-й</option>
            <option value="18">18-й</option>
            <option value="19">19-й</option>
            <option value="20">20-й</option>
        </FormControl>
      </div>
    );
  }

