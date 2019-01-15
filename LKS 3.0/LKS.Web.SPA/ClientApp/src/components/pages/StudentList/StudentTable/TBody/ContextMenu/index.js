import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { fetchSetStudentStatus, fetchSetStudentPosition } from '../../../../../../redux/modules/studentList'
import { fetchSetStudent } from '../../../../../../redux/modules/AddStudent'
import CreateStudent from '../../../../../_common/dialogs/CreateStudent'
import { ContextMenu, MenuItem, SubMenu } from "react-contextmenu";
import { Container } from './styled'

class Menu extends React.Component {
    state = {
        openModalWindowStudentCreate: false,
    }

    OnClick = () => {
        this.setState(prevState => ({
            openModalWindowStudentCreate: !prevState.openModalWindowStudentCreate,
        }))
    }

    menuClick = async (e, data) => {
        switch (data.type) {
            case 'editStudent':
                {
                    await this.props.fetchSetStudent({ id: data.id });
                    this.OnClick();
                    break;
                }
            case 'changeStatus':
                {
                    //apiSetStudentStatus({ id: data.id, status: data.status });
                    this.props.fetchSetStudentStatus({ id: data.id, status: data.status });
                    console.log('changeStatus');
                    break;
                }
            case 'changPosition':
                {
                    this.props.fetchSetStudentPosition({ id: data.id, position: data.position });
                    console.log('changePosition')
                    break;
                }
            default:
        }
    }

    render() {
        return (
            <Container>
                <ContextMenu id="stydentMenu">
                    <MenuItem onClick={this.menuClick} data={{ type: 'editStudent' }}>Редактировать студента</MenuItem>
                    <SubMenu title='Сменить статус'>
                        <MenuItem onClick={this.menuClick} data={{ type: 'changeStatus', status: 0 }}>обучается</MenuItem>
                        <MenuItem onClick={this.menuClick} data={{ type: 'changeStatus', status: 1 }}>на отчисление</MenuItem>
                        <MenuItem onClick={this.menuClick} data={{ type: 'changeStatus', status: 2 }}>отстраненый</MenuItem>
                        <MenuItem onClick={this.menuClick} data={{ type: 'changeStatus', status: 3 }}>на сборах</MenuItem>
                        <MenuItem onClick={this.menuClick} data={{ type: 'changeStatus', status: 4 }}>прошел сборы</MenuItem>
                    </SubMenu>
                    <SubMenu title='Сменить должность'>
                        <MenuItem onClick={this.menuClick} data={{ type: 'changPosition', position: 0 }}>командир взвода</MenuItem>
                        <MenuItem onClick={this.menuClick} data={{ type: 'changPosition', position: 1 }}>командир 1 отделения</MenuItem>
                        <MenuItem onClick={this.menuClick} data={{ type: 'changPosition', position: 2 }}>командир 2 отделения</MenuItem>
                        <MenuItem onClick={this.menuClick} data={{ type: 'changPosition', position: 3 }}>командир 3 отделения</MenuItem>
                        <MenuItem onClick={this.menuClick} data={{ type: 'changPosition', position: 4 }}>журналист</MenuItem>
                        <MenuItem onClick={this.menuClick} data={{ type: 'changPosition', position: 5 }}>секретчик</MenuItem>
                    </SubMenu>
                </ContextMenu>
                {this.state.openModalWindowStudentCreate && (
                    <CreateStudent show={this.state.openModalWindowStudentCreate} onHide={this.OnClick}/>
                )}
            </Container>
        );
    }
}

Menu.props = {
    fetchSetStudentStatus: PropTypes.func,
    fetchSetStudentPosition: PropTypes.func,
    fetchSetStudent: PropTypes.func,
}

export default connect(null, { fetchSetStudentStatus, fetchSetStudentPosition, fetchSetStudent })(Menu);