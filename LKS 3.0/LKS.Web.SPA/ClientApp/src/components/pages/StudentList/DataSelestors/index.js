import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { Panel } from 'react-bootstrap'

import Picky from 'react-picky'
import 'react-picky/dist/picky.css'

import { Container } from './styled'
import { fetchSetStudentListFields } from '../../../../redux/modules/studentList'
import { getStudentListFields } from '../../../../selectors/studentList'


// TODO Вынести в константы 
const fieldArr = [
    { id: 1, name: 'numTroop', value: 'Номер взвода', isFiltering: true },
    { id: 2, name: 'collness', value: 'Звание', isFiltering: true },
    { id: 3, name: 'rank', value: 'Должность', isFiltering: true },
    { id: 4, name: 'kurs', value: 'Курс', isFiltering: false },

]

class DataSelectors extends React.Component {
    //state = {
    //    selectedFields: [],
    //}

    changeSelectedFields = val => {
        this.props.fetchSetStudentListFields(val.sort((a, b) => a.id - b.id));
        //this.setState({ selectedFields: [...val.sort((a, b) => a.id - b.id)] });
    }

    render() {
        return (
            <Container>
                <Panel id="DetaSelectorsPanel" defaultExpanded>
                    <Picky
                        options={fieldArr}
                        value={this.props.selectedFields}
                        onChange={this.changeSelectedFields}
                        multiple={true}
                        valueKey="name"
                        labelKey="value"
                        numberDisplayed="2"
                        placeholder=""
                    />
                </Panel>
            </Container>
        );
    }
}

DataSelectors.props = {
    selectedFields: PropTypes.array,
    fetchSetStudentListFields: PropTypes.func,
}

const mapStateToProps = state => ({
    selectedFields: getStudentListFields(state),
})

export default connect(mapStateToProps, { fetchSetStudentListFields })(DataSelectors);