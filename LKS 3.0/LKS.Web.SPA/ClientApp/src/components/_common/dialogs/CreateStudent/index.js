import React from 'react'
import PropTypes from 'prop-types'
import { Modal, Tab, Tabs, Grid } from 'react-bootstrap'
import Input from '../../elements/Input'
import Select from '../../elements/Select'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import { FlexBox, FlexRow, ModalContainer } from '../../elements/StyleDialogs/styled'
import Info from './Info'
import { apiCreateStudent } from '../../../../api/dialogs'
import './StyleSheet.css'

class CreateStudent extends React.Component {
    state = {
        fieldValue: [],
    }
    createStudent = () => {
        if (this.validate()) {
            apiCreateStudent(this.state.fieldValue);
            this.props.onHide();
        }
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
                dialogClassName="custom-modal"
                >
                <ModalContainer>
                        <FormHead text="Добавить студента" handleClick={this.props.onHide} />
                        <Tabs defaultActiveKey={1} id="uncontrolled-tab-example">
                            <Tab eventKey={1} title="Tab 1">
                                <Info data={this.state.fieldValue} />
                            </Tab>
                            <Tab eventKey={2} title="Tab 2" disabled>
                                Tab 2 content
                            </Tab>
                            <Tab eventKey={3} title="Tab 3" disabled>
                                Tab 3 content
                            </Tab>
                            <div className="form-submit">
                                <Button onClick={this.createStudent} value="Создать" />
                            </div>
                        </Tabs>
                </ModalContainer>
            </Modal>
        );
    }
}

CreateStudent.props = {
    show: PropTypes.bool,
    onHide: PropTypes.func,
}

CreateStudent.state = {
    fieldValue: PropTypes.array,
}

export default CreateStudent