import React, { useState, useEffect } from 'react';
import { Row } from 'reactstrap';
import { Container } from 'react-bootstrap/esm';
import ToggleButtonGroup from 'react-bootstrap/ToggleButtonGroup';
import ToggleButton from 'react-bootstrap/ToggleButton';


export const MagiItemsFilter = ({value, onChange}) => {

    const [sources, setSources] = useState([]);

    const updateFilter = (key, data) =>
    {
        const updatedFilter = {...value};
        updatedFilter[key] = data;
        value = updatedFilter;
        onChange(updatedFilter);
    };

    const getSources = async () => {
        const response = await fetch('api/v1/sources/magic-items');
        const data = await response.json();
        setSources(data.sources);
    }
  
    useEffect(()=>{
        getSources();
    }, []);
  

    return (
        <Container>
            <Row><strong>Рідкість</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" value={value['rarities']} onChange={(e)=>updateFilter('rarities', e)}>
                    <ToggleButton value="1">Звичайна</ToggleButton>
                    <ToggleButton value="2">Не звичайна</ToggleButton>
                    <ToggleButton value="3">Рідкісний</ToggleButton>
                    <ToggleButton value="4">Дуже рідкісний</ToggleButton>
                    <ToggleButton value="5">Легендарний</ToggleButton>
                    <ToggleButton value="6">Артефакт</ToggleButton>
                    <ToggleButton value="7">Різна рідкість</ToggleButton>
                    <ToggleButton value="8">Не визначена</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Вид предмета</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" value={value['types']} onChange={(e)=>updateFilter('types', e)}>
                    <ToggleButton value="1">🥋обладунок</ToggleButton>
                    <ToggleButton value="2">⚗зілля</ToggleButton>
                    <ToggleButton value="3">💍кільце</ToggleButton>
                    <ToggleButton value="4">⚔зброя</ToggleButton>
                    <ToggleButton value="5">⚚жезл</ToggleButton>
                    <ToggleButton value="6">📜сувій</ToggleButton>
                    <ToggleButton value="7">🩼палиця</ToggleButton>
                    <ToggleButton value="8"> 	🪄чарівна паличка</ToggleButton>
                    <ToggleButton value="9">🔮чудодійний предмет</ToggleButton>
                    <ToggleButton value="10">🗡рукопашна зброя</ToggleButton>
                    <ToggleButton value="11">🏹далекобійна зброя</ToggleButton>
                    <ToggleButton value="12">🛡щит</ToggleButton>
                    <ToggleButton value="13">⚒амуніція</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Магічний бонус</strong></Row>
            <Row>
                <ToggleButtonGroup style={{ "flex-wrap": "wrap" }} type="checkbox" value={value['magicBonuses']} onChange={(e)=>updateFilter('magicBonuses', e)}>
                    <ToggleButton value="1">+1</ToggleButton>
                    <ToggleButton value="2">+2</ToggleButton>
                    <ToggleButton value="3">+3</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Налаштування</strong></Row>
            <Row>
                <ToggleButtonGroup name="attunement" type="radio" defaultValue="-" value={value['attunement']} onChange={(e)=>updateFilter('attunement', e)}>
                    <ToggleButton value="-">байдуже</ToggleButton>
                    <ToggleButton value="true">потрібне</ToggleButton>
                    <ToggleButton value="false">не потрібне</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Витратний матеріал</strong></Row>
            <Row>
                <ToggleButtonGroup type="radio" name="consumable" defaultValue="-" value={value['consumable']} onChange={(e)=>updateFilter('consumable', e)}>
                    <ToggleButton value="-">байдуже</ToggleButton>
                    <ToggleButton value="true">так</ToggleButton>
                    <ToggleButton value="false">ні</ToggleButton>
                </ToggleButtonGroup>
            </Row>

            <Row><strong>Має заряд</strong></Row>
            <Row>
                <ToggleButtonGroup type="radio" name="charged" defaultValue="-" value={value['charged']} onChange={(e)=>updateFilter('charged', e)}>
                    <ToggleButton value="-">байдуже</ToggleButton>
                    <ToggleButton value="true">так</ToggleButton>
                    <ToggleButton value="false">ні</ToggleButton>
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

        </Container>
    );
}

