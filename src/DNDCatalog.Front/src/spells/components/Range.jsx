import React from 'react';
import { FormControl, FormLabel} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const Range = () =>{
    const { register } = useFormContext(); // retrieve all hook methods

    return (
      <div>
        <FormLabel>Range</FormLabel>
        <br/>
        <FormControl as="select" {...register("range_type")} aria-label="range_type" >
            <option value="0">Self</option>
            <option value="1">Touch</option>
            <option value="2">Distance</option>
            <option value="3">Sight</option>
            <option value="4">Unlimited</option>
        </FormControl>

        <br/>
        <FormLabel>Distance</FormLabel>
        <FormControl {...register("range_distance")} type="number" placeholder='Distance..'/>

        <FormLabel>Area</FormLabel>
        <FormControl {...register("range_area")} type="number" placeholder='Area..'/>

        <FormLabel>Shape</FormLabel>
        <FormControl as="select" {...register("range_shape")} aria-label="range_shape" >
            <option>---</option>
            <option value="0">Square</option>
            <option value="1">Cube</option>
            <option value="2">Sphere</option>
            <option value="3">Circle</option>
            <option value="4">Cone</option>
            <option value="5">Cylinder</option>
            <option value="6">Line</option>
        </FormControl>
      </div>
    );
  }

