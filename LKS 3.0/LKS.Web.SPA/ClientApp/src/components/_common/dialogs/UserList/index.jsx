import React, { createRef } from 'react'
import PropTypes from 'prop-types'
import { Table } from 'react-bootstrap'
import ModalDialog from '../../ModalDialog'
import Button from '../../elements/Button'
import { FlexBox } from '../../elements/StyleDialogs/styled'
import { apiGetAllUsers, apiUpdatePassword } from '../../../../api/user'
import { ContextMenu, MenuItem, ContextMenuTrigger } from "react-contextmenu";

import PasswordWindow from './PasswordWindow'


class UserList extends React.Component {
  constructor(props) {
    super(props)
    this.modalRef = createRef()
  }
  state = {
    passwordWindowIsOpen: false,
    users: [],
    selectedUser: '',
    password: '',
  }

  toggleWindow = () => {
    this.setState(prevState => ({ passwordWindowIsOpen: !prevState.passwordWindowIsOpen }))
  }

  componentDidMount() {
    const self = this;
    apiGetAllUsers().then(users => self.setState({ users: users }))
  }

  collect = props => ({
    id: props.login,
  })

  menuClick = (e, data) => {
    switch (data.type) {
      case 'updatePassword':
        {
          const self = this;
          apiUpdatePassword(data.id).then(data =>
            self.setState({ passwordWindowIsOpen: true, selectedUser: data.login, password: data.password })
          )
          break;
        }
      default:
    }
  }

  render() {
    const { users, passwordWindowIsOpen, password, selectedUser } = this.state;
    return (
      <ModalDialog
        show={this.props.show}
        onHide={this.props.onHide}
        header="Список пользователей"
        modalRef={this.modalRef}
      >
        <FlexBox>
          <Table bordered condensed hover>
            <thead>
              <tr>
                <td>№</td>
                <td>Логин</td>
              </tr>
            </thead>
            <tbody>
              {
                users && this.modalRef.current && users.map((ob, num) => {
                  return (
                    <ContextMenuTrigger
                      renderTag="tr"
                      id="userMenu"
                      login={ob.login}
                      key={ob.id}
                      collect={this.collect}
                      posX={this.modalRef.current.getBoundingClientRect().left - 15}
                      posY={this.modalRef.current.getBoundingClientRect().top - 7}
                    >
                      <td>{num + 1}</td>
                      <td>{ob.login}</td>
                    </ContextMenuTrigger>
                  )
                })
              }

            </tbody>
          </Table>
        </FlexBox>

        <div className="form-submit">
          <Button onClick={this.props.onHide} value="Ок" />
        </div>
        <ContextMenu id="userMenu">
          <MenuItem onClick={this.menuClick} data={{ type: 'updatePassword' }}>Новый пароль</MenuItem>
        </ContextMenu>
        {passwordWindowIsOpen && (
          <PasswordWindow
            show={passwordWindowIsOpen}
            onHide={this.toggleWindow}
            login={selectedUser}
            password={password}
          />
        )}
      </ModalDialog>
    );
  }
}

UserList.props = {
  show: PropTypes.bool,
  onHide: PropTypes.func,
}

UserList.state = {
  passwordWindowIsOpen: PropTypes.bool,
  users: PropTypes.array,
  selectedUser: PropTypes.str,
  password: PropTypes.str,
}

export default UserList