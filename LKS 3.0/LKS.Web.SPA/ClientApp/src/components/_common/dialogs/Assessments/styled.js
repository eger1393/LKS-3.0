import styled from 'styled-components';

export const DropDownContainerStyled = styled.div`
    display: flex;
    flex-direction: column;
    margin-bottom: 30px;
`

export const TableStyled = styled.table`
    tr{
        & > *:nth-child(1){
            display: flex;
            width: max-content;
            align-items: center;
            height: 100%;
            min-height: 100%;
            justify-content: center;
        }
    }
`