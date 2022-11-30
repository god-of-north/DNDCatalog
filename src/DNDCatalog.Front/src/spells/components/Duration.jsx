import React, { useState } from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const Duration = () =>{
    const { register, watch } = useFormContext(); // retrieve all hook methods
    const formValues = watch();

    return (
      <div>
        <FormLabel>Тривалість</FormLabel>
        <br/>
        <FormControl as="select" {...register("duration_type")} aria-label="duration_type" >
            <option value="---">🐖💨🤷‍♀️🤷‍♂️</option>
            <option value="0">Миттєва</option>
            <option value="1">Поки не розвіється</option>
            <option value="2">Особлива</option>
            <option value="3">Має час дії</option>
            <option value="4">Поки не розвіється, або не спрацює</option>
        </FormControl>
        {formValues.duration_type!=="---" && <FormControl type="text" {...register("duration_time")} placeholder="Час у форматі HH:MM:SS.."/> }

      </div>
    );
  }

