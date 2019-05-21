import React from 'react'
import { Navbar, Nav, NavItem, NavDropdown, MenuItem } from 'react-bootstrap'
import PropTypes from 'prop-types'
import { apiLogout } from '../../../api/user'
import { Container } from './styled'
import CreateTroop from '../dialogs/CreateTroop'
import CreateStudent from '../dialogs/CreateStudent'
import CreateUniversityTemplate from '../dialogs/CreateUniversityTemplate'
import TroopList from '../dialogs/TroopList'
import UserList from '../dialogs/UserList'


class NavBar extends React.Component {

  state = {
    openModalWindow: [],
  }

  click = (key) => { // work
    var val = !this.state.openModalWindow[key];
    if (key == 'Exit') {
      apiLogout();
    }
    else {
      this.setState(prevState => ({
        openModalWindow: { ...prevState.openModalWindow, [key]: val, }
      }))
    }
  }

  hide = data => {
    console.log(data);
  }

  render() {
    const isAdmin = localStorage.getItem('role') == 'Admin'
    if (isAdmin)
      return (
        <Container>
          <Navbar fixedTop onSelect={this.click}>
            <Nav>
              <NavItem eventKey={'StudentCreate'} >
                Добавить студента
            </NavItem>
              {this.state.openModalWindow.StudentCreate && (
                <CreateStudent show={this.state.openModalWindow.StudentCreate} onHide={() => this.click('StudentCreate')} />
              )}
              <NavDropdown title="Взвода">
                <MenuItem eventKey={'TroopCreate'}>Создать взвод</MenuItem>
                {this.state.openModalWindow.TroopCreate && (
                  <CreateTroop show={this.state.openModalWindow.TroopCreate} onHide={() => this.click('TroopCreate')} />
                )}
                <MenuItem eventKey={'TroopList'}>Список взводов</MenuItem>
                {this.state.openModalWindow.TroopList && (
                  <TroopList show={this.state.openModalWindow.TroopList} onHide={() => this.click('TroopList')} />
                )}
              </NavDropdown>
              <NavDropdown title="Отчеты">
                <MenuItem eventKey={'ReportsVUS'}>ВУЗ</MenuItem>
                {this.state.openModalWindow.ReportsVUS && (
                  <CreateUniversityTemplate show={this.state.openModalWindow.ReportsVUS} onHide={() => this.click('ReportsVUS')} />
                )}
              </NavDropdown>
              <NavItem eventKey={'UserList'} >
                Список пользователей
              </NavItem>
              {this.state.openModalWindow.UserList && (
                <UserList show={this.state.openModalWindow.UserList} onHide={() => this.click('UserList')} />
              )}
              <NavItem eventKey={'Exit'} style={{ position: 'absolute', right: '10px' }} >
                Выход
            </NavItem>
            </Nav>
          </Navbar>
        </Container>
      );
    else
      return (
        <Container>
          <Navbar fixedTop onSelect={this.click}>
            <Nav>
              <NavItem eventKey={'StudentCreate'} >
                Добавить студента
            </NavItem>
              {this.state.openModalWindow.StudentCreate && (
                <CreateStudent show={this.state.openModalWindow.StudentCreate} onHide={() => this.click('StudentCreate')} />
              )}
              <NavItem eventKey={'Exit'} style={{ position: 'absolute', right: '10px' }} >
                Выход
              </NavItem>
            </Nav>
          </Navbar>
        </Container>
        );
  }
}

export default NavBar