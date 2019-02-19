import React from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import Modal from '../../../ModalDialog'
import Input from '../../../elements/Input'
import Select from '../../../elements/Select'
import FormHead from '../../../elements/FormHead'
import Button from '../../../elements/Button'
import { FlexBox, FlexRow, ModalContainer } from '../../../elements/StyleDialogs/styled'
import { fetchSetRelative } from '../../../../../redux/modules/AddStudent'
import { getStudentRelative } from '../../../../../selectors/addStudent'
import { Container } from './styled'


class CreateRelative extends React.Component {
    state = {
        fieldsValue: {
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
        if (this.validate()) {
            this.props.fetchSetRelative({ index: this.props.relativeIndex, values: this.state.fieldsValue })
            this.props.onHide();
        }

    }

    validate = () => {

        var val = this.state.fieldsValue;

        if (!val.lastName
            || !val.firstName
            || !val.middleName
            || !val.healthStatus
            || !val.relationDegree
            || !val.birthday
            || !val.placeOfRegestration
            || !val.mobilePhone

        ) {
            this.setState(prevSate => (
                {
                    error: {
                        ...prevSate.error,
                        lastName: !prevSate.fieldsValue.lastName,
                        firstName: !prevSate.fieldsValue.firstName,
                        middleName: !prevSate.fieldsValue.middleName,
                        healthStatus: !prevSate.fieldsValue.healthStatus,
                        birthday: !prevSate.fieldsValue.birthday,
                        relationDegree: !prevSate.fieldsValue.relationDegree,
                        mobilePhone: !prevSate.fieldsValue.mobilePhone,
                        placeOfRegestration: !prevSate.fieldsValue.placeOfRegestration,
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
                                <div>
                                    <Input id="lastName"
                                        type="text"
                                        isRequired={true}
                                        placeholder="Фамилия"
                                        value={this.state.fieldsValue['lastName']}
                                        onChange={this.changeSelect}
                                        error={this.state.error.lastName}
                                    />
                                    {
                                        this.state.error.lastName
                                        && (<div className="error-message">Введите фамилию!</div>)
                                    }
                                </div>
                                <div>
                                    <Input id="firstName"
                                        type="text"
                                        isRequired={true}
                                        placeholder="Имя"
                                        value={this.state.fieldsValue['firstName']}
                                        onChange={this.changeSelect}
                                        error={this.state.error.firstName}
                                    />
                                    {
                                        this.state.error.firstName
                                        && (<div className="error-message">Введите имя!</div>)
                                    }
                                </div>
                            </FlexRow>
                            <FlexRow>                           
                                <div>
                                    <Input id="middleName"
                                        type="text"
                                        isRequired={true}
                                        placeholder="Отчество"
                                        value={this.state.fieldsValue['middleName']}
                                        onChange={this.changeSelect}
                                        error={this.state.error.middleName}
                                    />
                                    {
                                        this.state.error.middleName
                                        && (<div className="error-message">Введите имя!</div>)
                                    }
                                </div>
                                <Input id="maidenName"
                                    type="text"
                                    isRequired={false}
                                    placeholder="Девичья фамилия"
                                    value={this.state.fieldsValue['maidenName']}
                                    onChange={this.changeSelect}
                                />
                               
                            </FlexRow>
                            <FlexRow>
                                <div>
                                    <Select id="healthStatus"
                                        data={healthStatus}
                                        value="val"
                                        selectedValue={this.state.fieldsValue['healthStatus']}
                                        text="val"
                                        isRequired={true}
                                        placeholder="Состояние здоровья"
                                        onChange={this.changeSelect}
                                        error={this.state.error.healthStatus}
                                    />
                                    {
                                        this.state.error.healthStatus
                                        && (<div className="error-message">Введите состояние здоровья!</div>)
                                    }
                                </div>
                                <div>
                                    <Select id="relationDegree"
                                        data={relationDegree}
                                        value="val"
                                        selectedValue={this.state.fieldsValue['relationDegree']}
                                        text="val"
                                        isRequired={true}
                                        placeholder="Степень родства"
                                        onChange={this.changeSelect}
                                        error={this.state.error.relationDegree}
                                    />
                                    {
                                        this.state.error.relationDegree
                                        && (<div className="error-message">Введите степень родства!</div>)
                                    }
                                </div>
                            </FlexRow>
                            <FlexRow>
                                <Input id="placeOfResidence"
                                    type="text"
                                    isRequired={false}
                                    placeholder="Адрес проживания"
                                    value={this.state.fieldsValue['placeOfResidence']}
                                    onChange={this.changeSelect}
                                />
                                <div>
                                    <Input id="placeOfRegestration"
                                        type="text"
                                        isRequired={true}
                                        placeholder="Адрес регистрации"
                                        value={this.state.fieldsValue['placeOfRegestration']}
                                        onChange={this.changeSelect}
                                        error={this.state.error.placeOfRegestration}
                                    />
                                    {
                                        this.state.error.placeOfRegestration
                                        && (<div className="error-message">Введите адрес регистрации!</div>)
                                    }
                                </div>
                            </FlexRow>
                            <FlexRow>
                                <div>
                                    <Input id="birthday"
                                        type="text"
                                        date={true}
                                        isRequired={true}
                                        placeholder="Дата рождения"
                                        value={this.state.fieldsValue['birthday']}
                                        onChange={this.changeSelect}
                                        error={this.state.error.birthday}
                                    />
                                    {
                                        this.state.error.birthday
                                        && (<div className="error-message">Введите дату рождения!</div>)
                                    }
                                </div>
                                <div>
                                    <Input id="mobilePhone"
                                        type="tel"
                                        isRequired={true}
                                        placeholder="Мобильный телефон"
                                        value={this.state.fieldsValue['mobilePhone']}
                                        onChange={this.changeSelect}
                                        error={this.state.error.mobilePhone}
                                    />
                                    {
                                        this.state.error.mobilePhone
                                        && (<div className="error-message">Введите мобильный телефон!</div>)
                                    }
                                </div>
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

function mapStateToProps(store, ownProps) {
    return {
        relative: getStudentRelative(store, ownProps.relativeIndex)
    }
}

CreateRelative.props = {
    show: PropTypes.bool,
    onHide: PropTypes.func,
    relativeIndex: PropTypes.string,
    relative: PropTypes.object,
    fetchSetRelative: PropTypes.func,
}


export default connect(mapStateToProps, { fetchSetRelative })(CreateRelative)