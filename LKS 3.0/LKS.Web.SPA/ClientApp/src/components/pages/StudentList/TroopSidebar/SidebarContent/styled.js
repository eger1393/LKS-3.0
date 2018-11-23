import styled from 'styled-components'

export const Container = styled.div`
    padding: 0px 10px 0px 10px;

    .TroopItem{
        display: flex;
        justify-content: center;
        margin: 10px 0 10px 0;
        cursor: pointer;

        &:hover{
            font-weight: bold;
        }
    }
`