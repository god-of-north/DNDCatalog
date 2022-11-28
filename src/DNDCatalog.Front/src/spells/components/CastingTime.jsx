import React, { useState } from 'react';
import { FormControl, FormLabel} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const CastingTime = () =>{
    const { register, watch } = useFormContext(); // retrieve all hook methods
    const formValues = watch();

    return (
      <div>
        <FormLabel>Casting Time</FormLabel>
        <br/>

        <FormControl as="select" {...register("castingTime_isAction")} aria-label="action-type" >
            <option value="action">Action</option>
            <option value="time">Time</option>
        </FormControl>

        {formValues.castingTime_isAction==="time" &&  <FormControl {...register("castingTime_time")} type="text" placeholder='Time HH:MM:SS..'/> }

        {formValues.castingTime_isAction==="action" &&
        <div>
          <FormControl {...register("castingTime_actionTime_count")} type="number" placeholder="Action's..."/>
          <FormControl as="select" {...register("castingTime_actionTime_actionType")} aria-label="action-type" >
              <option>---</option>
              <option value="0">Action</option>
              <option value="1">BonusAction</option>
              <option value="2">FreeAction</option>
              <option value="3">Reaction</option>
          </FormControl>
        </div>
        }

      </div>
    );
  }

