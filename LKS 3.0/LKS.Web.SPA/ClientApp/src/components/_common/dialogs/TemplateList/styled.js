import styled from 'styled-components';

export const TitleStyled = styled.div`
    font-size: 25px;
    line-height: 1.12;
    letter-spacing: 0.4px;
    color: #14162c;
    position: relative;
    display: flex;
    justify-content: center;
    width: 100%;
    margin-bottom: 20px;
`

export const BackButtonStyled = styled.button`
    border: 1px solid;
    border-radius: 20px;
    width: 30px;
    height: 30px;
    font-size: 21px;
    font-weight: bold;
    line-height: 1;
    color: #000;
    text-shadow: 0 1px 0 #fff;
    opacity: 0.4;
    display: flex;
    justify-content: center;
    align-items: center;
    position: absolute;
    left: 0;
    background-color: white;

    &:hover{
        opacity: 0.8;
    }
    &:focus{
        outline:0;
    }
`