import React from 'react'

import { fieldArr } from '../../../../../constants/studentTable'

import { Container } from './styled'

const THead = () => {
  return (
    <Container>
      <tr>
        <td>Фамилия</td>
        <td>Имя</td>
        <td>Отчество</td>

        {fieldArr.map(val => {
          return (
            <td>
              {val.value}
            </td>
          );
        })}
      </tr>
    </Container>
  );
}


export default THead