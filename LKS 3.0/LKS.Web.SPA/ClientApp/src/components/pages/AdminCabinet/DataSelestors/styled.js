import styled from 'styled-components'

export const Container = styled.div`
    margin-bottom: 20px;
    border-bottom: 1px;
    
    .picky{
        width: 250px;
    }

    .picky__dropdown .option{
            padding: 4px;
        }
    }
`

export const Contant = styled.div`
    display: flex;
    flex-direction: row;

    select{
        margin-right: 30px;
    }
`

export const Legend = styled.div`
    display: flex;
    align-items: center;
    margin-right: 10px;
    &>*{
        margin-left: 10px;
    }

`