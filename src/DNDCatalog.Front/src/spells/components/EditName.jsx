import React from 'react';
import { FormControl, Row, Col } from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const EditName = ({ua, eng, ru}) => {
    const { register } = useFormContext(); // retrieve all hook methods

    return (
        <Row>
            <Col><strong>{eng}</strong></Col>
            <Col><strong>{ru}</strong></Col>
            <Col>
                <FormControl {...register("name")} type="text" placeholder="Назва заклинання українською..." />
            </Col>
        </Row>
    );
}
