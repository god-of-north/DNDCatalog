import React from 'react';
import { FormControl, FormLabel} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const Range = () =>{
    const { register } = useFormContext(); // retrieve all hook methods

    return (
      <div>
        <FormLabel>Дальність</FormLabel>
        <br/>
        <FormControl as="select" {...register("range_type")} aria-label="range_type" >
            <option value="0">На себе</option>
            <option value="1">Дотик</option>
            <option value="2">Дистанція</option>
            <option value="3">Погляд</option>
            <option value="4">Безмежна</option>
        </FormControl>

        <br/>
        <FormLabel>Дистанція</FormLabel>
        <FormControl {...register("range_distance")} type="number" placeholder='Дистанція..'/>

        <FormLabel>Ділянка</FormLabel>
        <FormControl {...register("range_area")} type="number" placeholder='Ділянка..'/>

        <FormLabel>Форма ділянки</FormLabel>
        <FormControl as="select" {...register("range_shape")} aria-label="range_shape" >
            <option value="---">🐖💨🤷‍♀️🤷‍♂️</option>
            <option value="0">Квадрат</option>
            <option value="1">Куб</option>
            <option value="2">Сфера</option>
            <option value="3">Коло</option>
            <option value="4">Конус</option>
            <option value="5">Циліндер</option>
            <option value="6">Лінія</option>
        </FormControl>
      </div>
    );
}

