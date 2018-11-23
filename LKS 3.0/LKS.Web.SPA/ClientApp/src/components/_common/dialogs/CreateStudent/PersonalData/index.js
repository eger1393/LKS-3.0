import React from 'react'
import PropTypes from 'prop-types'
import { Modal } from 'react-bootstrap'
import Input from '../../../elements/Input'
import Select from '../../../elements/Select'
import FormHead from '../../../elements/FormHead'
import Button from '../../../elements/Button'
import { FlexBox, FlexRow, ModalContainer } from '../../../elements/StyleDialogs/styled'

class PersonalData extends React.Component {
    state = {
        fieldValue: [],
    }
    changeSelect = event => {
        var name = event.target.name ? event.target.name : event.target.id,
            val = event.target.value;
        this.setState(prevState => ({
            fieldValue: { ...prevState.fieldValue, [name]: val, }
        }));
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

        // дернуть с бека
        var cycle = [
            { id: '1', val: '1 цикл' },
        ]

        // дернуть с бека
        var prepod = [
            { id: '1', val: 'Ивано И. А.' },
            { id: '2', val: 'Петров Петр Петрович' },
        ]
        return (
                    <FlexBox>
                        <FlexRow>
                            <Select id="cycle" value={cycle} placeholder="Цикл" onChange={this.changeSelect} />
                            <Input id="troopNum"
                                type="text"
                                isRequired={true}
                                placeholder="Номер взвода"
                                value={this.state.fieldValue['troopNum']}
                                onChange={this.changeSelect}
                            />
                        </FlexRow>
                        <FlexRow>
                    <Select id="day" value={day} placeholder="День прихода" onChange={this.changeSelect} />
                    <Select id="prepod" value={prepod} placeholder="Ответственный преподаватель" onChange={this.changeSelect} />
                        </FlexRow>
                    </FlexBox>
        );
    }
}

PersonalData.state = {
    fieldValue: PropTypes.array,
}

export default PersonalData