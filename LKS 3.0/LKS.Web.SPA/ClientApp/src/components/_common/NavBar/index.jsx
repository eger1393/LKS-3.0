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
import CreatePrepod from '../dialogs/CreatePrepod'
import PrepodList from '../dialogs/PrepodList'
import TemplateList from '../dialogs/TemplateList'
import CreateTemplate from '../dialogs/CreateTemplate';
import CreateSbory from '../dialogs/CreateSbory'
import InfoSbori from '../dialogs/InfoSbori';


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
                            <NavDropdown title="Преподаватели">
                                <MenuItem eventKey={'PrepodCreate'}>Добавить преподавателя</MenuItem>
                                {this.state.openModalWindow.PrepodCreate && (
                                    <CreatePrepod show={this.state.openModalWindow.PrepodCreate} onHide={() => this.click('PrepodCreate')} />
                                )}
                                <MenuItem eventKey={'PrepodList'}>Список преподавателей</MenuItem>
                                {this.state.openModalWindow.PrepodList && (
                                    <PrepodList show={this.state.openModalWindow.PrepodList} onHide={() => this.click('PrepodList')} />
                                )}
                            </NavDropdown>
                            <NavDropdown title="Отчеты">
                                <MenuItem eventKey={'CreateNewTemplate'}>Добавить шаблон</MenuItem>
                                {this.state.openModalWindow.CreateNewTemplate && (
                                    <CreateTemplate show={this.state.openModalWindow.CreateNewTemplate} onHide={() => this.click('CreateNewTemplate')} />
                                )}
                                {/* <MenuItem eventKey={'ReportsVUS'}>ВУЗ</MenuItem>
                                {this.state.openModalWindow.ReportsVUS && (
                                    <CreateUniversityTemplate show={this.state.openModalWindow.ReportsVUS} onHide={() => this.click('ReportsVUS')} />
                                )} */}
                                <MenuItem eventKey={'TemplateList'}>Список шаблонов</MenuItem>
                                {this.state.openModalWindow.TemplateList && (
                                    <TemplateList show={this.state.openModalWindow.TemplateList} onHide={() => this.click('TemplateList')} />
                                )}
                            </NavDropdown>
                            <NavDropdown title="Сборы">
                            <MenuItem eventKey={'InfoSbori'}>Информация о сборах</MenuItem>
                                {this.state.openModalWindow.InfoSbori && (
                                    <InfoSbori show={this.state.openModalWindow.InfoSbori} onHide={() => this.click('InfoSbori')} />
                                )}
                            </NavDropdown>
                            <NavDropdown title="Сборы">
                            <MenuItem eventKey={'CreateSbory'}>Сформировать сборы</MenuItem>
                                {this.state.openModalWindow.CreateSbory && (
                                    <CreateSbory show={this.state.openModalWindow.CreateSbory} onHide={() => this.click('CreateSbory')} />
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