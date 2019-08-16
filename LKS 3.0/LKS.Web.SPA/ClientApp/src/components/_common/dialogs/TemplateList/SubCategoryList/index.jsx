import React, { useEffect, useState } from 'react'
import Item from '../Item'

import { BackButtonStyled, TitleStyled } from '../styled';
import TemplateListStore from '../../../../../Store/templateListStore'
import { observer } from 'mobx-react'

const SubCategoryList = props => {
    const [subCategotyList, setSubCategoryList] = useState()
    useEffect(() => {
        setSubCategoryList([
            { name: 'Экзамены', id: '0' },
            { name: '1 неделя', id: '1' },
            { name: '2 неделея', id: '2' },
            { name: 'Отчетные документы', id: '3' },
            { name: 'До сборов', id: '4' },
        ])
    }, [])

    const handleSelect = id => () => {
        TemplateListStore.subCategoryId = id;
        TemplateListStore.displayedContent = 'TemplateListItems';
    }

    return (
        <>
            <TitleStyled>
                <BackButtonStyled
                    onClick={() => TemplateListStore.displayedContent = 'CategoryList'}
                >&#9668;</BackButtonStyled>Выберите подкатегорию
            </TitleStyled>
            {(
                subCategotyList && subCategotyList.map(category =>
                    <Item key={category.id} onClick={handleSelect(category.id)}>{category.name}</Item>)
            ) || (
                    <div>Загрузка подкатегорий</div>
                )}
        </>
    );
}

export default observer(SubCategoryList);