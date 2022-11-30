import React from 'react';
import { FormControl, FormLabel} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const DamageType = () =>{
    const { register } = useFormContext(); // retrieve all hook methods

    return (
      <div>
        <FormLabel>Вид ушкоджень: </FormLabel>
        <br/>
        <FormControl as="select" {...register("damageType")} aria-label="damageType" >
            <option value="---">🐖💨🤷‍♀️🤷‍♂️</option>
            <option value="1">Кислотою</option>
            <option value="2">Дробильні</option>
            <option value="3">Холодом</option>
            <option value="4">Вогонем</option>
            <option value="5">Силовим полем</option>
            <option value="6">Електрикою</option>
            <option value="7">Некротичною енергією</option>
            <option value="8">Колоті</option>
            <option value="9">Отрутою</option>
            <option value="10">Психічною енергією</option>
            <option value="11">Випромінюванням</option>
            <option value="12">Рубані</option>
            <option value="13">Звуком</option>
        </FormControl>
      </div>
    );
  }

