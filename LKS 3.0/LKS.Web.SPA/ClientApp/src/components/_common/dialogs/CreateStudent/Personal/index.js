import React from 'react'
import PropTypes from 'prop-types'
import { Col } from 'react-bootstrap'
import Input from '../../../elements/Input'
import Select from '../../../elements/Select'
import AutocompleteInput from '../../../elements/Autocomplete'
import FormHead from '../../../elements/FormHead'
import Button from '../../../elements/Button'
import { FlexBox, FlexRow, ModalContainer } from '../../../elements/StyleDialogs/styled'
import { apiGetTroopNumberList, apiGetInstGroupList, apiGetRectalList, apiCreateStudent } from '../../../../../api/dialogs'

class Info extends React.Component {
    state = {
        fieldValue: this.props.data,
        troops: [],
        instGroup: [],
    }
    changeSelect = event => {
        console.log(event)
        var name = event.target.name ? event.target.name : event.target.id,
            val = event.target.value;
        this.setState(prevState => ({
            fieldValue: { ...prevState.fieldValue, [name]: val, }
        }));
    }
    componentDidMount() {
        var self = this;
        apiGetInstGroupList().then(res => self.setState({ instGroup: res }));
        apiGetTroopNumberList().then(res => self.setState({ troops: res }));
    }
    render() {
        // TODO Вынести в константы
        var kurs = [{ id: '1', val: '2' }, { id: '2', val: '3' }, { id: '3', val: '4' }]
        var сonditionsOfEducation = [{ id: '1', val: 'Бюджетное' }, { id: '2', val: 'Платное' }]
        return (
            <FlexBox>
                <FlexRow>
                    <FlexBox>
                        <Input id="LastName"
                            type="text"
                            isRequired={true}
                            placeholder="Фамилия"
                            value={this.state.fieldValue['LastName']}
                            onChange={this.changeSelect}
                        />
                        <Input id="FirstName"
                            type="text"
                            isRequired={true}
                            placeholder="Имя"
                            value={this.state.fieldValue['FirstName']}
                            onChange={this.changeSelect}
                        />
                        <Input id="MiddleName"
                            type="text"
                            isRequired={true}
                            placeholder="Отчество"
                            value={this.state.fieldValue['MiddleName']}
                            onChange={this.changeSelect}
                        />
                        <Select id="TroopId"
                            data={this.state.troops}
                            value="id"
                            text="numberTroop"
                            isRequired={true}
                            placeholder="Взвод"
                            onChange={this.changeSelect} />
                        <Input id="Rank"
                            type="text"
                            placeholder="Должность"
                            value={this.state.fieldValue['Rank']}
                            onChange={this.changeSelect}
                        />
                        <Select id="InstGroup"
                            data={[{ id: '1', val: '3ВТИ-039' }]}
                            value="id"
                            text="val"
                            isRequired={true}
                            placeholder="Группа"
                            onChange={this.changeSelect} />
                        <Select id="Kurs"
                            data={kurs}
                            value="id"
                            text="val"
                            isRequired={true}
                            placeholder="Курс"
                            onChange={this.changeSelect} />
                        <Input id="Faculty"
                            type="text"
                            isRequired={true}
                            placeholder="Факультет"
                            value={this.state.fieldValue['Faculty']}
                            onChange={this.changeSelect}
                        />
                        <Select id="SpecInst"
                            data={[{ id: '1', val: 'ИВТ'}]}
                            value="id"
                            text="val"
                            isRequired={true}
                            placeholder="Cпециальность в ВУЗе"
                            onChange={this.changeSelect} />
                    </FlexBox> 
                    <FlexBox>
                        <Select id="ConditionsOfEducation"
                            data={сonditionsOfEducation}
                            value="id"
                            text="val"
                            isRequired={true}
                            placeholder="Условия обучения"
                            onChange={this.changeSelect} />
                        <Input id="AvarageScore"
                            type="text"
                            placeholder="Средний балл зачетки"
                            value={this.state.fieldValue['AvarageScore']}
                            onChange={this.changeSelect}
                        />
                        <Input id="YearOfAddMAI"
                            type="text"
                            isRequired={true}
                            placeholder="Год поступления в МАИ"
                            value={this.state.fieldValue['YearOfAddMAI']}
                            onChange={this.changeSelect}
                        />
                        <Input id="YearOfEndMAI"
                            type="text"
                            placeholder="Год окончания МАИ"
                            value={this.state.fieldValue['YearOfEndMAI']}
                            onChange={this.changeSelect}
                        />
                        <Input id="YearOfAddVK"
                            type="text"
                            placeholder="Год поступления на ВК"
                            value={this.state.fieldValue['YearOfAddVK']}
                            onChange={this.changeSelect}
                        />
                        <Input id="YearOfEndVK"
                            type="text"
                            placeholder="Год окончания ВК"
                            value={this.state.fieldValue['YearOfEndVK']}
                            onChange={this.changeSelect}
                        />
                        <Input id="NumberOfOrder"
                            type="text"
                            placeholder="Номер приказа"
                            value={this.state.fieldValue['NumberOfOrder']}
                            onChange={this.changeSelect}
                        />
                        <Input id="DateOfOrder"
                            type="text"
                            placeholder="Дата приказа"
                            value={this.state.fieldValue['DateOfOrder']}
                            onChange={this.changeSelect}
                        />
                        <Select id="Rectal"
                            data={[{ id: '1', val: 'Одинцовский' }]}
                            value="id"
                            text="val"
                            placeholder="Военкомат"
                            onChange={this.changeSelect} />
                    </FlexBox>
                </FlexRow>               
            </FlexBox>
        );
    }
}

Info.state = {
    fieldValue: PropTypes.array,
}

export default Info