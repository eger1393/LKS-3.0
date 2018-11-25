import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { getStudentListData, getStudentListFields } from '../../../../../selectors/studentList'

import { ContextMenuTrigger } from 'react-contextmenu'

import Menu from './ContextMenu'

import { Container, Row } from './styled'

class TBody extends React.Component {

    collect = props => ({
        id: props.stydentId,
    })

    postionEnum = pos => {
        switch (pos) {
            case 0:
                return 'Командир взвода';
            case 1:
                return 'Командир 1 отделения';
            case 2:
                return 'Командир 2 отделения';
            case 3:
                return 'Командир 3 отделения';
            case 4:
                return 'Журналист';
            case 5:
                return 'Секретчик';
            default:
        }
    }

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
                                                {field.name === 'position' ? this.postionEnum(ob[field.name]) : ob[field.name]}
                                            </td>
                                        )
                                    })
                                }
                            </ContextMenuTrigger>
                        )
                    })
                )}
                <Menu />
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