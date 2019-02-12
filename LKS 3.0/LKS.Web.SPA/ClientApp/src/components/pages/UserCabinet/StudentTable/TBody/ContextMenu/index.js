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
            default:
        }
    }

    render() {
        return (
            <Container>
                <ContextMenu id="stydentMenu">
                    <MenuItem onClick={this.menuClick} data={{ type: 'editStudent' }}>Редактировать студента</MenuItem>
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