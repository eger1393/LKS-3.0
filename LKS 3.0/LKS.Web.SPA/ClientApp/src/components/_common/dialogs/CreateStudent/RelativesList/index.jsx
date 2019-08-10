import React from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import { Table } from 'react-bootstrap'
import Button from '../../../elements/Button'
import { getAddStudentRelatives } from '../../../../../selectors/addStudent'
import { FlexBox } from '../../../elements/StyleDialogs/styled'
import { ContextMenu, MenuItem, ContextMenuTrigger } from "react-contextmenu";
import { Container, Contant, ButtonStyle } from './styled'
import CreateRelative from '../CreateRelative'

class RelativesList extends React.Component {
    state = {
        relativesWindowIsOpen: false,
        selectRelativeIndex: undefined,
    }
    toggleWindow = () => {
        this.setState(prevState => ({ relativesWindowIsOpen: !prevState.relativesWindowIsOpen }))
    }
    menuClick = async (e, data) => {
        switch (data.type) {
            case 'editRelative':
                {
                    await this.setState({ selectRelativeIndex: data.RelativeIndex });
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
    collect = attr => ({
        RelativeIndex: attr.relativeIndex,
    })
    render() {
        const { currentRelatives } = this.props;
        return (
            <>
                <FlexBox>
                    <Contant>
                        <Table bordered condensed hover>
                            <thead>
                                <tr>
                                    <td>Фамилия</td>
                                    <td>Имя</td>
                                    <td>Отчество</td>
                                    <td>Степень родства</td>
                                    <td>Состояние здоровья</td>
                                    <td>Дата рождения</td>
                                    <td>Мобильный телефон</td>
                                </tr>
                            </thead>
                            <tbody>
                                {

                                    currentRelatives && currentRelatives.map(function (ob, i) {
                                        {
                                            return (
                                                <ContextMenuTrigger
                                                    renderTag="tr"
                                                    id="relativeMenu"
                                                    relativeIndex={i}
                                                    key={i}
                                                    collect={this.collect}
                                                //posX={this.refs.ModalContainer.offsetParent.offsetParent.offsetLeft}
                                                //posY={this.refs.ModalContainer.offsetParent.offsetParent.offsetTop}
                                                >
                                                    <td>{ob.lastName}</td>
                                                    <td>{ob.firstName}</td>
                                                    <td>{ob.middleName}</td>
                                                    <td>{ob.relationDegree}</td>
                                                    <td>{ob.healthStatus}</td>
                                                    <td>{ob.birthday}</td>
                                                    <td>{ob.mobilePhone}</td>
                                                </ContextMenuTrigger>
                                            )
                                        }
                                    }, this)
                                }
                            </tbody>
                        </Table>

                    </Contant>
                </FlexBox>
                <ButtonStyle>
                    <Button onClick={this.toggleWindow} value="Создать" />
                </ButtonStyle>
                <ContextMenu id="relativeMenu">
                    <MenuItem onClick={this.menuClick} data={{ type: 'editRelative' }}>Редактировать данные</MenuItem>
                    <MenuItem onClick={this.menuClick} data={{ type: 'deleteRelative' }}>Удалить родственника</MenuItem>
                </ContextMenu>
                {this.state.relativesWindowIsOpen && (
                    <CreateRelative
                        show={this.state.relativesWindowIsOpen}
                        onHide={this.toggleWindow}
                        relativeIndex={this.state.selectRelativeIndex}
                    />
                )}
            </>
        );
    }
}

RelativesList.props = {
    currentRelatives: PropTypes.array,
}

RelativesList.state = {
    relativesWindowIsOpen: PropTypes.func,
    editedRelativeId: PropTypes.string,
}

function mapStateToProps(store) {
    return {
        currentRelatives: getAddStudentRelatives(store),
    }
}

export default connect(mapStateToProps, null)(RelativesList)