import React from 'react'
import { Navbar, Nav, NavItem, NavDropdown, MenuItem } from 'react-bootstrap'
import PropTypes from 'prop-types'
import { apiLogout } from '../../../api/user'
import CreatePrepod from '../../_common/dialogs/CreatePrepod'
import PrepodList from '../../_common/dialogs/PrepodList'
import { Container } from './styled'

class MainAdminCabinet extends React.Component {
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

    render() {
        return (
            <Container>
                <Navbar fixedTop onSelect={this.click}>
                    <Nav>
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
                        <NavItem eventKey={'Exit'} style={{ position: 'absolute', right: '10px' }} >
                            Выход
                        </NavItem>
                    </Nav>
                </Navbar>
            </Container>
        );
    }
}

export default MainAdminCabinet