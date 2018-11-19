import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { getStudentListData, getStudentListFields } from '../../../../../selectors/studentList'

import { Container } from './styled'

class TBody extends React.Component {

    render() {
        return (
            <Container>
                {this.props.studentData.length > 0 && (
                    this.props.studentData.map(ob => {
                        return (
                            <tr>
                                <td>
                                    {ob['lastName']}
                                </td>
                                <td>
                                    {ob['firstName']}
                                </td>
                                <td>
                                    {ob['middleName']}
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
                            </tr>
                        )
                    })
                )}
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