import React, {useState, useEffect} from 'react';
import {  Form } from 'react-bootstrap';
import Select from 'react-select';
import { Controller, useFormContext } from "react-hook-form";

export const Archetypes = () =>{
    const { control } = useFormContext(); // retrieve all hook methods
    const [archetypeOptions, setArchetypeOptions] = useState([]);

    const getArchetypes = async () => {
      const response = await fetch('api/v1/classes/archetypes');
      const data = await response.json();
      const options = data.archetypes.map((x) => Object.create({value:x.id, label:x.name}));
      setArchetypeOptions(options);
    }

    useEffect(()=>{
      getArchetypes();
    }, []);



    return (
      <div>

        <Form.Label>Archetypes</Form.Label>
        <br/>

        <Controller
          name="archetypes"
          control={control}
          render={({ field }) => 
            <Select
              {...field}
              isMulti
              options={archetypeOptions}
              className="basic-multi-select"
              classNamePrefix="select"
            />

          } />

      </div>
    );
  }

