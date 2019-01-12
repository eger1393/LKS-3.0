import React from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import { Modal } from 'react-bootstrap'
import Input from '../../../elements/Input'
import Select from '../../../elements/Select'
import FormHead from '../../../elements/FormHead'
import Button from '../../../elements/Button'
import { FlexBox, FlexRow, ModalContainer } from '../../../elements/StyleDialogs/styled'
import { fetchSetRelative } from '../../../../../redux/modules/AddStudent'

import { Container } from './styled'

function getRandomArbitrary(min, max) {
    return Math.random() * (max - min) + min;
}

class CreateRelative extends React.Component {
    state = {
        fieldsValue: {
            id: getRandomArbitrary(1,100000),
            ...this.props.relative
        },
        error: {},
    }

    changeSelect = event => {
        console.log(event)
        var name = event.target.name ? event.target.name : event.target.id,
            val = event.target.value;

        this.setState(prevState => ({
            fieldsValue: { ...prevState.fieldsValue, [name]: val, },
            error: { ...prevState.error, [name]: false },
        }));
    }
    createRelative = () => {
        if (true) {
            this.props.fetchSetRelative({ id: this.state.fieldsValue["id"], value: this.state.fieldsValue })
            this.props.setRelative({ id: this.state.fieldsValue["id"], value: this.state.fieldsValue })
                this.props.onHide();
        }

    }

    validate = () => {

        var val = this.state.fieldValue,
            troopIsExist = false;
        (this.props.troops &&
            this.props.troops.map(ob => {
            if (ob.numberTroop === val.numberTroop)
                troopIsExist = true;
            }))

        if (!val.numberTroop
            || !val.cycleId
            || !val.arrivalDay
            || !val.prepodId
            || troopIsExist
        ) {
            this.setState(prevSate => (
                {
                    error: {
                        ...prevSate.error,
                        numberTroop: !prevSate.fieldValue.numberTroop,
                        cycleId: !prevSate.fieldValue.cycleId,
                        arrivalDay: !prevSate.fieldValue.arrivalDay,
                        prepodId: !prevSate.fieldValue.prepodId,
                        troopIsExist: troopIsExist,
                    }
                }
            ))
            return false;
        }
        return true;
    }

    render() {
        // TODO Вынести в константы
        var relationDegree = [
            { id: '1', val: 'Отец' },
            { id: '2', val: 'Мать' },
            { id: '3', val: 'Брат' },
            { id: '4', val: 'Сестра' },
            { id: '5', val: 'Отчим' },
            { id: '6', val: 'Мачеха' },
        ]
        var healthStatus = [
            { id: '1', val: 'Здоров' },
            { id: '2', val: 'Инвалид 1 степени' },
            { id: '3', val: 'Инвалид 2 степени' },
            { id: '4', val: 'Инвалид 3 степени' },
            { id: '5', val: 'Умер' },
        ]
        return (
            <Modal show={this.props.show} onHide={this.props.onHide}>
                <ModalContainer>
                    <Container>
                        <FormHead text="Добавить родственника" handleClick={this.props.onHide} />
                        <FlexBox>
                            <FlexRow>
                                <Input id="LastName"
                                    type="text"
                                    isRequired={true}
                                    placeholder="Фамилия"
                                    value={this.state.fieldsValue['LastName']}
                                    onChange={this.changeSelect}
                                />
                                <Input id="FirstName"
                                    type="text"
                                    isRequired={true}
                                    placeholder="Имя"
                                    value={this.state.fieldsValue['FirstName']}
                                    onChange={this.changeSelect}
                                />
                            </FlexRow>
                            <FlexRow>
                                <Input id="MiddleName"
                                    type="text"
                                    isRequired={true}
                                    placeholder="Отчество"
                                    value={this.state.fieldsValue['MiddleName']}
                                    onChange={this.changeSelect}
                                />
                                <Input id="MaidenName"
                                    type="text"
                                    isRequired={true}
                                    placeholder="Девичья фамилия"
                                    value={this.state.fieldsValue['MaidenName']}
                                    onChange={this.changeSelect}
                                />
                               
                            </FlexRow>
                            <FlexRow>
                                <Select id="HealthStatus"
                                    data={healthStatus}
                                    value="val"
                                    selectedValue={this.state.fieldsValue['HealthStatus']}
                                    text="val"
                                    isRequired={true}
                                    placeholder="Состояние здоровья"
                                    onChange={this.changeSelect}
                                />
                                <Select id="relationDegreeId"
                                    data={relationDegree}
                                    value="val"
                                    selectedValue={this.state.fieldsValue['RelationDegree']}
                                    text="val"
                                    isRequired={true}
                                    placeholder="Степень родства"
                                    onChange={this.changeSelect}
                                />
                            </FlexRow>
                            <FlexRow>
                                <Input id="Birthday"
                                    type="text"
                                    isRequired={true}
                                    placeholder="Дата рождения"
                                    value={this.state.fieldsValue['Birthday']}
                                    onChange={this.changeSelect}
                                />
                                <Input id="MobilePhone"
                                    type="text"
                                    isRequired={true}
                                    placeholder="Мобильный телефон"
                                    value={this.state.fieldsValue['MobilePhone']}
                                    onChange={this.changeSelect}
                                />
                            </FlexRow>
                        </FlexBox>
                        <div className="form-submit">
                            <Button onClick={this.createRelative} value="Сохранить" />
                        </div>
                    </Container>
                </ModalContainer>
            </Modal>
        );
    }
}

CreateRelative.props = {
    show: PropTypes.bool,
    onHide: PropTypes.func,
    relative: PropTypes.object,
    fetchSetRelative: PropTypes.func,
}


export default connect(null, { fetchSetRelative })(CreateRelative)