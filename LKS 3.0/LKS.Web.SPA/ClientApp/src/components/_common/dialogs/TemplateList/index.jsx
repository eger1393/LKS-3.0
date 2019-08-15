import React, { useState } from 'react'
import ModalDialog from '../../ModalDialog'
import Button from '../../elements/Button'
import { FlexBox, } from '../../elements/StyleDialogs/styled'
import CategoryList from './CategoryList'
import SubCategoryList from './SubCategoryList'
import TemplateListItems from './TemplateList'

const TemplateList = props => {
    const [displayedContent, setDisplayedContent] = useState('CategoryList')
    const [payload, setPayload] = useState({});
    let content = <div>error</div>;
    const handleBack = contentType => () => setDisplayedContent(contentType);
    const handleSelect = contentType => payload => () =>{
        setDisplayedContent(contentType);
        setPayload(payload);
    } 
    switch (displayedContent) {
        case 'CategoryList':
            content = <CategoryList handleSelect={handleSelect("SubCategoryList")}/>
            break;
        case 'SubCategoryList':
            content = <SubCategoryList handleBack={handleBack('CategoryList')} handleSelect={handleSelect("TemplateListItems")} payload={payload} />
            break;
        case 'TemplateListItems':
            content = <TemplateListItems handleBack={handleBack('SubCategoryList')} payload={payload} />
            break;
    }
    return (
        <ModalDialog
            show={props.show}
            onHide={props.onHide}
            header="Список шаблонов"
        >
            <FlexBox>
                {content}
            </FlexBox>
        </ModalDialog>
    );
}

export default TemplateList;