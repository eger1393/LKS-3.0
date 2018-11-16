import styled from 'styled-components'

export const Container = styled.div`
    width: 100%;
    height: 54px;
    position: relative;    
    display: flex;

     label {
        position: absolute;
        cursor: text;
        transform: translateY(-10px);
        transition: transform 0.3s ease;
        left: 0;
        bottom: 10px;;
    }

    input {
        width: 100%;
        height: 40px;
        transition: 0.6s;
        color: #1b1e2d;
        
        &:focus {
            outline: none;
            border-bottom: 1px solid #28a2a2;
        }
    }

    & span.red-star {
        font-family: OpenSans;
        font-size: 12px;
        font-weight: bold;
        color: #e85e5e;
    }

    &.animate label {
        transform: translateY(-40px);
        height: 12px;
        font-size: 12px;
        font-weight: 300;
        color: #aaaaaa;
    }

    &.invalid {
        input {
            outline: none;
            border-bottom: 1px solid #b73f4e !important;
        }

        .layer {
            display: inline;
        }
    }

    .layer {
        display: none;
        position: absolute;
        bottom: 20px;
        right: 8px;
        font-weight: 500;
        line-height: 1.43;
        letter-spacing: 0.2px;
        color: #b73f4e;
    }
}
`