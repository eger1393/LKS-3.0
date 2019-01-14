import React from 'react'
import PropTypes from 'prop-types'
import Input from '../../../elements/Input'
import Select from '../../../elements/Select'
import Autocomplete from '../../../elements/Autocomplete'
import { connect } from 'react-redux'
import { FlexBox, FlexRow } from '../../../elements/StyleDialogs/styled'
import { fetchSetValueForStudent } from '../../../../../redux/modules/AddStudent'
import { apiGetLanguagesList } from '../../../../../api/addStudent'
import { getAddStudentFieldsValue, getAddStudentErrorValues } from '../../../../../selectors/addStudent'
import { Container } from './styled'
import CheckBox from '../../../elements/Checkbox';

class Personal extends React.Component {
    state = {
        languages: [],
    }
    changeSelect = event => {
        console.log(event)

        var name = event.target.name ? event.target.name : event.target.id,
            val = event.target.value;

        //добавить валидацию значений
        var error = false;
        this.props.fetchSetValueForStudent({ name, val, error });
    }
    componentWillMount() {
        if (this.isUnmounted) {
            return;
        }
        var self = this;
        apiGetLanguagesList().then(res =>
            self.setState({ languages: res })
        );
    }
    componentWillUnmount() {
        this.isUnmounted = true;
    }
    render() {
        var languageRanks = [{ id: '1', val: 'Читает и переводит со словарем' }, { id: '2', val: 'Свободно читает и общается' }, { id: '3', val: 'Профессионально переводит и говорит' }]
        return (
            <Container>
                <FlexBox className="flex-box">
                    <FlexRow>
                        <div>
                            <Input id="birthday"
                                type="date"
                                isRequired={true}
                                placeholder="Дата рождения"
                                value={this.props.fieldValue['birthday']}
                                onChange={this.changeSelect}
                                error={this.props.errorValues.birthday}
                            />
                            {
                                this.props.errorValues.birthday
                                && (<div className="error-message">Введите дату рождения!</div>)
                            }
                        </div>
                        <div>
                            <Input id="placeBirthday"
                                type="text"
                                isRequired={true}
                                placeholder="Место рождения"
                                value={this.props.fieldValue['placeBirthday']}
                                onChange={this.changeSelect}
                                error={this.props.errorValues.placeBirthday}
                            />
                            {
                                this.props.errorValues.placeBirthday
                                && (<div className="error-message">Введите место рождения!</div>)
                            }
                        </div>
                       
                    </FlexRow>
                    <FlexRow>
                        <Input id="nationality"
                            type="text"
                            isRequired={false}
                            placeholder="Национальность"
                            value={this.props.fieldValue['nationality']}
                            onChange={this.changeSelect}
                        />
                        <Input id="citizenship"
                            type="text"
                            isRequired={false}
                            placeholder="Гражданство"
                            value={this.props.fieldValue['citizenship']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="homePhone"
                            type="tel"
                            isRequired={false}
                            placeholder="Дом. телефон"
                            value={this.props.fieldValue['homePhone']}
                            onChange={this.changeSelect}
                        />
                        <div>
                            <Input id="mobilePhone"
                                type="tel"
                                pattern="(\+?\d[- .]*){7,13}"
                                isRequired={true}
                                placeholder="Мобильный телефон"
                                value={this.props.fieldValue['mobilePhone']}
                                onChange={this.changeSelect}
                                error={this.props.errorValues.mobilePhone}
                            />
                            {
                                this.props.errorValues.mobilePhone
                                && (<div className="error-message">Введите телефон!</div>)
                            }
                        </div>
                    </FlexRow>
                    <FlexRow>
                        <Input id="two_MobilePhone"
                            type="tel"
                            isRequired={false}
                            placeholder="Дополнительный моб. телефон"
                            value={this.props.fieldValue['two_MobilePhone']}
                            onChange={this.changeSelect}
                        />
                        <Input id="school"
                            type="text"
                            isRequired={false}
                            placeholder="Школа"
                            value={this.props.fieldValue['school']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="placeOfResidence"
                            type="text"
                            isRequired={false}
                            placeholder="Адрес проживания"
                            value={this.props.fieldValue['placeOfResidence']}
                            onChange={this.changeSelect}
                        />

                        <div>
                            <Input id="placeOfRegestration"
                                type="text"
                                isRequired={true}
                                placeholder="Адрес регистрации"
                                value={this.props.fieldValue['placeOfRegestration']}
                                onChange={this.changeSelect}
                                error={this.props.errorValues.placeOfRegestration}
                            />
                            {
                                this.props.errorValues.placeOfRegestration
                                && (<div className="error-message">Введите адрес регистрации!</div>)
                            }
                        </div>
                    </FlexRow>
                    
                    <span className="badge badge-light">Биометрия</span>
                    <FlexRow>
                        <Input id="bloodType"
                                type="text"
                            isRequired={false}
                                placeholder="Группа крови"
                                value={this.props.fieldValue['bloodType']}
                                onChange={this.changeSelect}
                            />
                        <Input id="growth"
                                type="number"
                            isRequired={false}
                                placeholder="Рост"
                                value={this.props.fieldValue['growth']}
                                onChange={this.changeSelect}
                            />
                    </FlexRow>
                    <FlexRow>
                        <Input id="clothihgSize"
                            type="number"
                            isRequired={false}
                            placeholder="Размер одежды"
                            value={this.props.fieldValue['clothihgSize']}
                            onChange={this.changeSelect}
                        />
                        <Input id="shoeSize"
                            type="number"
                            isRequired={false}
                            placeholder="Размер обуви"
                            value={this.props.fieldValue['shoeSize']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="capSize"
                            type="number"
                            isRequired={false}
                            placeholder="Размер головного убора"
                            value={this.props.fieldValue['capSize']}
                            onChange={this.changeSelect}
                        />
                        <Input id="maskSize"
                            type="number"
                            isRequired={false}
                            placeholder="Размер противогаза"
                            value={this.props.fieldValue['maskSize']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>


                    <span className="badge badge-light">Личные навыки</span>
                    <FlexRow>
                        <CheckBox id="skill1"
                            title="Языки программирования (С,С++,С#)"
                            inline={true}
                            onChange={this.changeSelect}
                            value={this.props.fieldValue.skill1}
                        />
                        <CheckBox id="skill2"
                            title="Microsoft Office"
                            inline={true}
                            onChange={this.changeSelect}
                            value={this.props.fieldValue.skill2}
                        />
                        <CheckBox id="skill3"
                            title="Adobe Photoshop"
                            inline={true}
                            onChange={this.changeSelect}
                            value={this.props.fieldValue.skill3}
                        />
                    </FlexRow>
                    <FlexRow>
                        <CheckBox id="skill4"
                            title="Электроника, электротехника"
                            inline={true}
                            onChange={this.changeSelect}
                            value={this.props.fieldValue.skill4}
                        />
                        <CheckBox id="skill5"
                            title="Настройка локальных сетей"
                            inline={true}
                            onChange={this.changeSelect}
                            value={this.props.fieldValue.skill5}
                        />
                        <CheckBox id="skill6"
                            title="Другое"
                            inline={true}
                            onChange={this.changeSelect}
                            value={this.props.fieldValue.skill6}
                        />
                    </FlexRow>

                    <span className="badge badge-light">Иностраные языки</span>
                    <FlexRow>
                        {
                            this.state.languages.length != 0 && (<Autocomplete id="foreignLanguage"
                                data={this.state.languages} onChange={this.changeSelect} placeholder="Иностранный язык" value={this.props.fieldValue.foreignLanguage}
                            />)}
                            <Select id="languageRank"
                            data={languageRanks}
                            value="id"
                            selectedValue={this.props.fieldValue.languageRank}
                            text="val"
                            isRequired={false}
                            placeholder="Степень владения"
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                </FlexBox>
            </Container>

        );
    }
}

Personal.props = {
    fieldValue: PropTypes.object,
    errorValues: PropTypes.object,
}

function mapStateToProps(store) {
    return {
        fieldValue: getAddStudentFieldsValue(store),
        errorValues: getAddStudentErrorValues(store),
    }
}

export default connect(mapStateToProps, { fetchSetValueForStudent })(Personal)