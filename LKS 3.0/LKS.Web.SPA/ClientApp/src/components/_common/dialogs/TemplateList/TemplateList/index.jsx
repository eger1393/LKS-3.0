import React from 'react'
import Item from '../Item'

import { BackButtonStyled, TitleStyled } from '../styled';

const TemplateList = props => {
    return (
        <>
            <TitleStyled><BackButtonStyled onClick={props.handleBack}>&#9668;</BackButtonStyled>Выберите шаблон</TitleStyled>
            <Item onClick={props.handleSelect}>Присяга</Item>
            <Item onClick={props.handleSelect}>Мыло</Item>
            <Item onClick={props.handleSelect}>Ведомости</Item>
            <Item onClick={props.handleSelect}>Вкладыши в приписное</Item>
        </>
    );
}

export default TemplateList;