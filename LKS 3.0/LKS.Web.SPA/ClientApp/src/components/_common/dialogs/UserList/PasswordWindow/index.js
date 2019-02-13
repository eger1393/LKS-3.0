import React from 'react'
import PropTypes from 'prop-types'
import { Modal, Table } from 'react-bootstrap'
import FormHead from '../../../elements/FormHead'
import Button from '../../../elements/Button'
import { ModalContainer } from '../../../elements/StyleDialogs/styled'

import { Container } from './styled'

const PasswordWindow = props => (
    <Modal show={props.show} onHide={props.onHide}>
    <ModalContainer>
      <div style={{ display: 'flex', alignItems: 'center', flexDirection: 'column' }}>
      <FormHead text="Список взводов" handleClick={props.onHide} />
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
        </div>
      </ModalContainer>
    </Modal>
)

PasswordWindow.props = {
  show: PropTypes.bool,
  onHide: PropTypes.func,
  login: PropTypes.str,
  password: PropTypes.str,
}

export default PasswordWindow;
