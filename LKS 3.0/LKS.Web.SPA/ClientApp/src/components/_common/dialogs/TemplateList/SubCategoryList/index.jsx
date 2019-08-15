import React, { useEffect, useState } from 'react'
import Item from '../Item'

import { BackButtonStyled, TitleStyled } from '../styled';

const SubList = props => {
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
    return (
        <>
            <TitleStyled><BackButtonStyled onClick={props.handleBack}>&#9668;</BackButtonStyled>Выберите подкатегорию</TitleStyled>
            {(
                subCategotyList && subCategotyList.map(category =>
                    <Item key={category.id} onClick={props.handleSelect(category.id)}>{category.name}</Item>)
            ) || (
                    <div>Загрузка подкатегорий</div>
            )}
        </>
    );
}

export default SubList;