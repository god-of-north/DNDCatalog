import React from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const EffectType = () =>{
    const { register } = useFormContext(); // retrieve all hook methods

    return (
      <div>
        <FormLabel>Effect Type: </FormLabel>
        <br/>
        <FormControl as="select" {...register("effectType")} aria-label="effectType" >
            <option>---</option>
            <option value="0">Shapechanging</option>
            <option value="1">Detection</option>
            <option value="2">Teleportation</option>
            <option value="3">Control</option>
            <option value="4">Foreknowledge</option>
            <option value="5">Communication</option>
            <option value="6">Debuff</option>
            <option value="7">Buff</option>
            <option value="8">Creation</option>
            <option value="9">Movement</option>
            <option value="10">Exploration</option>
            <option value="11">Summoning</option>
            <option value="12">Warding</option>
            <option value="13">Healing</option>
            <option value="14">Additional</option>
            <option value="15">Blinded</option>
            <option value="16">Charmed</option>
            <option value="17">Combat</option>
            <option value="18">Deafened</option>
            <option value="19">Deception</option>
            <option value="20">Dunamancy</option>
            <option value="21">Environment</option>
            <option value="22">Frightened</option>
            <option value="23">Invisible</option>
            <option value="24">Negation</option>
            <option value="25">Paralyzed</option>
            <option value="26">Petrified</option>
            <option value="27">Prone</option>
            <option value="28">Restrained</option>
            <option value="29">Social</option>
            <option value="30">Stunned</option>
            <option value="31">Unconscious</option>
            <option value="32">Utility</option>
        </FormControl>
      </div>
    );
  }

