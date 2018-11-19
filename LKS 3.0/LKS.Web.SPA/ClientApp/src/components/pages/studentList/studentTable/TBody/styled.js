import styled from 'styled-components'

export const Container = styled.tbody`
`

export const Row = styled.tr`
    background-color: ${props => getColor(props.Status)};
`

function getColor(status){
    switch (status) {
        case 0: // Обучается
            return 'white';
        case 1: // На отчисление
            return '#f7f447';
        case 2: // Отстранен
            return '#e84a4a';
        case 3: // На сборах
            return '#81e84e';
        case 4: // Прошел сборы
            return '#4de8d0';
        default:
            return 'white';
    }
}