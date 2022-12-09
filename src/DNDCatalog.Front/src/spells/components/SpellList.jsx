import React, { useEffect, useState, useRef } from 'react';
import ListGroup from 'react-bootstrap/ListGroup';
import { SpellListItem } from './SpellListItem';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { SpellFilter } from './SpellFilter';
import { DebounceInput } from 'react-debounce-input';
import { Form } from 'react-bootstrap';


export const SpellList = () =>{

  const [spells, setSpells] = useState([]);
  const [currentPage, setCurrentPage] = useState(0);
  const [fetching, setFetching] = useState(true);
  const totalCount = useRef(0);
  
  const [filterShow, setFilterShow] = React.useState(false);
  const handleFilterClose = () => setFilterShow(false);
  const handleFilterShow = () => setFilterShow(true);

  const [searchString, setSearchString] = useState("");

  useEffect(() => 
  {
    if(fetching)
    {
      const filterQuery = getFilterQuery(filter);
      fetch(encodeURI(`api/v1/spells?page=${currentPage}${filterQuery}`))
        .then(async (response) => 
        {
            const data = await response.json();
            setCurrentPage(prevState => prevState + 1);
            totalCount.current = data.totalCount
            setSpells([...spells, ...data.spells]);
          })
        .finally(() => setFetching(false));
    }
  }, [fetching]);

  useEffect(()=>
  {
    document.addEventListener('scroll', scrollHandler);
    return function()
    {
      document.removeEventListener('scroll', scrollHandler);
    }
  }, []);

  const scrollHandler = (e) =>
  {
    if(e.target.documentElement.scrollHeight - (e.target.documentElement.scrollTop + window.innerHeight) < 200 && spells.length < totalCount.current)
    {
      setFetching(true);
    }
  }


  const [filter, setFilter] = useState({});
  useEffect(()=>
  {
    setSpells([]);
    setCurrentPage(0);
    totalCount.current = 0;
    setFetching(true);
  }, [filter, searchString]);

  const getFilterQuery = (f) =>
  {
    var query = [];
    if("levels" in f) query.push(...f.levels.map(x=>`Levels=${x}`));
    if("attackTypes" in f) query.push(...f.attackTypes.map(x=>`AttackTypes=${x}`));
    if("damageTypes" in f) query.push(...f.damageTypes.map(x=>`DamageTypes=${x}`));
    if("effectTypes" in f) query.push(...f.effectTypes.map(x=>`EffectTypes=${x}`));
    if("savingThrowTypes" in f) query.push(...f.savingThrowTypes.map(x=>`SavingThrowTypes=${x}`));
    if("schools" in f) query.push(...f.schools.map(x=>`Schools=${x}`));
    if("sources" in f) query.push(...f.sources.map(x=>`Sources=${x}`));
    if("classes" in f) query.push(...f.classes.map(x=>`Classes=${x}`));
    if("archetypes" in f) query.push(...f.archetypes.map(x=>`Archetypes=${x}`));
    if("components" in f)
    {
      query.push(`Verbal=${("Verbal" in f.components)}`);
      query.push(`Somatic=${("Somatic" in f.components)}`);
      query.push(`Material=${("Material" in f.components)}`);
    }
    if("ritual" in f && f.ritual!=="-") query.push(`Ritual=${f.ritual}`);
    if("concentration" in f && f.concentration!=="-") query.push(`Concentration=${f.concentration}`);
    if(searchString !== "") query.push(`Search=${searchString}`);
    return query.length>0?'&'+query.join("&"):"";
  };


  return (
    <div>
      <Button align="right" variant="primary" onClick={handleFilterShow}>Фільтри</Button>

      <Modal show={filterShow} onHide={handleFilterClose} size="lg" centered >
        <Modal.Header closeButton><Modal.Title>Фільтри</Modal.Title></Modal.Header>
        <Modal.Body>
          <SpellFilter value={filter} onChange={setFilter}/>
        </Modal.Body>
      </Modal>

      <DebounceInput element={Form.Control} minLength={2} debounceTimeout={500} onChange={e => setSearchString(e.target.value)} />

      <ListGroup as="ol">
        {spells.map(spell => {
          return <ListGroup.Item as="li" key={spell.name.eng} ><SpellListItem spell={spell} /></ListGroup.Item> 
        })}
      </ListGroup>        
    </div>
  );
}
