import React, { useState } from 'react'
import ModalDialog from '../../ModalDialog'
import Button from '../../elements/Button'
import { FlexBox, } from '../../elements/StyleDialogs/styled'
import CategoryList from './CategoryList'
import SubCategoryList from './SubCategoryList'
import TemplateListItems from './TemplateList'
import AdditionalInfo from './AdditionalData'

import TemplateListStore from '../../../../Store/templateListStore'
import { observer } from 'mobx-react'

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

export default observer(TemplateList);