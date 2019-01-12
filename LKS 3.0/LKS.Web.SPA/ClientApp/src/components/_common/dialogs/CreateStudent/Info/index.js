import React from 'react'
import PropTypes from 'prop-types'
import Input from '../../../elements/Input'
import Select from '../../../elements/Select'
import Autocomplete from '../../../elements/Autocomplete'
import { connect } from 'react-redux'
import { FlexBox, FlexRow, ModalContainer } from '../../../elements/StyleDialogs/styled'
import { apiGetInstGroupList, apiGetRectalList, apiGetSpecInstList } from '../../../../../api/addStudent'
import { fetchSetValueForStudent } from '../../../../../redux/modules/AddStudent'
import { getAddStudentFieldsValue  } from '../../../../../selectors/addStudent'
import { apiGetTroopList } from '../../../../../api/dialogs'
import { Container } from './styled'

class Info extends React.Component {
    state = {
        troops: [],
        instGroup: [],
        specInst: [],
        rectals: [],
    }
    changeSelect = event => {
        console.log(event)

        var name = event.target.name ? event.target.name : event.target.id,
            val = event.target.value;

        this.props.fetchSetValueForStudent({ name, val });
    }
    componentWillMount() {
        if (this.isUnmounted) {
            return;
        }
        var self = this;
        apiGetInstGroupList().then(res =>
            self.setState({ instGroup: res })
        );
        apiGetSpecInstList().then(res =>
            self.setState({ specInst: res })
        );
        apiGetRectalList().then(res =>
            self.setState({ rectals: res })
        );
        apiGetTroopList().then(res => self.setState({ troops: res }));
    }
    componentWillUnmount() {
        this.isUnmounted = true;
    }
    render() {
        // TODO Вынести в константы
        var kurs = [{ id: '1', val: '2' }, { id: '2', val: '3' }, { id: '3', val: '4' }]

        var military = [{ id: '1', val: 'Годен' }, { id: '2', val: 'Не годен' }, { id: '3', val: 'Прошел службу' }]
        var сonditionsOfEducation = [{ id: '1', val: 'Бюджетное' }, { id: '2', val: 'Платное' }]
        var status = [{ id: 0, val: "Обучается" }, { id: 1, val: "На отсчисление" }, { id: 2, val: "Отстранен" },
            { id: 3, val: "На сборах" }, { id: 4, val: "Прошел сборы" },]
        var ranks = [{ id: 0, val: "КВ" }, { id: 1, val: "КО1" }, { id: 2, val: "КО2" },
            { id: 3, val: "КО3" }, { id: 4, val: "Ж" }, { id: 5, val: "С" },]
        return (
            <Container>
                <FlexBox className="flex-box">
                    <FlexRow>
                        <Input id="lastName"
                            type="text"
                            isRequired={true}
                            placeholder="Фамилия"
                            value={this.props.fieldValue['lastName']}
                            onChange={this.changeSelect}
                        />
                        <Input id="firstName"
                            type="text"
                            isRequired={true}
                            placeholder="Имя"
                            value={this.props.fieldValue['firstName']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="middleName"
                            type="text"
                            isRequired={true}
                            placeholder="Отчество"
                            value={this.props.fieldValue['middleName']}
                            onChange={this.changeSelect}
                        />
                        <Select id="troopId"
                            data={this.state.troops}
                            value="id"
                            selectedValue={this.props.fieldValue.troopId}
                            text="numberTroop"
                            isRequired={true}
                            placeholder="Взвод"
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Select id="rank"
                            data={ranks}
                            value="id"
                            text="val"
                            selectedValue={this.props.fieldValue.rank}
                            placeholder="Должность"
                            onChange={this.changeSelect}
                        />
                        {
                            this.state.instGroup.length != 0 && (<Autocomplete id="instGroup"
                                data={this.state.instGroup} onChange={this.changeSelect} placeholder="Группа" value={this.props.fieldValue.instGroup}
                        />)}
                    </FlexRow>
                    <FlexRow>
                        <Select id="kurs"
                            data={kurs}
                            value="id"
                            selectedValue={this.props.fieldValue.kurs}
                            text="val"
                            isRequired={true}
                            placeholder="Курс"
                            onChange={this.changeSelect}
                        />
                        <Input id="Faculty"
                            type="text"
                            isRequired={true}
                            placeholder="Факультет"
                            value={this.props.fieldValue['faculty']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                            {
                            this.state.specInst.length != 0 && (<Autocomplete id="specInst"
                                data={this.state.specInst} onChange={this.changeSelect} placeholder="Специальность в ВУЗе" value={this.props.fieldValue.specInst}
                            />)}
                        <Select id="conditionsOfEducation"
                            data={сonditionsOfEducation}
                            value="id"
                            selectedValue={this.props.fieldValue.conditionsOfEducation}
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
                            selectedValue={this.props.fieldValue.status}
                            text="val"
                            placeholder="Статус обучения"
                            onChange={this.changeSelect}
                        />
                                             
                        <Input id="yearOfAddMAI"
                            type="text"
                            isRequired={true}
                            placeholder="Год поступления в МАИ"
                            value={this.props.fieldValue['yearOfAddMAI']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="yearOfEndMAI"
                            type="text"
                            placeholder="Год окончания МАИ"
                            value={this.props.fieldValue['yearOfEndMAI']}
                            onChange={this.changeSelect}
                        />
                        <Input id="yearOfAddVK"
                            type="text"
                            placeholder="Год поступления на ВК"
                            value={this.props.fieldValue['yearOfAddVK']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="yearOfEndVK"
                            type="text"
                            placeholder="Год окончания ВК"
                            value={this.props.fieldValue['yearOfEndVK']}
                            onChange={this.changeSelect}
                        />
                        <Input id="numberOfOrder"
                            type="text"
                            placeholder="Номер приказа"
                            value={this.props.fieldValue['numberOfOrder']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="dateOfOrder"
                            type="text"
                            placeholder="Дата приказа"
                            value={this.props.fieldValue['dateOfOrder']}
                            onChange={this.changeSelect}
                        />
                        {
                            this.state.rectals.length != 0 && (<Autocomplete id="rectal"
                                data={this.state.rectals} onChange={this.changeSelect} placeholder="Военкомат" value={this.props.fieldValue.rectal}
                            />)}
                    </FlexRow> 
                    <FlexRow>
                        <Select id="military"
                            data={military}
                            value="id"
                            selectedValue={this.props.fieldValue.military}
                            text="val"
                            isRequired={false}
                            placeholder="Служба в ВС"
                            onChange={this.changeSelect}
                        />
                        <Input id="avarageScore"
                            type="text"
                            placeholder="Средний балл зачетки"
                            value={this.props.fieldValue['avarageScore']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                </FlexBox>

            </Container>
            
        );
    }
}

Info.props = {
    fieldValue: PropTypes.object,
    setValue: PropTypes.func,
}

function mapStateToProps(store) {
    return {
        fieldValue: getAddStudentFieldsValue(store),
    }
}

export default connect(mapStateToProps, { fetchSetValueForStudent })(Info)