import React, { useState } from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const Duration = () =>{
    const { register, watch } = useFormContext(); // retrieve all hook methods
    const formValues = watch();

    return (
      <div>
        <FormLabel>Duration</FormLabel>
        <br/>
        <FormControl as="select" {...register("duration_type")} aria-label="duration_type" >
            <option>---</option>
            <option value="0">Instantaneous</option>
            <option value="1">UntilDispelled</option>
            <option value="2">Special</option>
            <option value="3">Time</option>
            <option value="4">UntilDispelledOrTriggered</option>
        </FormControl>
        {formValues.duration_type!=="---" && <FormControl type="text" {...register("duration_time")} placeholder="Time HH:MM:SS.."/> }

      </div>
    );
  }

