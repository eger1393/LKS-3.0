﻿import React from 'react'
import PropTypes from 'prop-types'
import {Tab, Tabs } from 'react-bootstrap'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import { ModalContainer } from '../../elements/StyleDialogs/styled'
import Info from './Info'
import { Container } from './styled'
import { fetchAddNewStudent, fetchUpdateStudent, fetchSetErrors, fetchClearStudent } from '../../../../redux/modules/AddStudent'
import { getIsLoading, getStudentId, getAddStudentFieldsValue, getIsError, getIsErrorInfo, getIsErrorPersonal } from '../../../../selectors/addStudent'
import { connect } from 'react-redux'
import Personal from './Personal';
import RelativesList from './RelativesList'
import Photo from './Photo'

import ModalDialog from '../../ModalDialog'

class CreateStudent extends React.Component {
    constructor(props) {
        super(props);
        this.createStudent = this.createStudent.bind(this)
    }
    createStudent = () => {
        if (this.validate()) {
            if (this.props.StudentId != undefined) {
                this.props.fetchUpdateStudent();
            }
            else {
                this.props.fetchAddNewStudent();
            }

            if (!this.props.errorStudent) {
                alert("Успешно!");
                this.props.onHide();
            }
            else {
                alert("Ошибка!");
            }

        }

    }
    closeModal = () => {
        this.props.fetchClearStudent();
        this.props.onHide();
    }
    validate = () => {
        var val = this.props.fieldsValue;
        if (!val.lastName
            || !val.firstName
            || !val.middleName
            || !val.troopId
            || !val.kurs
            || !val.faculty
            || !val.position
            || !val.birthday
            || !val.placeBirthday
            || !val.mobilePhone
            || !val.placeOfRegestration
        ) {
            this.props.fetchSetErrors();
            return false;
        }
        return true;
    }

    render() {
        return (
            !this.props.loading &&
            (<ModalDialog
                show={this.props.show}
            //убрал функцию OnHide чтоб окно не закрывалось случайно, закрыть можно по нажатию на X

            >
                <ModalContainer ref="ModalContainer">
                    <Container>
                        <FormHead text="Добавить студента" handleClick={this.closeModal} />
                        <Tabs defaultActiveKey={1} id="uncontrolled-tab-example" className="customTubs" >
                            <Tab eventKey={1} title="Информация" className={(this.props.errorPersonal ? 'Error' : '')}>
                                <Info />
                            </Tab>
                            <Tab eventKey={2} title="Личные данные" className={(this.props.errorPersonal ? 'Error' : '')}>
                                <Personal />
                            </Tab>
                            <Tab eventKey={3} title="Родственники">
                                <RelativesList />
                            </Tab>
                            <Tab eventKey={4} title="Фотография">
                                <Photo />
                            </Tab>
                            <div className="form-submit">
                            </div>
                        </Tabs>
                    </Container>
                    <Button onClick={this.createStudent} value="Сохранить" />
                </ModalContainer>
            </ModalDialog>)
        );
    }
}

CreateStudent.props = {
    show: PropTypes.bool,
    onHide: PropTypes.func,
    StudentId: PropTypes.string,
    fetchUpdateStudent: PropTypes.func,
    fetchAddNewStudent: PropTypes.func,
    loading: PropTypes.bool,
    errorStudent: PropTypes.bool,
    errorInfo: PropTypes.bool,
    errorPersonal: PropTypes.bool,
}

function mapStateToProps(store) {
    return {
        loading: getIsLoading(store),
        errorStudent: getIsError(store),
        StudentId: getStudentId(store),
        fieldsValue: getAddStudentFieldsValue(store),
        errorInfo: getIsErrorInfo(store),
        errorPersonal: getIsErrorPersonal(store),
    }
}
export default connect(mapStateToProps, { fetchAddNewStudent, fetchUpdateStudent, fetchSetErrors, fetchClearStudent })(CreateStudent)