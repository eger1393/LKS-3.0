import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import Input from '../../../../_common/elements/Input'

import { fetchGetStudentListData } from '../../../../../redux/modules/studentList'

import { Container } from './styled'

class THead extends React.Component {
    state = {
        cahngeFilterFlag: 0,
        filterList: [],
    }
    changeField = async event => {
        var self = this;
        var name = event.target.id,
            value = event.target.value;
        await this.setState(prevState => ({
            filterList: { ...prevState.filterList, [name]: value },
            cahngeFilterFlag: prevState.cahngeFilterFlag + 1,
        }))
        setTimeout(() => {
            self.setState(prevState => ({
                cahngeFilterFlag: prevState.cahngeFilterFlag - 1,
            }))
            if (self.state.cahngeFilterFlag === 0) {
                self.props.fetchGetStudentListData({ filters: self.state.filterList })
            }
        }, 500);
    }

    render() {
        // Захардкодил поля, потом они будут передаваться с основной страницы
        const fieldArr = [
            { id: 1, name: 'numTroop', value: 'Номер взвода', isFiltering: true },
            { id: 2, name: 'collness', value: 'Звание', isFiltering: true },
            { id: 3, name: 'rank', value: 'Должность', isFiltering: true },
            { id: 4, name: 'kurs', value: 'Курс', isFiltering: false },

        ]
        return (
            <Container>
                <tr>
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
                </tr>
            </Container>
        );
    }
}

THead.props = {
    fetchGetStudentListData: PropTypes.func,
}

THead.state = {
    cahngeFilterFlag: PropTypes.number,
}

export default connect(null, { fetchGetStudentListData })(THead)