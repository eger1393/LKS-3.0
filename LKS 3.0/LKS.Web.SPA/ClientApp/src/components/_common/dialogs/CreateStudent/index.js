import React from 'react'
import PropTypes from 'prop-types'
import { Tab, Tabs, Row, Nav } from 'react-bootstrap'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import { ModalContainer } from '../../elements/StyleDialogs/styled'
import Info from './Info'
import { Container } from './styled'
import { fetchUpdateStudent, fetchSetErrors, fetchClearStudent } from '../../../../redux/modules/addStudent'
import { getIsLoading, getStudentId, getAddStudentFieldsValue, getIsError, getIsErrorInfo, getIsErrorPersonal } from '../../../../selectors/addStudent'
import { connect } from 'react-redux'
import Personal from './Personal';
import RelativesList from './RelativesList'
import Photo from './Photo'
import ModalClose from './CloseOrNot'

import ModalDialog from '../../ModalDialog'

class CreateStudent extends React.Component {
    state = {
        closeOrNotWindow: false,
    };
    constructor(props) {
        super(props);
        this.createStudent = this.createStudent.bind(this)
    }
    createStudent = () => {
        if (this.validate()) {
            this.props.fetchUpdateStudent();
            this.props.onHide();
        }

    }
    closeOrNotModal = () => {
        this.setState({
            closeOrNotWindow: true,
        })
    }

    closeModal = () => {
        this.setState({
            closeOrNotWindow: false,
        })
        this.props.fetchClearStudent();
        this.props.onHide();
    }

    cancelClose = () => {
        this.setState({
            closeOrNotWindow: false,
        })
    }
    validate = () => {
        var val = this.props.fieldsValue;
        if (!val.lastName
            || !val.firstName
            || !val.middleName
            || !val.troopId
            || !val.kurs
            || !val.position
            || !val.faculty
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
                onHide={this.closeOrNotModal}
            >
                <ModalContainer ref="ModalContainer">
                    <Container>
                        <FormHead text="Добавить студента" handleClick={this.closeModal} />
                        <Tabs defaultActiveKey={1} id="uncontrolled-tab-example" className="customTubs" >
                            <Tab eventKey={1} title={<div className={(this.props.errorInfo ? 'Error' : '')} >Информация</div>}>
                                <Info />
                            </Tab>
                            <Tab eventKey={2} title={<div className={(this.props.errorPersonal ? 'Error' : '')} >Личные данные</div>}>
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
                    {this.state.closeOrNotWindow && (<ModalClose isOpen={this.state.closeOrNotWindow} isOk={this.closeModal} isCancel={this.cancelClose} />)}
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
    loading: PropTypes.bool,
    errorInfo: PropTypes.bool,
    errorPersonal: PropTypes.bool,
}

function mapStateToProps(store) {
    return {
        loading: getIsLoading(store),
        StudentId: getStudentId(store),
        fieldsValue: getAddStudentFieldsValue(store),
        errorInfo: getIsErrorInfo(store),
        errorPersonal: getIsErrorPersonal(store),
    }
}
export default connect(mapStateToProps, { fetchUpdateStudent, fetchSetErrors, fetchClearStudent })(CreateStudent)