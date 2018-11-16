import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import Input from '../../../../_common/Input'

import { fetchSetStudentsListFilter } from '../../../../../redux/modules/studentList'

import { Container } from './styled'

class THead extends React.Component {
    //< { fetchSetStudentsListFilter: fetchSetStudentsListFilter },>
    changeField = event => {
        var name = event.target.id,
            value = event.target.value;
        this.props.fetchSetStudentsListFilter({ fieldName: name, value: value });
    }

    render() {
        // Захардкодил поля, потом они будут передаваться с основной страницы
        const fieldArr = [
            { id: 1, name: 'troopNum', value: 'Номер взвода', isFiltering: true },
            { id: 2, name: 'collness', value: 'Звание', isFiltering: true },
            { id: 3, name: 'rank', value: 'Должность', isFiltering: true },
            { id: 4, name: 'kurs', value: 'Курс', isFiltering: false },

        ]
        return (
            <Container>
                <td>
                    <Input
                        type="text"
                        id="lastName"
                        name="lastName"
                        placeholder="Фамилия"
                        onChange={this.changeField}
                    />
                </td>
                <td>
                    <Input
                        type="text"
                        id="firstName"
                        name="firstName"
                        placeholder="Имя"
                        onChange={this.changeField}
                    />
                </td>
                <td>
                    <Input
                        type="text"
                        id="middleName"
                        name="middleName"
                        placeholder="Отчество"
                        onChange={this.changeField}
                    />
                </td>
                {fieldArr.map(val => {
                    if (val.isFiltering)
                        return (
                            <td>
                                <Input
                                    type="text"
                                    id={val.name}
                                    name={val.name}
                                    placeholder={val.value}
                                    onChange={this.changeField}
                                />
                            </td>
                        );
                    else
                        return (
                            <td>
                                {val.value}
                            </td>
                            );
                })}
            </Container>
        );
    }
}

THead.props = {
    fetchSetStudentsListFilter: fetchSetStudentsListFilter,
}

export default connect(null,{ fetchSetStudentsListFilter })(THead)