import React from 'react'
import { Navbar, Nav, NavItem, NavDropdown, MenuItem } from 'react-bootstrap'
import PropTypes from 'prop-types'
import { Container } from './styled'
import CreateTroop from '../../../_common/dialogs/CreateTroop'
import CreateStudent from '../../../_common/dialogs/CreateStudent'
import CreateUniversityTemplate from '../../../_common/dialogs/CreateUniversityTemplate'
import TroopList from '../../../_common/dialogs/TroopList'


class NavBar extends React.Component {

    state = {
        openModalWindow: [],
    }

    click = (key) => { // work
        var val = !this.state.openModalWindow[key];
        this.setState(prevState => ({
            openModalWindow: { ...prevState.openModalWindow, [key]: val, }
        }))
        
    }

    hide = data => {
        console.log(data);
    }

    render() {
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
                        <NavDropdown title="Преподаватели">
                            <MenuItem eventKey={'PrepodCreate'}>Добавить преподавателя</MenuItem>
                            <MenuItem eventKey={'PrepodList'}>Список преподавателей</MenuItem>
                        </NavDropdown>
                        <NavDropdown title="Взвода">
                            <MenuItem eventKey={'TroopCreate'}>Создать взвод</MenuItem>
                            { this.state.openModalWindow.TroopCreate && (
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
                    </Nav>
                </Navbar>
            </Container>
        );
    }
}

export default NavBar