import styled from 'styled-components'

export const FlexBox = styled.div`
    display: flex;
    flex-direction: column;
`

export const FlexRow = styled.div`
    display: flex;
    flex-direction: row;
    margin-top: 40px;
    justify-content: space-between;

    &>:first-child{
      margin-right: 40px;
    }

    & > * {
        width: 210px;
    }
`

export const ModalContainer = styled.div`
    
`