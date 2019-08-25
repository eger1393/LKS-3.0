import React from 'react'
import PropTypes from 'prop-types'
import Input from '../../../elements/Input'
import Select from '../../../elements/Select'
import CreatableSelect from 'react-select/creatable'
import { connect } from 'react-redux'
import { FlexBox, FlexRow } from '../../../elements/StyleDialogs/styled'
import { apiGetInstGroupList, apiGetRectalList, apiGetSpecInstList } from '../../../../../api/addStudent'
import { fetchSetValueForStudent } from '../../../../../redux/modules/addStudent'
import { getAddStudentFieldsValue, getAddStudentErrorValues } from '../../../../../selectors/addStudent'
import { apiGetTroopList } from '../../../../../api/dialogs'
import { kurs, military, conditionsOfEducation, status, positions } from '../../../../../constants/addStudent'
import { Container } from './styled'

class Info extends React.Component {
    state = {
        troops: [],
        instGroup: [],
        specInst: [],
        rectal: [],
    }
    changeSelect = event => {
        var name = event.target.name ? event.target.name : event.target.id,
        val = event.target.value;
        var error = false;
        var tab = "infoTab";
        this.props.fetchSetValueForStudent({ name, val, error, tab });
    }

    changeCreatableSelect = (id) => (value) =>
    {
        this.changeSelect({target: {id: id, value: value.label,}});
    }

    createNewOption = (id) => (value) =>
    {
        this.setState({...this.state, [id] : [...this.state[id], { label: value }]})
        this.changeSelect({target: {id: id, value: value,}});
    }
    
    componentDidMount() {
        apiGetInstGroupList().then(res => this.setState({ instGroup: res }));
        apiGetSpecInstList().then(res => this.setState({ specInst: res }));
        apiGetRectalList().then(res => this.setState({ rectal: res }));
        apiGetTroopList().then(res => this.setState({ troops: res }));
    }

    render() {
        return (

            <Container>
                <FlexBox className="flex-box">
                    <FlexRow>
                        <div>
                            <Input id="lastName"
                                type="text"
                                isRequired={true}
                                placeholder="Фамилия"
                                value={this.props.fieldsValue['lastName']}
                                onChange={this.changeSelect}
                                error={this.props.errorValues['infoTab']['lastName']}
                            />
                            {
                                this.props.errorValues['infoTab']['lastName']
                                && (<div className="error-message">Введите фамилию!</div>)
                            }
                        </div>
                        <div>
                            <Input id="firstName"
                                type="text"
                                isRequired={true}
                                placeholder="Имя"
                                value={this.props.fieldsValue['firstName']}
                                onChange={this.changeSelect}
                                error={this.props.errorValues['infoTab']['firstName']}
                            />
                            {
                                this.props.errorValues['infoTab']['firstName']
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
                                value={this.props.fieldsValue['middleName']}
                                onChange={this.changeSelect}
                                error={this.props.errorValues.infoTab['middleName']}
                            />
                            {
                                this.props.errorValues.infoTab['middleName']
                                && (<div className="error-message">Введите отчество!</div>)
                            }
                        </div>
                        <div>
                            <Select id="troopId"
                                data={this.state.troops}
                                value="id"
                                selectedValue={this.props.fieldsValue.troopId}
                                text="numberTroop"
                                isRequired={true}
                                placeholder="Взвод"
                                error={this.props.errorValues.infoTab.troopId}
                                onChange={this.changeSelect}
                            />
                            {
                                this.props.errorValues.infoTab.troopId
                                && (<div className="error-message">Выберите взвод!</div>)
                            }
                        </div>
                    </FlexRow>
                    <FlexRow>

                        <Select id="position"
                            data={positions}
                            value="id"
                            text="val"
                            selectedValue={this.props.fieldsValue.position}
                            placeholder="Должность"
                            onChange={this.changeSelect}
                        />
                        <CreatableSelect id="instGroup" className="custom-style"
                            options={this.state.instGroup}
                            onChange={this.changeCreatableSelect("instGroup")}
                            onCreateOption={this.createNewOption("instGroup")}
                            placeholder="Группа"
                            classNamePrefix="screatable-select"
                            value={this.props.fieldsValue.instGroup ? { label: this.props.fieldsValue.instGroup } : null}
                        />
                    </FlexRow>
                    <FlexRow>
                        <div>
                            <Select id="kurs"
                                data={kurs}
                                value="id"
                                selectedValue={this.props.fieldsValue.kurs}
                                text="val"
                                isRequired={true}
                                placeholder="Курс"
                                onChange={this.changeSelect}
                                error={this.props.errorValues.infoTab.kurs}
                            />
                            {
                                this.props.errorValues.infoTab.kurs
                                && (<div className="error-message">Введите курс!</div>)
                            }
                        </div>
                        <div>
                            <Input id="faculty"
                                type="number"
                                isRequired={true}
                                placeholder="Факультет"
                                value={this.props.fieldsValue['faculty']}
                                onChange={this.changeSelect}
                                error={this.props.errorValues.infoTab.faculty}
                            />
                            {
                                this.props.errorValues.infoTab.faculty
                                && (<div className="error-message">Введите номер факультета!</div>)
                            }
                        </div>
                    </FlexRow>
                    <FlexRow>
                            
                        <CreatableSelect id="specInst" className="custom-style"
                            options={this.state.specInst}
                            onChange={this.changeCreatableSelect("specInst")}
                            onCreateOption={this.createNewOption("specInst")}
                            placeholder="Специальность в ВУЗе"
                            value={ this.props.fieldsValue.specInst ? { label :this.props.fieldsValue.specInst} : null }
                        />
                        <Select id="conditionsOfEducation"
                            data={conditionsOfEducation}
                            value="id"
                            selectedValue={this.props.fieldsValue.conditionsOfEducation}
                            text="val"
                            isRequired={false}
                            placeholder="Условия обучения"
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Select id="status"
                            data={status}
                            value="id"
                            selectedValue={this.props.fieldsValue.status}
                            text="val"
                            placeholder="Статус обучения"
                            onChange={this.changeSelect}
                        />
                        <Input id="yearOfAddMAI"
                            type="text"
                            placeholder="Год поступления в МАИ"
                            value={this.props.fieldsValue['yearOfAddMAI']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="yearOfEndMAI"
                            type="text"
                            placeholder="Год окончания МАИ"
                            value={this.props.fieldsValue['yearOfEndMAI']}
                            onChange={this.changeSelect}
                        />
                        <Input id="yearOfAddVK"
                            type="text"
                            placeholder="Год поступления на ВК"
                            value={this.props.fieldsValue['yearOfAddVK']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="yearOfEndVK"
                            type="text"
                            placeholder="Год окончания ВК"
                            value={this.props.fieldsValue['yearOfEndVK']}
                            onChange={this.changeSelect}
                        />
                        <Input id="numberOfOrder"
                            type="number"
                            placeholder="Номер приказа"
                            value={this.props.fieldsValue['numberOfOrder']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="dateOfOrder"
                            type="text"
                            date={true}
                            placeholder="Дата приказа"
                            value={this.props.fieldsValue['dateOfOrder']}
                            onChange={this.changeSelect}
                        />
                        <CreatableSelect id="rectal" className="custom-style"
                            options={this.state.rectal}
                            onChange={this.changeCreatableSelect("rectal")}
                            onCreateOption={this.createNewOption("rectal")}
                            placeholder="Военкомат"
                            value={this.props.fieldsValue.rectal ? { label : this.props.fieldsValue.rectal} : null}
                        />
                        </FlexRow>
                    <FlexRow>
                        <Select id="military"
                            data={military}
                            value="id"
                            selectedValue={this.props.fieldsValue.military}
                            text="val"
                            isRequired={false}
                            placeholder="Служба в ВС"
                            onChange={this.changeSelect}
                        />
                        <Input id="avarageScore"
                            type="number"
                            placeholder="Средний балл зачетки"
                            value={this.props.fieldsValue['avarageScore']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                </FlexBox>
            </Container>



        );
    }
}

Info.props = {
    fieldsValue: PropTypes.object,
    errorValues: PropTypes.object,
}

function mapStateToProps(store) {
    return {
        fieldsValue: getAddStudentFieldsValue(store),
        errorValues: getAddStudentErrorValues(store),
    }
}

export default connect(mapStateToProps, { fetchSetValueForStudent })(Info)