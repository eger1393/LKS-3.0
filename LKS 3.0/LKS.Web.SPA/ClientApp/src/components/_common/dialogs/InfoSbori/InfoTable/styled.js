import styled from 'styled-components'

export const Container = styled.thead`
    th{
        width: 100px;
        height: 35px;
        padding-right: 10px;
        
        input {
            
        }
    }
    tr{
        border: solid black 1px;
        & > * > *:nth-child(1){
            display: flex;
            justify-content: center;
            align-items: center;
        }

        & > * {
            padding-left: 5px;
        }
    }
`