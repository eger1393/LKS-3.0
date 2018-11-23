import React from 'react'

import { Navbar, Nav, NavItem, NavDropdown, MenuItem } from 'react-bootstrap'

import { Container } from './styled'
import CreateTroop from '../../../_common/dialogs/CreateTroop'

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
    //onHide={this.click('TroopCreate')}
    render() {
        return (
            <Container>
                <Navbar fixedTop onSelect={this.click}>
                    <Nav>
                        <NavItem eventKey={'AddStudent'}>
                            Добавить студентов
                    </NavItem>
                        <NavDropdown title="Преподователи">
                            <MenuItem eventKey={'PrepodCreate'}>Добавить преподавателя</MenuItem>
                            <MenuItem eventKey={'PrepodList'}>Список преподавателей</MenuItem>
                        </NavDropdown>
                        <NavDropdown title="Взвода">
                            <MenuItem eventKey={'TroopCreate'}>Создать взвод</MenuItem>
                            {this.state.openModalWindow['TroopCreate'] && (
                                <CreateTroop show={this.state.openModalWindow['TroopCreate']} onHide={() => this.click('TroopCreate')} />
                            )}
                            <MenuItem eventKey={'TroopList'}>Список взводов</MenuItem>
                        </NavDropdown>
                        <NavDropdown title="Отчеты">
                            <MenuItem eventKey={'ReportsVUS'}>ВУЗ</MenuItem>
                            <MenuItem eventKey={'XZ'}>еще что то</MenuItem>
                        </NavDropdown>
                    </Nav>
                </Navbar>
            </Container>
        );
    }
}

export default NavBar