import React from 'react'
import PropTypes from 'prop-types'
import { Modal, Tab, Tabs } from 'react-bootstrap'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import {  ModalContainer } from '../../elements/StyleDialogs/styled'
import Info from './Info'
import { Container } from './styled'
import { fetchAddNewStudent } from '../../../../redux/modules/AddStudent'
import { connect } from 'react-redux'


class CreateStudent extends React.Component {
    constructor(props) {
        super(props);
        this.createStudent = this.createStudent.bind(this)
    }
    createStudent = () => {
            this.props.fetchAddNewStudent();
            this.props.onHide();   
    }
    validate = () => {
        // TODO add validate fields
        return true;
    }
    render() {
        return (
            <Modal
                show={this.props.show}
                onHide={this.props.onHide}
            >
                <ModalContainer>
                   <Container>
                        <FormHead text="Добавить студента" handleClick={this.props.onHide} />
                        <Tabs defaultActiveKey={1} id="uncontrolled-tab-example" className="customTubs" >
                            <Tab eventKey={1} title="Информация">
                                <Info/>
                            </Tab>
                            <Tab eventKey={2} title="Личные данные" disabled>
                                Tab 2 content
                            </Tab>
                            <Tab eventKey={3} title="Родственники" disabled>
                                Tab 3 content
                            </Tab>
                            <Tab eventKey={4} title="Фотография" disabled>
                                Tab 4 content
                            </Tab>
                            <div className="form-submit">
                            </div>
                        </Tabs>
                    </Container>
                    <Button onClick={this.createStudent} value="Создать" />
                </ModalContainer>
            </Modal>
        );
    }
}

CreateStudent.props = {
    show: PropTypes.bool,
    onHide: PropTypes.func,
    createStudent: PropTypes.func,
}

export default connect(null, { fetchAddNewStudent })(CreateStudent)