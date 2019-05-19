import styled from 'styled-components'

export const Container = styled.div`

    .flex-box > div{
        margin-top: 20px !important;
    }
`
export const ModalContainer = styled.div`
    height: 300px;
    width: 400px;
    position: relative;
    padding: 25px;
    box-shadow: 0 0 6px 0 rgba(0, 0, 0, 0.09);
    border-radius: 2.5px;
    background-color: #ffffff;
    border: solid 0.3px rgba(210, 210, 210, 0.51);
    display: flex;
    flex-direction: column;
    justify-content: space-between;
`
export const ModalBody = styled.div`
    display: flex;
    conten-alogn: center;
`
export const ModalFooter = styled.div`
    justify-content: space-around;
    display: flex;
`