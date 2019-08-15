import React, { useEffect, useState } from 'react'
import Item from '../Item'

import { BackButtonStyled, TitleStyled } from '../styled';

const CategoryList = props => {
    const [categotyList, setCategoryList] = useState()
    useEffect(() => {
        setCategoryList([
            {name: 'Сборы', id: '0'},
            {name: 'Вуз', id: '1'},
            {name: 'общее', id: '2'},
            {name: 'Хрень', id: '3'},
            {name: 'Кафедра', id: '4'},
        ])
    }, [])
    return (
        <>
            <TitleStyled>Выберите категорию</TitleStyled>
            {
                (
                    categotyList && categotyList.map(category =>
                        <Item key={category.id} onClick={props.handleSelect(category.id)}>{category.name}</Item>)
                ) || (
                    <div>Загрузка категорий</div>
                )
            }
        </>
    );
}

export default CategoryList;