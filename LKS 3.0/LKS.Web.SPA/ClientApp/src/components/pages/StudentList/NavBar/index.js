import React from 'react'

import { Navbar, Nav, NavItem, NavDropdown, MenuItem } from 'react-bootstrap'

import { Container } from './styled'

class NavBar extends React.Component {

    clickItem = event => { //work
        console.log('1');
    }

    click = (key, event) => { // work
        console.log(key);
    }

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