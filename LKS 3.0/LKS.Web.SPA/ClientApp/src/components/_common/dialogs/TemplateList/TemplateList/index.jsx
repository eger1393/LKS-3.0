import React, {useState, useEffect} from 'react'
import Item from '../Item'

import { BackButtonStyled, TitleStyled } from '../styled';
import TemplateListStore from '../../../../../Store/templateListStore'
import { observer } from 'mobx-react'

const TemplateList = props => {
    const [templateList, setTemplateList] = useState();
    useEffect(() =>{
        setTemplateList([
            {id: '1', name: 'Ведомость', type:'singleTroop'},
            {id: '2', name: 'Нормативы', type:'manyTroop'},
            {id: '3', name: 'Присяга', type:'singleStydent'},
            {id: '4', name: 'Список взвода', type:'manyStydent'},
            {id: '5', name: 'Журналы', type:''},
        ])
    }, [])

    const handleSelect = template => () => {
        TemplateListStore.selectedTemplate = template;
        TemplateListStore.displayedContent = 'AdditionalInfo';
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
                    templateList && templateList.map(template =>
                        <Item key={template.id} onClick={handleSelect(template)}>{template.name}</Item>)
                ) || (
                    <div>Загрузка категорий</div>
                )
            }
        </>
    );
}

export default observer(TemplateList);