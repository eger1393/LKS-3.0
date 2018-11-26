import React from 'react'
import PropTypes from 'prop-types'
import { Modal } from 'react-bootstrap'
import Input from '../../elements/Input'
import Select from '../../elements/Select'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import { FlexBox, FlexRow, ModalContainer } from '../../elements/StyleDialogs/styled'
import { apiGetCycleList, apiGetPrepodList, apiCreateTroop } from '../../../../api/dialogs'

import { Container } from './styled'

class CreateTroop extends React.Component {
    state = {
        fieldValue: [], // значение полей формы
        cycle: [], // список циклов(тянем из бд)
        prepod: [], // список преподов (тянем из бд)
    }

    changeSelect = event => {
        var name = event.target.name ? event.target.name : event.target.id,
            val = event.target.value;
        this.setState(prevState => ({
            fieldValue: { ...prevState.fieldValue, [name]: val, }
        }));
    }

    createTroop = () => {
        if (this.validate()) {
            apiCreateTroop(this.state.fieldValue);
            this.props.onHide();
        }

    }

    validate = () => {
        // TODO add validate fields
        return true;
    }

    componentDidMount() {
        var self = this;
        apiGetCycleList().then(res => self.setState({ cycle: res }));
        apiGetPrepodList().then(res => self.setState({ prepod: res }));
    }

    render() {
        // TODO Вынести в константы
        var day = [
            { id: 'Monday', val: 'Понедельник' },
            { id: 'Tuesday', val: 'Вторник' },
            { id: 'Wednesday', val: 'Среда' },
            { id: 'Thursday', val: 'Четверг' },
            { id: 'Friday', val: 'Пятница' },
            { id: 'Saturday', val: 'Суббота' },
        ]
        return (
            <Modal show={this.props.show} onHide={this.props.onHide}>
                <ModalContainer>
                    <Container>
                        <FormHead text="Создать взвод" handleClick={this.props.onHide} />
                        <FlexBox>
                            <FlexRow className="flex-row">
                                <Select id="cycleId" data={this.state.cycle} placeholder="Цикл" onChange={this.changeSelect} value="id" text="number" />
                                <Input id="numberTroop"
                                    type="text"
                                    isRequired={true}
                                    placeholder="Номер взвода"
                                    value={this.state.fieldValue['numberTroop']}
                                    onChange={this.changeSelect}
                                />
                            </FlexRow>
                            <FlexRow className="flex-row">
                                <Select id="arrivalDay" data={day} value="id" text="val" placeholder="День прихода" onChange={this.changeSelect} />
                                <Select id="prepodId" data={this.state.prepod} value="id" text="initials" placeholder="Ответственный преподаватель" onChange={this.changeSelect} />
                            </FlexRow>
                        </FlexBox>
                        <div className="form-submit">
                            <Button onClick={this.createTroop} value="Создать" />
                        </div>
                    </Container>
                </ModalContainer>
            </Modal>
        );
    }
}

CreateTroop.props = {
    show: PropTypes.bool,
    onHide: PropTypes.func,
}

CreateTroop.state = {
    fieldValue: PropTypes.array,
}

export default CreateTroop