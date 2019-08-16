import styled from 'styled-components';

export const ItemStyled = styled.div`
    position: relative;
    margin-bottom: 10px;
    cursor: pointer;

    &:hover {
        font-weight: bolder;
    }
`

export const CloseStyled = styled.div`
    position: absolute;
    right: -8px;
    top: 8px;
    width: 14px;
    height: 14px;
    opacity: 0.3;
    cursor: pointer;

    &:hover {
        opacity: 1;
    }

    &:before, 
    &:after {
        position: absolute;
        content: ' ';
        height: 14px;
        width: 1px;
        background-color: #333;
    }

    &:before {
        transform: rotate(45deg);
    }

    &:after {
        transform: rotate(-45deg);
    }
`