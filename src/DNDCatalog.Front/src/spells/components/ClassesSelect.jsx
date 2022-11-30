import React, {useState, useEffect} from 'react';
import { Form} from 'react-bootstrap';
import Select from 'react-select';
import { Controller, useFormContext } from "react-hook-form";

export const ClassesSelector = () =>{

    const { control } = useFormContext(); // retrieve all hook methods
    const [classesOptions, setClassesOptions] = useState([]);

    const getClasses = async () => {
      const response = await fetch('api/v1/classes');
      const data = await response.json();
      const options = data.classes.map((x) => Object.create({value:x.id, label:x.name}));
      setClassesOptions(options);
    }

    useEffect(()=>{
      getClasses();
    }, []);



    return (
      <div>
        <Form.Label>Класи: </Form.Label>
        <br/>
        <Controller
          name="classes"
          control={control}
          render={({ field }) => <Select 
              {...field}
              isMulti
              name="classes"
              options={classesOptions}
              className="basic-multi-select"
              classNamePrefix="select"
              />
          } />
      </div>
    );
  }

