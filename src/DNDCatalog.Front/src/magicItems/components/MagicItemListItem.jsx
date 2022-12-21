import React from 'react';
import { Button, Container, Row, Col } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { useLocalStorageState } from 'react-localstorage-hooks';

export const MagicItemListItem = ({magicItem}) => {

    const [isAuthenticated] = useLocalStorageState("isAuthenticated");

    return (
      <Container>
        <Row>
          <Col>
            <div>{magicItem.name.ukr}</div>
            <div>{magicItem.name.eng}</div>
            <div>{magicItem.name.rus}</div>
          </Col>
          <Col align="right">
            {/* {isAuthenticated ?? <Link to={"/magicItems/edit/"+magicItem.id}> <Button>✏Редагувати</Button> </Link> } */}
            <Link to={"/magic-items/edit/"+magicItem.id}> <Button>✏Редагувати</Button> </Link>
          </Col>
        </Row>
      </Container>
    );
}
