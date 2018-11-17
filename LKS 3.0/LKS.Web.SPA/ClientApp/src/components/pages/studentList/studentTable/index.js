import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { fetchGetStudentListData } from '../../../../redux/modules/studentList'

import THead from './THead'
import TBody from './TBody'
import { Container } from './styled'

class StudentTable extends React.Component {

    componentWillMount = () => {
        this.props.fetchGetStudentListData({});
    }

    render() {
        return (
            <Container>
                <table>
                    <THead />
                    <TBody />
                </table>
            </Container>
        );
    }
}

StudentTable.props = {
    fetchGetStudentListData: PropTypes.func,
}

export default connect(null, { fetchGetStudentListData})(StudentTable);