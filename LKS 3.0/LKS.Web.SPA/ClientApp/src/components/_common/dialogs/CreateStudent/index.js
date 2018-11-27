import React from 'react'
import PropTypes from 'prop-types'
import { Modal, Tab, Tabs, Grid } from 'react-bootstrap'
import Input from '../../elements/Input'
import Select from '../../elements/Select'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import { FlexBox, FlexRow, ModalContainer } from '../../elements/StyleDialogs/styled'
import Info from './Info'
import { apiCreateStudent } from '../../../../api/addStudent'
import { Container } from './styled'

class CreateStudent extends React.Component {
    constructor(props) {
        super(props);
        this.createStudent = this.createStudent.bind(this)
    }
    createStudent = (values) => {
        
            apiCreateStudent(values);
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
                                <Info createStudent={this.createStudent} />
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

CreateStudent.state = {
    fieldValue: PropTypes.array,
}

export default CreateStudent