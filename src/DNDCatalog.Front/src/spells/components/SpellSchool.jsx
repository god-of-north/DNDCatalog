import React from 'react';
import { FormControl, FormLabel} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const SpellSchool = () =>{
    const { register } = useFormContext(); // retrieve all hook methods

    return (
        <div>
            <FormLabel>Школа магії: </FormLabel>
            <br/>
            <FormControl as="select" {...register("school")} aria-label="school" >
                <option value="1">Огородження</option>
                <option value="2">Виклику</option>
                <option value="3">Віщування</option>
                <option value="4">Причарування</option>
                <option value="5">Втілення</option>
                <option value="6">Ілюзії</option>
                <option value="7">Некромантії</option>
                <option value="8">Видозміни</option>
            </FormControl>
        </div>
    );
}

