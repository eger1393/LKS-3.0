﻿import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { Panel } from 'react-bootstrap'

import Picky from 'react-picky'
import 'react-picky/dist/picky.css'

import { Container, Contant, Legend } from './styled'
import {
    fetchSetStudentListFields,
    fetchSetStudentListFiltersValue,
    fetchGetStudentListData,
} from '../../../../redux/modules/studentList'
import { fieldArr } from '../../../../constants/studentTable'

import { getStudentListFields, getStudentListFiltersValue } from '../../../../selectors/studentList'


class DataSelectors extends React.Component {

    changeSelectedFields = val => {
        var self = this;
        self.props.selectedFields.map(ob => {
            // Затираем значение фильтрации в поле, с которого сняли выбор
            if (!val.includes(ob)) {
                self.props.fetchSetStudentListFiltersValue({ fieldName: ob.name, value: '' });
            }
        });
        this.props.fetchSetStudentListFields(val.sort((a, b) => a.id - b.id));
    }

    changeSelectedStudentFilter = async event => { // выпадашка со статусами студентов
        var name = 'studentType',
            val = event.target.value;
        await this.props.fetchSetStudentListFiltersValue({ fieldName: name, value: val }); // добавили фильтр
        await this.props.fetchGetStudentListData(); // дернули студентов
    }

    render() {
        return (
            <Container>
                <Panel id="DetaSelectorsPanel">
                    <Panel.Heading >
                        <Panel.Title toggle>
                            Панель настроек таблицы
                        </Panel.Title>
                    </Panel.Heading>
                    <Panel.Collapse>
                        <Panel.Body>
                            <Contant>
                                <select onChange={this.changeSelectedStudentFilter}>
                                    <option value="all" selected>Все студенты</option>
                                    <option value="train">Обучаются</option>
                                    <option value="forDeductions">На отчисление</option>
                                    <option value="suspended">Отстранены</option>
                                    <option value="trainingFees">На сборах</option>
                                    <option value="completedFees">Прошел сборы</option>
                                </select>

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
                                <Legend style={{}}>
                                    Легенда:
                                    <div style={{ color: 'black'}}>Обучается;</div>
                                    <div style={{ color: 'orange' }}>На отчисление;</div>
                                    <div style={{ color: '#e84a4a' }}>Отстранены;</div>
                                    <div style={{ color: '#81e84e' }}>На сборах;</div>
                                    <div style={{ color: '#4de8d0' }}>Прошел сборы;</div>
                                </Legend>
                            </Contant>
                        </Panel.Body>
                    </Panel.Collapse>

                </Panel>
            </Container>
        );
    }
}

DataSelectors.props = {
    selectedFields: PropTypes.array,
    filters: PropTypes.array,
    fetchSetStudentListFields: PropTypes.func,
    fetchSetStudentsListFilters: PropTypes.func,
    fetchGetStudentListData: PropTypes.func,
}

const mapStateToProps = state => ({
    selectedFields: getStudentListFields(state),
    filters: getStudentListFiltersValue(state),
})

export default connect(mapStateToProps, {
    fetchSetStudentListFields,
    fetchSetStudentListFiltersValue,
    fetchGetStudentListData,
})(DataSelectors);