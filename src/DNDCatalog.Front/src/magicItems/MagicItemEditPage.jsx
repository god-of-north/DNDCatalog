import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Form, Row, Col, FormCheck, FormControl, Alert, Container, FormLabel } from 'react-bootstrap';
import axios from 'axios';
import { useForm, FormProvider } from 'react-hook-form';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useLocalStorageState } from 'react-localstorage-hooks';
import { EditName } from './components/EditName';
import { Description } from './components/Description';
import { Rarity } from './components/Rarity';
import { MagicItemType } from './components/MagicItemType';
import { MagicBonus } from './components/MagicBonus';
import { MagicItemSources } from './components/MagicItemSources';

export const MagicItemEditPage = () => {

    let { magicItemId } = useParams();

    const methods = useForm();
    const { register, handleSubmit, setValue } = methods;

    const [authToken] = useLocalStorageState("authToken");
    const [isAuthenticated] = useLocalStorageState("isAuthenticated");

    const [descriptionUa, setDescriptionUa] = useState("");
    const [descriptionUa1, setDescriptionUa1] = useState("");
    const [descriptionUa2, setDescriptionUa2] = useState("");
    const [descriptionRu1, setDescriptionRu1] = useState("");
    const [descriptionRu2, setDescriptionRu2] = useState("");

    const [nameUa, setNameUa] = useState("");
    const [nameEng, setNameEng] = useState("");
    const [nameRu, setNameRu] = useState("");

    const [alertMessage, setAlertMessage] = useState("");
    const [alertMessageType, setAlertMessageType] = useState("danger");

    const showAlert = (type, message) => {
        setAlertMessageType(type);
        setAlertMessage(message);
    }

    const getMagicItem = async (id) => {
        const response = await fetch('api/v1/magicItems/' + id);
        const data = await response.json();

        setValue("id", magicItemId);
        setValue("name", data.name.ukr);
        setValue("description", data.description.ukr);
        setValue("source", Object.create({ value: data.source, label: data.source }));
        setValue("magicBonus", data.magicBonus == null ? "---" : data.magicBonus);
        setValue("rarity", data.rarity == null ? "---" : data.rarity);
        setValue("type", data.type == null ? "---" : data.type);
        setValue("consumable", data.consumable);
        setValue("charged", data.charged);
        setValue("attunement", data.attunement);
        setValue("minPrice", data.price?.minPrice);
        setValue("maxPrice", data.price?.maxPrice);
        setValue("priceNotes", data.price?.notes);
        setValue("priceFormula", data.price?.formula);

        setDescriptionUa(data.description.ukr);
        setDescriptionUa1(data.description.ukr1);
        setDescriptionUa2(data.description.ukr2);
        setDescriptionRu1(data.description.rus1);
        setDescriptionRu2(data.description.rus2);

        setNameUa(data.name.ukr);
        setNameEng(data.name.eng);
        setNameRu(data.name.rus);
    }

    useEffect(() => {
        getMagicItem(magicItemId);
    }, []);

    const getSelectItem = (item) => item === "---" ? null : item;

    const onSubmit = async (data) => {
        console.log(data);

        if (!isAuthenticated) {
            showAlert("danger", "Лише авторизовані користувачі мають право на магію збереження змін!");
            return;
        }

        const req = {};

        req.id = magicItemId;
        req.name = data.name;
        req.description = descriptionUa;
        req.source = data.source.value;
        req.attunement = data.attunement;
        req.consumable = data.consumable;
        req.charged = data.charged;
        req.magicBonus = getSelectItem(data.magicBonus);
        req.rarity = getSelectItem(data.rarity);
        req.type = getSelectItem(data.type);
        req.price = {
            minPrice: data.minPrice,
            maxPrice: data.maxPrice,
            notes: data.priceNotes,
            formula: data.priceFormula
        }

        console.log(req);

        const config = {
            headers: {
                Authorization: `Bearer ${authToken}`,
            }
        };

        axios
            .put('api/v1/magicItems', req, config)
            .then((response) => {
                console.log(response);

                if (response.status !== 200)
                    throw 'Помилка збереження'

                showAlert("success", "Збережено!");
            })
            .catch((error) => {
                console.log(error);
                showAlert("danger", `Saving failed with error code ${error.response.status}:${error.response.statusText}`);
            });

    }


    return (
        <Container>
            <h1>🔮✏Редагування магічного предмета</h1>

            {alertMessage !== "" &&
                <div style={{ position: "sticky", top: 20, zIndex: 999 }}>
                    <Alert variant={alertMessageType} onClose={() => setAlertMessage("")} dismissible>
                        <p>{alertMessage}</p>
                    </Alert>
                </div>}

            <FormProvider {...methods}>
                <Form onSubmit={handleSubmit(onSubmit)} >
                    <EditName eng={nameEng} ru={nameRu} ua={nameUa} />
                    <Description translation={descriptionUa} setTranslation={(d) => setDescriptionUa(d)} ru1={descriptionRu1} ru2={descriptionRu2} ua1={descriptionUa1} ua2={descriptionUa2} />
                    <Row>
                        <Col sm={6} lg={3}>
                            <Rarity />
                            <FormCheck   {...register("attunement")} label="Потребує налаштування" />
                            <FormCheck   {...register("consumable")} label="Витратний матеріал" />
                            <FormCheck   {...register("charged")} label="Має заряд(и)" />
                        </Col>
                        <Col sm={6} lg={3}>
                            <MagicItemType />
                        </Col>
                        <Col sm={6} lg={2}>
                            <MagicBonus />
                        </Col>
                        <Col lg={4}>
                            <FormLabel>Рекомендована ціна</FormLabel>
                            <FormControl {...register("minPrice")} type="text" placeholder="Мінімальна ціна..." />
                            <FormControl {...register("maxPrice")} type="text" placeholder="Максимальна ціна..." />
                            <FormControl {...register("priceFormula")} type="text" placeholder="Формула цінотворення..." />
                            <FormControl {...register("priceNotes")} type="text" placeholder="Примітки..." />
                        </Col>
                        <Col sm={6} lg={4}>
                            <MagicItemSources />
                        </Col>
                    </Row>

                    <Form.Control type="submit" value='💾Зберегти' disabled={!isAuthenticated} />
                </Form>
            </FormProvider>
            <br />
            <br />
            <br />
            <br />
        </Container>
    );
}

