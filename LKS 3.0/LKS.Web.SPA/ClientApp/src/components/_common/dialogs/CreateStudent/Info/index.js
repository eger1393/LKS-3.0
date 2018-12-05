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
    render() {
        // TODO Вынести в константы
        var kurs = [{ id: '1', val: '2' }, { id: '2', val: '3' }, { id: '3', val: '4' }]
        var сonditionsOfEducation = [{ id: '1', val: 'Бюджетное' }, { id: '2', val: 'Платное' }]
        var status = [{ id: 0, val: "Обучается" }, { id: 1, val: "На отсчисление" }, { id: 2, val: "Отстранен" },
            { id: 3, val: "На сборах" }, { id: 4, val: "Прошел сборы" },]
        var ranks = [{ id: 0, val: "КВ" }, { id: 1, val: "КО1" }, { id: 2, val: "КО2" },
            { id: 3, val: "КО3" }, { id: 4, val: "Ж" }, { id: 5, val: "С" },]
        return (
            <Container>
                <FlexBox className="flex-box">
                    <FlexRow>
                        <Input id="LastName"
                            type="text"
                            isRequired={true}
                            placeholder="Фамилия"
                            value={this.props.fieldValue['LastName']}
                            onChange={this.changeSelect}
                        />
                        <Input id="FirstName"
                            type="text"
                            isRequired={true}
                            placeholder="Имя"
                            value={this.props.fieldValue['FirstName']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="MiddleName"
                            type="text"
                            isRequired={true}
                            placeholder="Отчество"
                            value={this.props.fieldValue['MiddleName']}
                            onChange={this.changeSelect}
                        />
                        <Select id="TroopId"
                            data={this.state.troops}
                            value="id"
                            text="numberTroop"
                            isRequired={true}
                            placeholder="Взвод"
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Select id="Rank"
                            data={ranks}
                            value="id"
                            text="val"
                            placeholder="Должность"
                            onChange={this.changeSelect}
                        />
                        {
                            this.state.instGroup.length != 0 && (<Autocomplete id="InstGroup"
                                data={this.state.instGroup} onChange={this.changeSelect} placeholder="Группа"
                        />)}
                    </FlexRow>
                    <FlexRow>
                        <Select id="Kurs"
                            data={kurs}
                            value="id"
                            text="val"
                            isRequired={true}
                            placeholder="Курс"
                            onChange={this.changeSelect}
                        />
                        <Input id="Faculty"
                            type="text"
                            isRequired={true}
                            placeholder="Факультет"
                            value={this.props.fieldValue['Faculty']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                            {
                            this.state.specInst.length != 0 && (<Autocomplete id="SpecInst"
                                data={this.state.specInst} onChange={this.changeSelect} placeholder="Специальность в ВУЗе"
                            />)}
                        <Select id="ConditionsOfEducation"
                            data={сonditionsOfEducation}
                            value="id"
                            text="val"
                            isRequired={true}
                            placeholder="Условия обучения"
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Select id="Status"
                            data={status}
                            value="id"
                            text="val"
                            placeholder="Статус обучения"
                            onChange={this.changeSelect}
                        />

                        {//<Input id="AvarageScore" type="text" placeholder="Средний балл зачетки"  value={this.state.fieldValue['AvarageScore']} onChange={this.changeSelect} />
                        }

                        <Input id="YearOfAddMAI"
                            type="text"
                            isRequired={true}
                            placeholder="Год поступления в МАИ"
                            value={this.props.fieldValue['YearOfAddMAI']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="YearOfEndMAI"
                            type="text"
                            placeholder="Год окончания МАИ"
                            value={this.props.fieldValue['YearOfEndMAI']}
                            onChange={this.changeSelect}
                        />
                        <Input id="YearOfAddVK"
                            type="text"
                            placeholder="Год поступления на ВК"
                            value={this.props.fieldValue['YearOfAddVK']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="YearOfEndVK"
                            type="text"
                            placeholder="Год окончания ВК"
                            value={this.props.fieldValue['YearOfEndVK']}
                            onChange={this.changeSelect}
                        />
                        <Input id="NumberOfOrder"
                            type="text"
                            placeholder="Номер приказа"
                            value={this.props.fieldValue['NumberOfOrder']}
                            onChange={this.changeSelect}
                        />
                    </FlexRow>
                    <FlexRow>
                        <Input id="DateOfOrder"
                            type="text"
                            placeholder="Дата приказа"
                            value={this.props.fieldValue['DateOfOrder']}
                            onChange={this.changeSelect}
                        />
                        {
                            this.state.rectals.length != 0 && (<Autocomplete id="Rectal"
                                data={this.state.rectals} onChange={this.changeSelect} placeholder="Военкомат"
                            />)}
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