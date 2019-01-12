import React from 'react'
import PropTypes from 'prop-types'
import { Modal, Tab, Tabs } from 'react-bootstrap'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import {  ModalContainer } from '../../elements/StyleDialogs/styled'
import Info from './Info'
import { Container } from './styled'
import { fetchAddNewStudent, fetchUpdateStudent } from '../../../../redux/modules/AddStudent'
import { getIsLoading } from '../../../../selectors/addStudent'
import { connect } from 'react-redux'
import Personal from './Personal';
import RelativesList from './RelativesList'

class CreateStudent extends React.Component {
    constructor(props) {
        super(props);
        this.createStudent = this.createStudent.bind(this)
    }
    createStudent = () => {
        if (this.validate()) {
            if (this.props.StudentId != "") {
                this.props.fetchUpdateStudent();
            }
            else {
                this.props.fetchAddNewStudent();
            }
        }
        this.props.onHide();
    }
    validate = () => {
        // TODO add validate fields
        return true;
    }
    render() {
        return (
            !this.props.loading &&
            (<Modal
                show={this.props.show}
                onHide={this.props.onHide}
            >
                <ModalContainer>
                    <Container>
                        <FormHead text="Добавить студента" handleClick={this.props.onHide} />
                        <Tabs defaultActiveKey={1} id="uncontrolled-tab-example" className="customTubs" >
                            <Tab eventKey={1} title="Информация">
                                <Info />
                            </Tab>
                            <Tab eventKey={2} title="Личные данные">
                                <Personal />
                            </Tab>
                            <Tab eventKey={3} title="Родственники">
                                <RelativesList />
                            </Tab>
                            <Tab eventKey={4} title="Фотография" disabled>
                                Tab 4 content
                            </Tab>
                            <div className="form-submit">
                            </div>
                        </Tabs>
                    </Container>
                    <Button onClick={this.createStudent} value="Сохранить" />
                </ModalContainer>
            </Modal>)
        );
    }
}

CreateStudent.props = {
    show: PropTypes.bool,
    onHide: PropTypes.func,
    fetchUpdateStudent: PropTypes.func,
    fetchAddNewStudent: PropTypes.func,
    loading: PropTypes.bool,
}

function mapStateToProps(store) {
    return {
        loading: getIsLoading(store),
    }
}
export default connect(mapStateToProps, { fetchAddNewStudent, fetchUpdateStudent })(CreateStudent)