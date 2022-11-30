import React, { useState } from 'react';
import { FormControl, FormLabel} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const CastingTime = () =>{
    const { register, watch } = useFormContext(); // retrieve all hook methods
    const formValues = watch();

    return (
      <div>
        <FormLabel>Час виконання</FormLabel>
        <br/>

        <FormControl as="select" {...register("castingTime_isAction")} aria-label="action-type" >
            <option value="action">Вчинок</option>
            <option value="time">Час</option>
        </FormControl>

        {formValues.castingTime_isAction==="time" &&  <FormControl {...register("castingTime_time")} type="text" placeholder='Час у форматі HH:MM:SS..'/> }

        {formValues.castingTime_isAction==="action" &&
        <div>
          <FormControl {...register("castingTime_actionTime_count")} type="number" placeholder="Кількість..."/>
          <FormControl as="select" {...register("castingTime_actionTime_actionType")} aria-label="action-type" >
              <option value="---">🐖💨🤷‍♀️🤷‍♂️</option>
              <option value="0">Вчинок</option>
              <option value="1">Бонусний вчинок</option>
              <option value="2">Вільний вчинок</option>
              <option value="3">Реакція</option>
          </FormControl>
        </div>
        }

      </div>
    );
}

