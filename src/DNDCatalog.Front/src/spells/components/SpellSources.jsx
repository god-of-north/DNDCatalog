import React, {useEffect, useState} from 'react';
import {  Form } from 'react-bootstrap';

import { Controller, useFormContext } from "react-hook-form";
import CreatableSelect from 'react-select/creatable';

export const SpellSources = () =>{
  
    const { control, getValues } = useFormContext(); // retrieve all hook methods
    const [sourceOptions, setSourceOptions] = useState([]);

    const getSources = async () => {
        const response = await fetch('api/v1/sources');
        const data = await response.json();
        const options = data.sources.map((x) => Object.create({value:x, label:x}));
        setSourceOptions(options);
    }

    useEffect(()=>{
        getSources();
    }, []);


    return (
        <div>
            <Form.Label>Джерело</Form.Label>
            <br/>

            <Controller
                name="source"
                control={control}
                render={({ field }) => 
                    <CreatableSelect
                          {...field}
                          isClearable
                          options={sourceOptions}
                          value={getValues().source}
                          />
                }
            />
        </div>
    );
}

