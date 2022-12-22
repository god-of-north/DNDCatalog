import React, { useState, useEffect } from 'react';
import Select from 'react-select';
import { Row } from 'reactstrap';
import { Container } from 'react-bootstrap/esm';
import ToggleButtonGroup from 'react-bootstrap/ToggleButtonGroup';
import ToggleButton from 'react-bootstrap/ToggleButton';


export const SpellFilter = ({value, onChange}) => {

    const [sources, setSources] = useState([]);
    const [classesOptions, setClassesOptions] = useState([]);
    const [archetypeOptions, setArchetypeOptions] = useState([]);

    const updateFilter = (key, data) =>
    {
        const updatedFilter = {...value};
        updatedFilter[key] = data;
        value = updatedFilter;
        onChange(updatedFilter);
    };

    const getSources = async () => {
        const response = await fetch('api/v1/sources/spells');
        const data = await response.json();
        setSources(data.sources);
    }

    const getClasses = async () => {
        const response = await fetch('api/v1/classes');
        const data = await response.json();
        const options = data.classes.map((x) => Object.create({value:x.id, label:x.name}));
        setClassesOptions(options);
    }
      
    const getArchetypes = async () => {
        const response = await fetch('api/v1/classes/archetypes');
        const data = await response.json();
        const options = data.archetypes.map((x) => Object.create({value:x.id, label:x.name}));
        setArchetypeOptions(options);
      }
  
    useEffect(()=>{
        getSources();
        getClasses();
        getArchetypes();
    }, []);
  

    return (
        <Container>
            <Row><strong>Рівень</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" value={value['levels']} onChange={(e)=>updateFilter('levels', e)}>
                    <ToggleButton value="0">Заговір</ToggleButton>
                    <ToggleButton value="1">1-й</ToggleButton>
                    <ToggleButton value="2">2-й</ToggleButton>
                    <ToggleButton value="3">3-й</ToggleButton>
                    <ToggleButton value="4">4-й</ToggleButton>
                    <ToggleButton value="5">5-й</ToggleButton>
                    <ToggleButton value="6">6-й</ToggleButton>
                    <ToggleButton value="7">7-й</ToggleButton>
                    <ToggleButton value="8">8-й</ToggleButton>
                    <ToggleButton value="9">9-й</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Атака</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" value={value['attackTypes']} onChange={(e)=>updateFilter('attackTypes', e)}>
                    <ToggleButton value="0">Рукопашна</ToggleButton>
                    <ToggleButton value="1">Далекобійна</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Вид ушкоджень</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" value={value['damageTypes']} onChange={(e)=>updateFilter('damageTypes', e)}>
                    <ToggleButton value="1">Кислотою</ToggleButton>
                    <ToggleButton value="2">Дробильні</ToggleButton>
                    <ToggleButton value="3">Холодом</ToggleButton>
                    <ToggleButton value="4">Вогонем</ToggleButton>
                    <ToggleButton value="5">Силовим полем</ToggleButton>
                    <ToggleButton value="6">Електрикою</ToggleButton>
                    <ToggleButton value="7">Некротичною енергією</ToggleButton>
                    <ToggleButton value="8">Колоті</ToggleButton>
                    <ToggleButton value="9">Отрутою</ToggleButton>
                    <ToggleButton value="10">Психічною енергією</ToggleButton>
                    <ToggleButton value="11">Випромінюванням</ToggleButton>
                    <ToggleButton value="12">Рубані</ToggleButton>
                    <ToggleButton value="13">Звуком</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Ефект</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" value={value['effectTypes']} onChange={(e)=>updateFilter('effectTypes', e)}>
                    <ToggleButton value="0">Зміна форми (Shapechanging)</ToggleButton>
                    <ToggleButton value="1">Виявлення (Detection)</ToggleButton>
                    <ToggleButton value="2">Телепортація (Teleportation)</ToggleButton>
                    <ToggleButton value="3">Контроль (Control)</ToggleButton>
                    <ToggleButton value="4">Передбачення (Foreknowledge)</ToggleButton>
                    <ToggleButton value="5">Спілкування (Communication)</ToggleButton>
                    <ToggleButton value="6">Дебафф (Debuff)</ToggleButton>
                    <ToggleButton value="7">Бафф (Buff)</ToggleButton>
                    <ToggleButton value="8">Створення (Creation)</ToggleButton>
                    <ToggleButton value="9">Рух (Movement)</ToggleButton>
                    <ToggleButton value="10">Розвідка (Exploration)</ToggleButton>
                    <ToggleButton value="11">Прикликання (Summoning)</ToggleButton>
                    <ToggleButton value="12">Охорона (Warding)</ToggleButton>
                    <ToggleButton value="13">Загоєння (Healing)</ToggleButton>
                    <ToggleButton value="14">Додатковий (Additional)</ToggleButton>
                    <ToggleButton value="15">Осліплений (Blinded)</ToggleButton>
                    <ToggleButton value="16">Зачарований (Charmed)</ToggleButton>
                    <ToggleButton value="17">Бойовий (Combat)</ToggleButton>
                    <ToggleButton value="18">Оглушені (Deafened)</ToggleButton>
                    <ToggleButton value="19">Обман (Deception)</ToggleButton>
                    <ToggleButton value="20">Дунамансі (Dunamancy)</ToggleButton>
                    <ToggleButton value="21">Навколишнє середовище (Environment)</ToggleButton>
                    <ToggleButton value="22">Наляканий (Frightened)</ToggleButton>
                    <ToggleButton value="23">Невидимий (Invisible)</ToggleButton>
                    <ToggleButton value="24">Заперечення (Negation)</ToggleButton>
                    <ToggleButton value="25">Паралізований (Paralyzed)</ToggleButton>
                    <ToggleButton value="26">Скам'янілий (Petrified)</ToggleButton>
                    <ToggleButton value="27">Лежачий (Prone)</ToggleButton>
                    <ToggleButton value="28">Стриманий (Restrained)</ToggleButton>
                    <ToggleButton value="29">Соціальний (Social)</ToggleButton>
                    <ToggleButton value="30">Приголомшений (Stunned)</ToggleButton>
                    <ToggleButton value="31">Без свідомості (Unconscious)</ToggleButton>
                    <ToggleButton value="32">Утиліта (Utility)</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Кидок рятунку</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" value={value['savingThrowTypes']} onChange={(e)=>updateFilter('savingThrowTypes', e)}>
                    <ToggleButton value="0">Вправність</ToggleButton>
                    <ToggleButton value="1">Статура</ToggleButton>
                    <ToggleButton value="2">Сила</ToggleButton>
                    <ToggleButton value="3">Мудрість</ToggleButton>
                    <ToggleButton value="4">Харизма</ToggleButton>
                    <ToggleButton value="5">Інтелект</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Школа магії</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" value={value['schools']} onChange={(e)=>updateFilter('schools', e)}>
                    <ToggleButton value="1">Огородження</ToggleButton>
                    <ToggleButton value="2">Виклику</ToggleButton>
                    <ToggleButton value="3">Віщування</ToggleButton>
                    <ToggleButton value="4">Причарування</ToggleButton>
                    <ToggleButton value="5">Втілення</ToggleButton>
                    <ToggleButton value="6">Ілюзії</ToggleButton>
                    <ToggleButton value="7">Некромантії</ToggleButton>
                    <ToggleButton value="8">Видозміни</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Компоненти</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" value={value['components']} onChange={(e)=>updateFilter('components', e)}>
                    <ToggleButton value="Словесний">Verbal</ToggleButton>
                    <ToggleButton value="Тілесний">Somatic</ToggleButton>
                    <ToggleButton value="Матеріальний">Material</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Ритуал</strong></Row>
            <Row>
                <ToggleButtonGroup name="ritual" type="radio" defaultValue="-" value={value['ritual']} onChange={(e)=>updateFilter('ritual', e)}>
                    <ToggleButton value="-">байдуже</ToggleButton>
                    <ToggleButton value="true">так</ToggleButton>
                    <ToggleButton value="false">ні</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Концентрація</strong></Row>
            <Row>
                <ToggleButtonGroup type="radio" name="concentration" defaultValue="-" value={value['concentration']} onChange={(e)=>updateFilter('concentration', e)}>
                    <ToggleButton value="-">байдуже</ToggleButton>
                    <ToggleButton value="true">потрібна</ToggleButton>
                    <ToggleButton value="false">не потрібна</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Джерела</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" value={value['sources']} onChange={(e)=>updateFilter('sources', e)}>
                    {sources.map(source =>
                        <ToggleButton key={source} value={source}>{source}</ToggleButton>
                    )}
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Класи</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" value={value['classes']} onChange={(e)=>updateFilter('classes', e)}>
                    {classesOptions.map(c =>
                        <ToggleButton key={c.value} value={c.value}>{c.label}</ToggleButton>
                    )}
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Архетипи</strong></Row>
            <Row>
                <Select
                    name="archetypes"
                    isMulti
                    options={archetypeOptions}
                    className="basic-multi-select"
                    classNamePrefix="select"
                    value={value['archetypes_value']}
                    onChange={(e)=>
                        {
                            const updatedFilter = {...value};
                            updatedFilter['archetypes_value'] = e;
                            value = updatedFilter;
                            updateFilter('archetypes', e.map(o => o.value));
                        }}
                />
            </Row>

        </Container>
    );
}

