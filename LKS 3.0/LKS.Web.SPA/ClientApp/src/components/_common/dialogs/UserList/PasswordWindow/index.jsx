import React from 'react'
import PropTypes from 'prop-types'
import ModalDialog from '../../../ModalDialog'
import Button from '../../../elements/Button'

import { Container } from './styled';

const PasswordWindow = props => (
  <ModalDialog
    show={props.show}
    onHide={props.onHide}
    header="Список взводов"
  >
    <Container>
      <br />
      <span>
        Логин: {props.login}
      </span>
      <br />
      <span>
        Пароль: {props.password}
      </span>
      <br />
      <Button onClick={props.onHide} value="Ок" />
    </Container>
  </ModalDialog>
)

PasswordWindow.props = {
  show: PropTypes.bool,
  onHide: PropTypes.func,
  login: PropTypes.str,
  password: PropTypes.str,
}

export default PasswordWindow;
