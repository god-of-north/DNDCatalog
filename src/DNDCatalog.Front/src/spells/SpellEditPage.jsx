import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Form, Row, Col, FormCheck, FormControl, Alert, Container } from 'react-bootstrap';
import { EditName } from './components/EditName';
import { Description } from './components/Description';
import { Level } from './components/Level';
import { ClassesSelector } from './components/ClassesSelect';
import { AttackType } from './components/AttackType';
import { DamageType } from './components/DamageType';
import { EffectType } from './components/EffectType';
import { SavingThrowType } from './components/SavingThrowType';
import { SpellSchool } from './components/SpellSchool';
import { Duration } from './components/Duration';
import { CastingTime } from './components/CastingTime';
import { Range } from './components/Range';
import { Archetypes } from './components/Archetypes';
import { SpellSources } from './components/SpellSources';
import axios from 'axios';

import {useForm, FormProvider} from 'react-hook-form';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useLocalStorageState } from 'react-localstorage-hooks';

export const SpellEditPage = () =>{

    // let { spellId } = useParams();
    let { spellName } = useParams();

    const methods = useForm();
    const {register, handleSubmit, setValue } = methods;

    const [authToken] = useLocalStorageState("authToken");
    const [isAuthenticated] = useLocalStorageState("isAuthenticated");

    const [descriptionUa, setDescriptionUa] = useState("");
    const [descriptionEng, setDescriptionEng] = useState("");
    const [descriptionRu1, setDescriptionRu1] = useState("");
    const [descriptionRu2, setDescriptionRu2] = useState("");
    const [descriptionUa1, setDescriptionUa1] = useState("");
    const [descriptionUa2, setDescriptionUa2] = useState("");
    
    const [nameUa, setNameUa] = useState("");
    const [nameEng, setNameEng] = useState("");
    const [nameRu, setNameRu] = useState("");
    
    const [alertMessage, setAlertMessage] = useState("");
    const [alertMessageType, setAlertMessageType] = useState("danger");

    const showAlert = (type, message) =>
    {
      setAlertMessageType(type);
      setAlertMessage(message);
    }

    const getSpell = async (name) =>
    {
      const response = await fetch('api/v1/spells/'+name);
      const data = await response.json();

      setValue("id", data.id);
      setValue("name", data.name.ukr);
      setValue("description", data.description.ukr);
      setValue("attackType", data.attack==null?"---":data.attack);
      setValue("castingTime_time", data.castingTime.time);
      setValue("castingTime_isAction", data.castingTime.isAction===true?"action":"time");
      setValue("castingTime_actionTime_count", data.castingTime?.actionTime?.count);
      setValue("castingTime_actionTime_actionType", data.castingTime?.actionTime?.actionType);
      setValue("range_type", data.range.type==null?"---":data.range.type);
      setValue("range_distance", data.range.distance);
      setValue("range_area", data.range.area);
      setValue("range_shape", data.range.shape==null?"---":data.range.shape);
      setValue("duration_type", data.duration.type==null?"---":data.duration.type);
      setValue("duration_time", data.duration.time);
      setValue("damageType", data.damageType==null?"---":data.damageType);
      setValue("effectType", data.effectType==null?"---":data.effectType);
      setValue("savingThrowType", data.saveReqired==null?"---":data.saveReqired);
      setValue("school", data.school);
      setValue("level", data.level);
      setValue("ritual", data.ritual);
      setValue("concentration", data.concentration);
      setValue("verbal", data.componentV);
      setValue("somatic", data.componentS);
      setValue("material", data.componentM);
      setValue("materialDescription", data.componentMDescription);
      setValue("classes", data.classes.map((c) => Object.create({value:c.id, label:c.name}) ));
      setValue("archetypes", data.archetypes.map((c) => Object.create({value:c.id, label:c.name}) ));
      setValue("source", Object.create({value:data.source, label:data.source}) );
      
      setDescriptionUa(data.description.ukr1);
      setDescriptionEng(data.description.eng);
      setDescriptionRu1(data.description.rus1);
      setDescriptionRu2(data.description.rus2);
      setDescriptionUa1(data.description.ukr2);
      setDescriptionUa2(data.description.ukr3);
      
      setNameUa( data.name.ukr);
      setNameEng(data.name.eng);
      setNameRu( data.name.rus);
    }
    
    useEffect(()=>{
      getSpell(spellName);
    }, []);
    
    const getSelectItem = (item) => item==="---"?null:item;

    const onSubmit = async (data) =>
    {
      console.log(data);

      if(!isAuthenticated)
      {
        showAlert("danger", "Лише авторизовані користувачі мають право на магію збереження змін!");
        return;
      }
      
      const req = {};

      req.id = data.id;
      req.name = data.name;
      req.description = descriptionUa;
      req.level = data.level;
      req.ritual = data.ritual;
      req.concentration = data.concentration;
      req.verbal = data.verbal;
      req.somatic = data.somatic;
      req.material = data.material;
      req.materialDescription = data.materialDescription;
      req.source = data.source.value;
      req.attackType = getSelectItem(data.attackType);
      req.damageType = getSelectItem(data.damageType);
      req.effectType = getSelectItem(data.effectType);
      req.savingThrowType = getSelectItem(data.savingThrowType);
      req.school = data.school;
      req.castingTime = {};
      req.castingTime.time = data.castingTime_time;
      req.castingTime.isAction = data.castingTime_isAction==="action";
      req.castingTime.actionTime = {};
      req.castingTime.actionTime.actionType = data.castingTime_actionTime_actionType;
      req.castingTime.actionTime.count = data.castingTime_actionTime_count;
      req.range = {};
      req.range.type = getSelectItem(data.range_type);
      req.range.distance = data.range_distance;
      req.range.area = data.range_area;
      req.range.shape = getSelectItem(data.range_shape);
      req.duration = {};
      req.duration.type = getSelectItem(data.duration_type);
      req.duration.time = data.duration_time;
      req.classes = data.classes.map(o => o.value);
      req.archetypes = data.archetypes.map(o => o.value);

      console.log(req);

      const config = {
        headers: { 
          Authorization: `Bearer ${authToken}`,
        }
      };
    
      axios
        .put('api/v1/spells', req, config)
        .then((response)=>
        {
          console.log(response);

            if(response.status !== 200)
                throw 'Помилка збереження'

            showAlert("success", "Збережено!");
        })
       .catch((error) => 
        {
            console.log(error);
            showAlert("danger", `Saving failed with error code ${error.response.status}:${error.response.statusText}`);
        });
 
    }
    
    
    return (
      <Container fluid={true}>
        <h1>Редагування заклинання</h1>

        {alertMessage!=="" &&  
        <div style={{ position: "sticky", top: 20, zIndex: 999 }}>
            <Alert variant={alertMessageType} onClose={() => setAlertMessage("")} dismissible>
                <p>{alertMessage}</p>
            </Alert>
        </div>}

        <FormProvider {...methods}>
        <Form onSubmit={handleSubmit(onSubmit)} >
            <EditName eng={nameEng} ru={nameRu} ua={nameUa}/>
            <Description translation={descriptionUa} setTranslation={(d) =>setDescriptionUa(d)} eng={descriptionEng} ru1={descriptionRu1} ru2={descriptionRu2} ua1={descriptionUa1} ua2={descriptionUa2}/>
            <Row>
              <Col sm={6} lg={2}>
                <Level />
              </Col>
              <Col sm={6} lg={2}>
                <AttackType />
              </Col>
              <Col sm={6} lg={2}>
                <DamageType />
              </Col>
              <Col sm={6} lg={2}>
                <EffectType />
              </Col>
              <Col sm={6} lg={2}>
                <SavingThrowType />
              </Col>
              <Col sm={6} lg={2}>
                <SpellSchool />
              </Col>
            </Row>
            <Row>
              <Col>
                <FormCheck {...register("ritual")} label="Ритуал"  />
                <FormCheck {...register("concentration")} label="Концентрація" />
              </Col>
              <Col lg={4}>
                <FormCheck   {...register("somatic")} label="Тілесний" />
                <FormCheck   {...register("verbal")} label="Словесний" />
                <FormCheck   {...register("material")} label="Матеріальний" />
                <FormControl {...register("materialDescription")} type="text" placeholder="Опис матеріального компонента..." />
              </Col>
            </Row>
            <Row>
              <Col sm={6} lg={4}>
                <CastingTime />
              </Col>
              <Col sm={6} lg={4}>
                <Duration />
              </Col>
              <Col sm={6} lg={4}>
                <Range />
              </Col>
            </Row> 
            <Row>
              <Col sm={6} lg={4}>
                <ClassesSelector />
              </Col>
              <Col sm={6} lg={4}>
                <Archetypes />
              </Col>
              <Col sm={6} lg={4}>
                <SpellSources />
              </Col>
            </Row>

            <Form.Control type="submit" value='Зберегти' disabled={!isAuthenticated}/>
        </Form>
        </FormProvider>
        <br/>
        <br/>
        <br/>
        <br/>
      </Container>
    );
}

