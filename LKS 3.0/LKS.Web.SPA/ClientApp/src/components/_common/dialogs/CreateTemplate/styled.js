import styled from 'styled-components'

export const Container = styled.div`
 
.custom-style > 
div:first-child{
        width: 100%;
        height: 40px;
        border-radius: 1px;
        border: none;
        border-bottom: ${props => props.error ? "solid 1px red" : "1px solid #d8d8d8"};
        color: #1b1e2d;
        font-size: 14px;
        color: black;
        font-weight: 300;

            div:first-child{
                padding : 0px;
                color: #1b1e2d;
            }
            div:nth-child(2){
                    span:first-child{
                    background-color: hsla(0, 0%, 0%, 0);
                    } 
            }
      }

`

export const ErrorInput = styled.div`
    width: 100% !important;
        height: 40px !important;
        border-radius: 1px !important;
        border: none !important;
        border-bottom: ${props => props.error ? "solid 1px red" : "1px solid #d8d8d8"} !important;
        color: #1b1e2d !important;
        font-size: 14px !important;
        color: black !important;
        font-weight: 300 !important;
`