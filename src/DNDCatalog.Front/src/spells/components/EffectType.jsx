import React from 'react';
import { FormLabel, FormControl} from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const EffectType = () =>{
    const { register } = useFormContext(); // retrieve all hook methods

    return (
      <div>
        <FormLabel>Ефект: </FormLabel>
        <br/>
        <FormControl as="select" {...register("effectType")} aria-label="effectType" >
            <option value="---">🐖💨🤷‍♀️🤷‍♂️</option>
            <option value="0">Зміна форми (Shapechanging)</option>
            <option value="1">Виявлення (Detection)</option>
            <option value="2">Телепортація (Teleportation)</option>
            <option value="3">Контроль (Control)</option>
            <option value="4">Передбачення (Foreknowledge)</option>
            <option value="5">Спілкування (Communication)</option>
            <option value="6">Дебафф (Debuff)</option>
            <option value="7">Бафф (Buff)</option>
            <option value="8">Створення (Creation)</option>
            <option value="9">Рух (Movement)</option>
            <option value="10">Розвідка (Exploration)</option>
            <option value="11">Прикликання (Summoning)</option>
            <option value="12">Охорона (Warding)</option>
            <option value="13">Загоєння (Healing)</option>
            <option value="14">Додатковий (Additional)</option>
            <option value="15">Осліплений (Blinded)</option>
            <option value="16">Зачарований (Charmed)</option>
            <option value="17">Бойовий (Combat)</option>
            <option value="18">Оглушені (Deafened)</option>
            <option value="19">Обман (Deception)</option>
            <option value="20">Дунамансі (Dunamancy)</option>
            <option value="21">Навколишнє середовище (Environment)</option>
            <option value="22">Наляканий (Frightened)</option>
            <option value="23">Невидимий (Invisible)</option>
            <option value="24">Заперечення (Negation)</option>
            <option value="25">Паралізований (Paralyzed)</option>
            <option value="26">Скам'янілий (Petrified)</option>
            <option value="27">Лежачий (Prone)</option>
            <option value="28">Стриманий (Restrained)</option>
            <option value="29">Соціальний (Social)</option>
            <option value="30">Приголомшений (Stunned)</option>
            <option value="31">Без свідомості (Unconscious)</option>
            <option value="32">Утиліта (Utility)</option>
        </FormControl>
      </div>
    );
  }

