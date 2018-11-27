import styled from 'styled-components'

export const Container = styled.div`
    @media (min-width: 768px){  
        .navbar-nav{
            float: unset !important;
            margin: 7.5px -15px !important;
        }
    }
    
    a[role="tab"]{
        color: #555;
    }

    .flex-box>:first-child{
        margin-top: 15px;
    }
`

export const TemplateItem = styled.p`
    width: 260px;
    label{
        margin-left: 10px;
        cursor: pointer;
        font-size: 14px;
        font-weight: 300;
        color: #1b1e2d;
    }

    input[type="radio"]{
        cursor: pointer;
    }
`