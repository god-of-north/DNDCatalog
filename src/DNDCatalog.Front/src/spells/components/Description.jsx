import React from 'react';
import { Row, Col } from 'react-bootstrap';

import { DescriptionItem } from './DescriptionItem';

import ReactSummernote from "react-summernote";
import "react-summernote/dist/react-summernote.css"; // import styles
import "bootstrap/js/dist/modal";
import "bootstrap/js/dist/dropdown";
import "bootstrap/js/dist/tooltip";
import "bootstrap/dist/css/bootstrap.css";

export const Description = ({translation, eng, ru1, ru2, ua1, ua2, setTranslation}) =>{

    return (
        <Row>
            <Col>
                {eng!=="" && <DescriptionItem description={eng} onCopyClicked={(d) => setTranslation(d)}/> }
                {ru1!=="" && <DescriptionItem description={ru1} onCopyClicked={(d) => setTranslation(d)}/> }
                {ru2!=="" && <DescriptionItem description={ru2} onCopyClicked={(d) => setTranslation(d)}/> }
                {ua1!=="" && <DescriptionItem description={ua1} onCopyClicked={(d) => setTranslation(d)}/> }
                {ua2!=="" && <DescriptionItem description={ua2} onCopyClicked={(d) => setTranslation(d)}/> }
            </Col>
            <Col>
                {/* <RichEditorExample text={translation}/> */}

                <ReactSummernote
                    value={translation}
                    options={{
                        height: 350,
                        dialogsInBody: true,
                        toolbar: [
                            ["style", ["style"]],
                            ["font", ["bold", "underline", "clear"]],
                            ["para", ["ul", "ol", "paragraph"]],
                            ["table", ["table"]],
                            ["insert", ["link"]]
                        ]
                    }}
                    onChange={(e)=> setTranslation(e)}
                />
            </Col>
        </Row>
    );
  }

