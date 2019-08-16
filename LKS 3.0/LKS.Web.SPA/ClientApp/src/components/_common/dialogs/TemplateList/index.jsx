import React, { useState, useEffect } from 'react'
import ModalDialog from '../../ModalDialog'
import Button from '../../elements/Button'
import { FlexBox, } from '../../elements/StyleDialogs/styled'
import CategoryList from './CategoryList'
import SubCategoryList from './SubCategoryList'
import TemplateListItems from './TemplateList'
import AdditionalInfo from './AdditionalData'

import TemplateListStore from '../../../../Store/templateListStore'
import { observer } from 'mobx-react'
import templateListStore from '../../../../Store/templateListStore';

const TemplateList = props => {
    let content;
    switch (TemplateListStore.displayedContent) {
        case 'SubCategoryList':
            content = <SubCategoryList />
            break;
        case 'TemplateListItems':
            content = <TemplateListItems />
            break;
        case 'AdditionalInfo':
            content = <AdditionalInfo />
            break;
        case 'CategoryList':
        default:
            content = <CategoryList />
            break;
    }
    const handleHide = () => {
        templateListStore.setDefaultValue();
        props.onHide();
    }
    return (
        <ModalDialog
            show={props.show}
            onHide={handleHide}
            header="Список шаблонов"
            crossOnly={true}
        >
            <FlexBox>
                {content}
            </FlexBox>
        </ModalDialog>
    );
}

export default observer(TemplateList);