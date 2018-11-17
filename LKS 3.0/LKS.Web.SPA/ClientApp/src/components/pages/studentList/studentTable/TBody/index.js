import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { getStudentListData } from '../../../../../selectors/studentList'

import { Container } from './styled'

class TBody extends React.Component {

    render() {
        // Захардкодил поля, потом они будут передаваться с основной страницы
        const fieldArr = [
            { id: 1, name: 'numTroop', value: 'Номер взвода', isFiltering: true },
            { id: 2, name: 'collness', value: 'Звание', isFiltering: true },
            { id: 3, name: 'rank', value: 'Должность', isFiltering: true },
            { id: 4, name: 'kurs', value: 'Курс', isFiltering: false },

        ]
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
                                    fieldArr.map(field => {
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
    studentData: getStudentListData(state),
})

export default connect(mapStateToProps)(TBody);