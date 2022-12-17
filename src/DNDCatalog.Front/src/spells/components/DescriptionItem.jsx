import React from 'react';
import { Button } from 'react-bootstrap';
import parse from 'html-react-parser'

export const DescriptionItem = ({description, onCopyClicked}) =>{

    return (
        <div>
            <div>
                {description.split("\n").map((i,key) => {
                    return <div key={key}>{parse(i)}</div>;
                })}
            </div>
            <Button onClick={()=>onCopyClicked("<p>"+description.replaceAll("\n", "</p><p>")+"</p>")}>Copy &gt;&gt;</Button>
        </div>
    );
  }

