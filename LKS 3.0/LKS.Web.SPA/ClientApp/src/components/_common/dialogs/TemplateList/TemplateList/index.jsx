import React, { useState, useEffect } from 'react'
import Item from '../Item'

import { BackButtonStyled, TitleStyled } from '../styled';
import TemplateListStore from '../../../../../Store/templateListStore'
import { observer } from 'mobx-react'
import { apiGetTemplateList, apiDeleteTemplate } from '../../../../../api/templates'
import { ContextMenu, MenuItem, ContextMenuTrigger } from "react-contextmenu";

const TemplateList = props => {
    const [templateList, setTemplateList] = useState();
    useEffect(() => {
        apiGetTemplateList(TemplateListStore.subCategoryId)
            .then(data => setTemplateList(data))
        // setTemplateList([
        //     {id: '1', name: 'Ведомость', type:'singleTroop'},
        //     {id: '2', name: 'Нормативы', type:'manyTroops'},
        //     {id: '3', name: 'Присяга', type:'singleStudent'},
        //     {id: '4', name: 'Список взвода', type:'manyStudents'},
        //     {id: '5', name: 'Журналы', type:''},
        // ])
    }, [])

    const handleSelect = template => () => {
        TemplateListStore.selectedTemplate = template;
        TemplateListStore.displayedContent = 'AdditionalInfo';
    }

    const menuClick = (e, data) => {
        apiDeleteTemplate(data.id).then(() => TemplateListStore.displayedContent = 'CategoryList');
        
    }

    return (
        <>
            <TitleStyled>
                <BackButtonStyled
                    onClick={() => TemplateListStore.displayedContent = 'SubCategoryList'}
                >&#9668;</BackButtonStyled>Выберите шаблон
            </TitleStyled>
            {
                (
                    templateList && templateList.map(template => (
                        <ContextMenuTrigger
                            renderTag="tr"
                            id="prepodMenu"
                            key={template.id}
                            templateId={template.id}
                            collect={props => ({id: props.templateId})}
                            posX={props.modalRef.current.getBoundingClientRect().left - 15}
                            posY={props.modalRef.current.getBoundingClientRect().top - 7}
                        >
                            <Item onClick={handleSelect(template)}>{template.name}</Item>
                        </ContextMenuTrigger>))
                ) || (
                    <div>Загрузка категорий</div>
                )
            }
            <ContextMenu id="prepodMenu">
                <MenuItem onClick={menuClick} data={{ type: 'deletePrepod' }}>Удалить шаблон</MenuItem>
            </ContextMenu>
        </>
    );
}

export default observer(TemplateList);