import React from 'react'
import { Container } from './styled'


const Button = ({
    value,
    onClick,
    disabled
}) => {
        return (<Container disabled={disabled} onClick={onClick}>
            {value}
        </Container>);
    }

export default Button