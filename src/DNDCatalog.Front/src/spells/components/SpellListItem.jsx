import React from 'react';
import Badge from 'react-bootstrap/Badge';
import { Button, Container, Row, Col } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { useGlobalState } from '../../auth/state';

export const SpellListItem = ({spell}) => {

    const [isAuthenticated] = useGlobalState("isAuthenticated");

    return (
      <Container>
        <Row>
          <Col>
            <div>{spell.name.ukr}</div>
            <div>{spell.name.eng}</div>
            <div>{spell.name.rus}</div>
          </Col>
          <Col>
            <div>Level <Badge bg="light" pill>{spell.level}</Badge></div>
            <div>{spell.source}</div>
          </Col>
          <Col align="right">
            {/* {isAuthenticated ?? <Link to={"/spells/edit/"+spell.id}> <Button>Edit</Button> </Link> } */}
            <Link to={"/spells/edit/"+spell.id}> <Button>Edit</Button> </Link>
          </Col>
        </Row>
      </Container>
    );
}
