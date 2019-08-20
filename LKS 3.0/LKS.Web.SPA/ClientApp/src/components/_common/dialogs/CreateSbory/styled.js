import styled from 'styled-components';

export const DropDownContainerStyled = styled.div`
    display: flex;
    flex-direction: column;
    margin-bottom: 30px;
`
export const ColumnStule = styled.div`
    display: flex;
    flex-direction: column;
    min-width: 200px;
`

export const ContainerStyle = styled.div`
    display: flex;
    flex-direction: row;
    & > *:nth-child(2){
        margin-left: 30px;
        margin-right: 30px;
    }
`

export const ArrowContainerStyled = styled.div`
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
`

export const ArrowButton = styled.button`
    width:35px;
    margin-bottom: 20px;
    & > * {
        width:20px;
        height: 20px;
    }
`