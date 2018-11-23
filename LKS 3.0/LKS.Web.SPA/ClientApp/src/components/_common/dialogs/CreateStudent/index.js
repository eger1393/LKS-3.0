import React from 'react'
import PropTypes from 'prop-types'
import { Modal } from 'react-bootstrap'
import Input from '../../elements/Input'
import Select from '../../elements/Select'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import { FlexBox, FlexRow, ModalContainer } from '../../elements/StyleDialogs/styled'
import PersonalData from './PersonalData'

class CreateStudent extends React.Component {
    state = {
        fieldValue: [],
    }
    createStudent = () => {
        alert('done!');
        this.props.onHide();
    }

    render() {
        return (
            <Modal show={this.props.show} onHide={this.props.onHide}>
                <ModalContainer>
                    <FormHead text="Добавить студента" handleClick={this.props.onHide} />
                    <PersonalData />
                    <div className="form-submit">
                        <Button onClick={this.createStudent} value="Создать" />
                    </div>
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