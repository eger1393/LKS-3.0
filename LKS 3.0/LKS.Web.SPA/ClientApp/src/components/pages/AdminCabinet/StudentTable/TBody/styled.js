﻿import styled from 'styled-components'

export const Container = styled.tbody`
    
    .react-contextmenu {
        background-color: #fff;
        background-clip: padding-box;
        border: 1px solid rgba(0,0,0,.15);
        border-radius: .25rem;
        color: #373a3c;
        font-size: 14px;
        margin: 2px 0 0;
        min-width: 160px;
        outline: none;
        opacity: 0;
        padding: 5px 0;
        pointer-events: none;
        text-align: left;
        transition: opacity 250ms ease !important;
    }

    .react-contextmenu.react-contextmenu--visible {
        opacity: 1;
        pointer-events: auto;
        z-index: 9999;
    }

    .react-contextmenu-item {
        background: 0 0;
        border: 0;
        color: #373a3c;
	    cursor: pointer;
        font-weight: 400;
        line-height: 1.5;
        padding: 3px 20px;
        text-align: inherit;
        white-space: nowrap;
    }

    .react-contextmenu-item.react-contextmenu-item--active,
    .react-contextmenu-item.react-contextmenu-item--selected {
        color: #fff;
        background-color: #20a0ff;
        border-color: #20a0ff;
        text-decoration: none;
    }

    .react-contextmenu-item.react-contextmenu-item--disabled,
    .react-contextmenu-item.react-contextmenu-item--disabled:hover {
        background-color: transparent;
        border-color: rgba(0,0,0,.15);
        color: #878a8c;
    }

    .react-contextmenu-item--divider {
        border-bottom: 1px solid rgba(0,0,0,.15);
        cursor: inherit;
        margin-bottom: 3px;
        padding: 2px 0;
    }
    .react-contextmenu-item--divider:hover {
        background-color: transparent;
        border-color: rgba(0,0,0,.15);
    }

    .react-contextmenu-item.react-contextmenu-submenu {
	    padding: 0;
    }

    .react-contextmenu-item.react-contextmenu-submenu > .react-contextmenu-item {
    }

    .react-contextmenu-item.react-contextmenu-submenu > .react-contextmenu-item:after {
        content: "▶";
        display: inline-block;
        position: absolute;
        right: 7px;
    }

`

export const Row = styled.tr`
    .select-color{
         color: ${props => getColor(props.Status)};
    }
    //.fixed-column{
    //    position: fixed;
    //}
`

function getColor(status) {
  switch (status) {
    case 0:
    case 'train': // Обучается
      return 'black';
    case 1:
    case 'forDeductions': // На отчисление
      return '#f7f447';
    case 2:
    case 'suspended': // Отстранен
      return '#e84a4a';
    case 3:
    case 'trainingFees': // На сборах
      return '#81e84e';
    case 4:
    case 'completedFees': // Прошел сборы
      return '#4de8d0';
    default:
      console.log('ошибка в цвете статуса');
      return 'white';
  }
}