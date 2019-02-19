import React from 'react'
import PropTypes from 'prop-types'
import { Table } from 'react-bootstrap'
import Modal from '../../ModalDialog'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import { FlexBox, ModalContainer } from '../../elements/StyleDialogs/styled'
import { apiGetAllUsers, apiUpdatePassword } from '../../../../api/user'
import { ContextMenu, MenuItem, ContextMenuTrigger } from "react-contextmenu";

import PasswordWindow from './PasswordWindow'

import { Container, Content } from './styled'


class UserList extends React.Component {
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
      <Modal show={this.props.show} onHide={this.props.onHide}>
        <ModalContainer ref="ModalContainer">
          <Container>
            <FormHead text="Список пользователей" handleClick={this.props.onHide} />
            <FlexBox>
              <Content >
                <Table bordered condensed hover>
                  <thead>
                    <tr>
                      <td>
                        №
                      </td>
                      <td>
                        Логин
                      </td>
                    </tr>
                  </thead>
                  <tbody>
                    {
                      users && this.refs.ModalContainer && users.map((ob, num) => {
                        return (
                          <ContextMenuTrigger
                            renderTag="tr"
                            id="userMenu"
                            login={ob.login}
                            key={ob.id}
                            collect={this.collect}
                            posX={this.refs.ModalContainer.offsetParent.offsetParent.offsetLeft}
                            posY={this.refs.ModalContainer.offsetParent.offsetParent.offsetTop}
                          >
                            <td>
                              {num}
                            </td>
                            <td>
                              {ob.login}
                            </td>
                          </ContextMenuTrigger>
                        )
                      })
                    }

                  </tbody>
                </Table>

              </Content>
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
          </Container>
        </ModalContainer>
      </Modal>
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