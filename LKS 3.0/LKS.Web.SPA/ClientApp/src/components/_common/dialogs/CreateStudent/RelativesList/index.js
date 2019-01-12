import React from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import { Modal, Table } from 'react-bootstrap'
import Button from '../../../elements/Button'
import { getAddStudentRelatives } from '../../../../../selectors/addStudent'
import { FlexBox, ModalContainer } from '../../../elements/StyleDialogs/styled'
import { ContextMenu, MenuItem, ContextMenuTrigger } from "react-contextmenu";
import { Container, Contant } from './styled'
import CreateRelative from '../CreateRelative'

class RelativesList extends React.Component {
    state = {
        relatives: this.props.currentRelatives,
        relativesWindowIsOpen: false,
        editedRelativeId: ''
    }
    toggleWindow = () => {
        this.setState(prevState => ({ relativesWindowIsOpen: !prevState.relativesWindowIsOpen }))
    }
    collect = props => ({
        id: props.RelativeId,
    })

    menuClick = (e, data) => {
        switch (data.type) {
            case 'editRelative':
                {
                    this.setState({ editedRelativeId: data.id });
                    this.toggleWindow();
                    console.log('editRelative');
                    break;
                }
            case 'deleteRelative':
                {
                    console.log('deleteRelative');
                    break;
                }
            default:
        }
    }
    setRelative = (data) => {
        this.setState(prevState => (
            {
                ...prevState,
                relatives: [
                    ...prevState.realtives,
                    { ...data.value }
                    ],
               
            }))
    }
    render() {
        const { relatives } = this.state;
        return (
                    <Container>
                        <FlexBox>
                            <Contant>
                                <Table bordered condensed hover>
                                    <thead>
                                        <tr>
                                            <td>
                                                Фамилия
                                            </td>
                                            <td>
                                                Имя
                                            </td>
                                            <td>
                                                Отчество
                                            </td>
                                            <td>
                                                Степень родства
                                            </td>
                                            <td>
                                                Дата рождения
                                            </td>
                                            <td>
                                                Мобильный телефон
                                            </td>
                                            <td>
                                                Адрес проживания
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {
                                            relatives && relatives.map(ob => {
                                                return (
                                                    <ContextMenuTrigger
                                                        renderTag="tr"
                                                        id="relativeMenu"
                                                        relativeId={ob.id}
                                                        key={ob.id}
                                                        collect={this.collect}
                                                    >
                                                        <td>
                                                            {ob.lastName}
                                                        </td>
                                                        <td>
                                                            {ob.firstName}
                                                        </td>
                                                        <td>
                                                            {ob.middleName}
                                                        </td>
                                                        <td>
                                                            {ob.relationDegree}
                                                        </td>
                                                        <td>
                                                            {ob.birthday}
                                                        </td>
                                                        <td>
                                                            {ob.mobilePhone}
                                                        </td>
                                                        <td>
                                                            {ob.placeOfResidence}
                                                        </td>
                                                    </ContextMenuTrigger>
                                                )
                                            })
                                        }

                                    </tbody>
                                </Table>

                            </Contant>
                        </FlexBox>
                        <div className="form-submit">
                            <Button onClick={this.toggleWindow} value="Создать" />
                        </div>
                        <ContextMenu id="troopMenu">
                            <MenuItem onClick={this.menuClick} data={{ type: 'editRelative' }}>Редактировать данные</MenuItem>
                            <MenuItem onClick={this.menuClick} data={{ type: 'deleteRelative' }}>Удалить родственника</MenuItem>
                        </ContextMenu>
                       {this.state.relativesWindowIsOpen && (
                    <CreateRelative
                        show={this.state.relativesWindowIsOpen}
                        onHide={this.toggleWindow}
                        setRelative={this.setRelative}
                     />
                        )}
                    </Container>
        );
    }
}

RelativesList.props = {
    currentRelatives: PropTypes.array,
}

RelativesList.state = {
    relatives: PropTypes.array,
    relativesWindowIsOpen: PropTypes.func,
    editedRelativeId: PropTypes.string,
}

function mapStateToProps(store) {
    return {
        currentRelatives: getAddStudentRelatives(store),
    }
}

export default connect(mapStateToProps, null)(RelativesList)