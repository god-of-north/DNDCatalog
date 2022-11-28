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
        onChange(updatedFilter);
    };

    const getSources = async () => {
        const response = await fetch('api/v1/sources');
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
            <Row><strong>Level</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" onChange={(e)=>updateFilter('levels', e)}>
                    <ToggleButton value="0">Cantrip</ToggleButton>
                    <ToggleButton value="1">1</ToggleButton>
                    <ToggleButton value="2">2</ToggleButton>
                    <ToggleButton value="3">3</ToggleButton>
                    <ToggleButton value="4">4</ToggleButton>
                    <ToggleButton value="5">5</ToggleButton>
                    <ToggleButton value="6">6</ToggleButton>
                    <ToggleButton value="7">7</ToggleButton>
                    <ToggleButton value="8">8</ToggleButton>
                    <ToggleButton value="9">9</ToggleButton>
                    <ToggleButton value="10">10</ToggleButton>
                    <ToggleButton value="11">11</ToggleButton>
                    <ToggleButton value="12">12</ToggleButton>
                    <ToggleButton value="13">13</ToggleButton>
                    <ToggleButton value="14">14</ToggleButton>
                    <ToggleButton value="15">15</ToggleButton>
                    <ToggleButton value="16">16</ToggleButton>
                    <ToggleButton value="17">17</ToggleButton>
                    <ToggleButton value="18">18</ToggleButton>
                    <ToggleButton value="19">19</ToggleButton>
                    <ToggleButton value="20">20</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Attack Type</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox"  onChange={(e)=>updateFilter('attackTypes', e)}>
                    <ToggleButton value="0">Melee</ToggleButton>
                    <ToggleButton value="1">Ranged</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Damage Type</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox"  onChange={(e)=>updateFilter('damageTypes', e)}>
                    <ToggleButton value="1">Acid</ToggleButton>
                    <ToggleButton value="2">Bludgeoning</ToggleButton>
                    <ToggleButton value="3">Cold</ToggleButton>
                    <ToggleButton value="4">Fire</ToggleButton>
                    <ToggleButton value="5">Force</ToggleButton>
                    <ToggleButton value="6">Lightning</ToggleButton>
                    <ToggleButton value="7">Necrotic</ToggleButton>
                    <ToggleButton value="8">Piercing</ToggleButton>
                    <ToggleButton value="9">Poison</ToggleButton>
                    <ToggleButton value="10">Psychic</ToggleButton>
                    <ToggleButton value="11">Radiant</ToggleButton>
                    <ToggleButton value="12">Slashing</ToggleButton>
                    <ToggleButton value="13">Thunder</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Effect Type</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox"  onChange={(e)=>updateFilter('effectTypes', e)}>
                    <ToggleButton value="0">Shapechanging</ToggleButton>
                    <ToggleButton value="1">Detection</ToggleButton>
                    <ToggleButton value="2">Teleportation</ToggleButton>
                    <ToggleButton value="3">Control</ToggleButton>
                    <ToggleButton value="4">Foreknowledge</ToggleButton>
                    <ToggleButton value="5">Communication</ToggleButton>
                    <ToggleButton value="6">Debuff</ToggleButton>
                    <ToggleButton value="7">Buff</ToggleButton>
                    <ToggleButton value="8">Creation</ToggleButton>
                    <ToggleButton value="9">Movement</ToggleButton>
                    <ToggleButton value="10">Exploration</ToggleButton>
                    <ToggleButton value="11">Summoning</ToggleButton>
                    <ToggleButton value="12">Warding</ToggleButton>
                    <ToggleButton value="13">Healing</ToggleButton>
                    <ToggleButton value="14">Additional</ToggleButton>
                    <ToggleButton value="15">Blinded</ToggleButton>
                    <ToggleButton value="16">Charmed</ToggleButton>
                    <ToggleButton value="17">Combat</ToggleButton>
                    <ToggleButton value="18">Deafened</ToggleButton>
                    <ToggleButton value="19">Deception</ToggleButton>
                    <ToggleButton value="20">Dunamancy</ToggleButton>
                    <ToggleButton value="21">Environment</ToggleButton>
                    <ToggleButton value="22">Frightened</ToggleButton>
                    <ToggleButton value="23">Invisible</ToggleButton>
                    <ToggleButton value="24">Negation</ToggleButton>
                    <ToggleButton value="25">Paralyzed</ToggleButton>
                    <ToggleButton value="26">Petrified</ToggleButton>
                    <ToggleButton value="27">Prone</ToggleButton>
                    <ToggleButton value="28">Restrained</ToggleButton>
                    <ToggleButton value="29">Social</ToggleButton>
                    <ToggleButton value="30">Stunned</ToggleButton>
                    <ToggleButton value="31">Unconscious</ToggleButton>
                    <ToggleButton value="32">Utility</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Saving Throw Type</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox"  onChange={(e)=>updateFilter('savingThrowTypes', e)}>
                    <ToggleButton value="0">Dexterity</ToggleButton>
                    <ToggleButton value="1">Constitution</ToggleButton>
                    <ToggleButton value="2">Strength</ToggleButton>
                    <ToggleButton value="3">Wisdom</ToggleButton>
                    <ToggleButton value="4">Charisma</ToggleButton>
                    <ToggleButton value="5">Intelligence</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>School</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" onChange={(e)=>updateFilter('schools', e)}>
                    <ToggleButton value="1">Abjuration</ToggleButton>
                    <ToggleButton value="2">Conjuration</ToggleButton>
                    <ToggleButton value="3">Divination</ToggleButton>
                    <ToggleButton value="4">Enchantment</ToggleButton>
                    <ToggleButton value="5">Evocation</ToggleButton>
                    <ToggleButton value="6">Illusion</ToggleButton>
                    <ToggleButton value="7">Necromancy</ToggleButton>
                    <ToggleButton value="8">Transmutation</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Components</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" onChange={(e)=>updateFilter('components', e)}>
                    <ToggleButton value="Verbal">Verbal</ToggleButton>
                    <ToggleButton value="Somatic">Somatic</ToggleButton>
                    <ToggleButton value="Material">Material</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Ritual</strong></Row>
            <Row>
                <ToggleButtonGroup name="ritual" type="radio" defaultValue="-" onChange={(e)=>updateFilter('ritual', e)}>
                    <ToggleButton value="-">байдуже</ToggleButton>
                    <ToggleButton value="true">так</ToggleButton>
                    <ToggleButton value="false">ні</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Concentration</strong></Row>
            <Row>
                <ToggleButtonGroup type="radio" name="concentration" defaultValue="-" onChange={(e)=>updateFilter('concentration', e)}>
                    <ToggleButton value="-">байдуже</ToggleButton>
                    <ToggleButton value="true">потрібна</ToggleButton>
                    <ToggleButton value="false">не потрібна</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Sources</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox"  onChange={(e)=>updateFilter('sources', e)}>
                    {sources.map(source =>
                        <ToggleButton key={source} value={source}>{source}</ToggleButton>
                    )}
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Classes</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" onChange={(e)=>updateFilter('classes', e)}>
                    {classesOptions.map(c =>
                        <ToggleButton key={c.value} value={c.value}>{c.label}</ToggleButton>
                    )}
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Archetypes</strong></Row>
            <Row>
                <Select
                    name="archetypes"
                    isMulti
                    options={archetypeOptions}
                    className="basic-multi-select"
                    classNamePrefix="select"
                    onChange={(e)=>updateFilter('archetypes', e.map(o => o.value))}
                />
            </Row>

        </Container>
    );
}

