import React from 'react';
import { useRef } from 'react';
import { useEffect } from 'react';
import { useState } from 'react';
import { Button, Form, ListGroup, Modal } from 'react-bootstrap';
import { DebounceInput } from 'react-debounce-input';
import { useLocalStorageState } from 'react-localstorage-hooks';
import {MagicItemListItem} from './MagicItemListItem'
import {MagiItemsFilter} from './MagiItemsFilter'

export const MagicItemsList = () => {

    const [magicItems, setMagicItems] = useState([]);
    const [currentPage, setCurrentPage] = useState(0);
    const [fetching, setFetching] = useState(true);
    const totalCount = useRef(0);

    const [filter, setFilter] = useLocalStorageState("magicItemsFilter", { initialState: {} });
    const [filterShow, setFilterShow] = useState(false);
    const handleFilterClose = () => setFilterShow(false);
    const handleFilterShow = () => setFilterShow(true);

    const [searchString, setSearchString] = useState("");

    useEffect(() => {
        if (fetching) {
            const filterQuery = getFilterQuery(filter);
            fetch(encodeURI(`api/v1/magicItems?page=${currentPage}${filterQuery}`))
                .then(async (response) => {
                    const data = await response.json();
                    setCurrentPage(prevState => prevState + 1);
                    totalCount.current = data.totalCount
                    setMagicItems([...magicItems, ...data.magicItems]);
                })
                .finally(() => setFetching(false));
        }
    }, [fetching]);

    useEffect(() => {
        document.addEventListener('scroll', scrollHandler);
        return function () {
            document.removeEventListener('scroll', scrollHandler);
        }
    }, []);

    const scrollHandler = (e) => {
        if (e.target.documentElement.scrollHeight - (e.target.documentElement.scrollTop + window.innerHeight) < 200 && magicItems.length < totalCount.current) {
            setFetching(true);
        }
    }


    useEffect(() => {
        setMagicItems([]);
        setCurrentPage(0);
        totalCount.current = 0;
        setFetching(true);
    }, [filter, searchString]);

    const getFilterQuery = (f) => {
        var query = [];
        if (searchString !== "") query.push(`Search=${searchString}`);
        if ("rarities" in f) query.push(...f.rarities.map(x => `Rarities=${x}`));
        if ("types" in f) query.push(...f.types.map(x => `Types=${x}`));
        if ("magicBonuses" in f) query.push(...f.magicBonuses.map(x => `MagicBonuses=${x}`));
        if ("priceMin" in f) query.push(...f.priceMin.map(x => `PriceMin=${x}`));
        if ("priceMax" in f) query.push(...f.priceMax.map(x => `PriceMax=${x}`));
        if ("sources" in f) query.push(...f.sources.map(x => `Sources=${x}`));
        if ("attunement" in f && f.attunement !== "-") query.push(`Attunement=${f.attunement}`);
        if ("consumable" in f && f.consumable !== "-") query.push(`Consumable=${f.consumable}`);
        if ("charged" in f && f.charged !== "-") query.push(`Charged=${f.charged}`);
        return query.length > 0 ? '&' + query.join("&") : "";
    };

    return (
        <>
            <Button align="right" variant="primary" onClick={handleFilterShow}>⚙Фільтри</Button>

            <Modal show={filterShow} onHide={handleFilterClose} size="lg" centered >
            <Modal.Header closeButton><Modal.Title>Фільтри</Modal.Title></Modal.Header>
            <Modal.Body>
                <MagiItemsFilter value={filter} onChange={setFilter}/>
            </Modal.Body>
            </Modal>

            <DebounceInput element={Form.Control} minLength={2} debounceTimeout={500} onChange={e => setSearchString(e.target.value)} />

            <ListGroup as="ol">
                {magicItems.map(magicItem => {
                    return <ListGroup.Item as="li" key={magicItem.name.eng} ><MagicItemListItem magicItem={magicItem} /></ListGroup.Item>
                })}
            </ListGroup>
        </>
    );
}
