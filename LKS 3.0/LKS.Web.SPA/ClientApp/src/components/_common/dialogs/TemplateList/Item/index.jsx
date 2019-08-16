import React from 'react';

import { ItemStyled } from './styled';
const Item = props => {
    return (
        <ItemStyled {...props}>{props.children}</ItemStyled>
    );
}

export default Item;