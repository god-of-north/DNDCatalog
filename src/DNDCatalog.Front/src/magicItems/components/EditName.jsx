import React from 'react';
import { FormControl, Row, Col } from 'react-bootstrap';
import { useFormContext } from "react-hook-form";

export const EditName = ({ua, eng, ru}) => {
    const { register } = useFormContext(); // retrieve all hook methods

    return (
        <Row>
            <Col sm={6} lg={4}><strong>{eng}</strong></Col>
            <Col sm={6} lg={4}><strong>{ru}</strong></Col>
            <Col sm={6} lg={4}>
                <FormControl {...register("name")} type="text" placeholder="Назва предмету українською..." />
            </Col>
        </Row>
    );
}
