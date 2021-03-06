import React, { useRef } from 'react'
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
    const modalRef = useRef(null)
    switch (TemplateListStore.displayedContent) {
        case 'SubCategoryList':
            content = <SubCategoryList />
            break;
        case 'TemplateListItems':
            content = <TemplateListItems modalRef={modalRef}/>
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
        TemplateListStore.setDefaultValue();
        props.onHide();
    }
    return (
        <ModalDialog
            show={props.show}
            onHide={handleHide}
            header="Список шаблонов"
            crossOnly={true}
            modalRef={modalRef}
        >
            <FlexBox>
                {content}
            </FlexBox>
        </ModalDialog>
    );
}

export default observer(TemplateList);