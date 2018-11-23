import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { getStudentListData, getStudentListFields } from '../../../../../selectors/studentList'
import { ContextMenu, MenuItem, ContextMenuTrigger, SubMenu } from "react-contextmenu";

import { Container, Row } from './styled'

class TBody extends React.Component {

    handleClick = (e, data) => {
        switch (data.type) {
            case 'editStudent':
                {
                    console.log('editStudent');
                    break;
                }
            case 'changeStatus':
                {
                    console.log('changeStatus');
                    break;
                }
            case 'changeRank':
                {
                    console.log('changeRank')
                    break;
                }
            default:
        }
        console.log(data);
    }

    collect = props => ({
        id: props.stydentId,
    })

    render() {
        return (
            <Container>
                {this.props.studentData.length > 0 && (
                    this.props.studentData.map(ob => {
                        return (
                            <ContextMenuTrigger
                                renderTag={Row}
                                attributes={{ Status: ob.status }}
                                id="stydentMenu"
                                stydentId={ob.id}
                                key={ob.id}
                                collect={this.collect}
                            >
                                <td className="fixed-column select-color">
                                    {ob.lastName}
                                </td>
                                <td className="select-color">
                                    {ob.firstName}
                                </td>
                                <td className="select-color">
                                    {ob.middleName}
                                </td>
                                {
                                    this.props.selectedFields.map(field => {
                                        return (
                                            <td>
                                                {ob[field.name]}
                                            </td>
                                        )
                                    })
                                }
                            </ContextMenuTrigger>
                        )
                    })
                )}
                <ContextMenu id="stydentMenu">
                    <MenuItem onClick={this.handleClick} data={{ type: 'editStudent' }}>Редактировать студента</MenuItem>
                    <SubMenu title='Сменить статус'>
                        <MenuItem onClick={this.handleClick} data={{ type: 'changeStatus', status: 'train' }}>Обучается</MenuItem>
                        <MenuItem onClick={this.handleClick} data={{ type: 'changeStatus', status: 'forDeductions' }}>На отчисление</MenuItem>
                        <MenuItem onClick={this.handleClick} data={{ type: 'changeStatus', status: 'suspended' }}>Отстраненый</MenuItem>
                        <MenuItem onClick={this.handleClick} data={{ type: 'changeStatus', status: 'trainingFees' }}>На сборах</MenuItem>
                        <MenuItem onClick={this.handleClick} data={{ type: 'changeStatus', status: 'completedFees' }}>Прошел сборы</MenuItem>
                    </SubMenu>
                    <SubMenu title='Сменить должность'>
                        <MenuItem onClick={this.handleClick} data={{ type: 'changeRank', rank: '' }}>SubSubItem 1</MenuItem>
                        <MenuItem onClick={this.handleClick} data={{ type: 'changeRank', rank: '' }}>SubSubItem 1</MenuItem>
                        <MenuItem onClick={this.handleClick} data={{ type: 'changeRank', rank: '' }}>SubSubItem 1</MenuItem>
                        <MenuItem onClick={this.handleClick} data={{ type: 'changeRank', rank: '' }}>SubSubItem 1</MenuItem>
                        <MenuItem onClick={this.handleClick} data={{ type: 'changeRank', rank: '' }}>SubSubItem 1</MenuItem>
                    </SubMenu>
                </ContextMenu>
            </Container>
        );
    }
}

TBody.props = {
    studentData: PropTypes.array,
}

const mapStateToProps = state => ({
    selectedFields: getStudentListFields(state),
    studentData: getStudentListData(state),
})

export default connect(mapStateToProps)(TBody);