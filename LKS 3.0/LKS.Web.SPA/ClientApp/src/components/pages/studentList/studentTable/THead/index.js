import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import Input from '../../../../_common/elements/Input'

import {
    fetchGetStudentListData,
    fetchSetStudentListFiltersValue
} from '../../../../../redux/modules/studentList'

import {
    getStudentListFields,
    getStudentListFiltersValue
} from '../../../../../selectors/studentList'

import { Container } from './styled'

class THead extends React.Component {
    state = {
        cahngeFilterFlag: 0, // костыль для задержки отправки запроса на сервер
        filterList: [],
    }
    changeField = async event => {
        var self = this;
        var name = event.target.id,
            value = event.target.value;
        await this.setState(prevState => ({
            cahngeFilterFlag: prevState.cahngeFilterFlag + 1,
        }))
        await this.props.fetchSetStudentListFiltersValue({ fieldName: name, value: value });
        setTimeout(() => {
            self.setState(prevState => ({
                cahngeFilterFlag: prevState.cahngeFilterFlag - 1,
            }))
            // проверяем ввод символоа, если cahngeFilterFlag = 0, то за 0.5 сек больше ничего введено небыло, можно делать запрос
            if (self.state.cahngeFilterFlag === 0) {
                self.props.fetchGetStudentListData()
            }
        }, 500);
    }

    render() {
        return (
            <Container>
                <tr>
                    <td>
                        <Input
                            type="text"
                            id="lastName"
                            value={this.props.filterList['lastName']}
                            name="lastName"
                            placeholder="Фамилия"
                            onChange={this.changeField}
                        />
                    </td>
                    <td>
                        <Input
                            type="text"
                            id="firstName"
                            value={this.props.filterList['firstName']}
                            name="firstName"
                            placeholder="Имя"
                            onChange={this.changeField}
                        />
                    </td>
                    <td>
                        <Input
                            type="text"
                            id="middleName"
                            value={this.props.filterList['middleName']}
                            name="middleName"
                            placeholder="Отчество"
                            onChange={this.changeField}
                        />
                    </td>
                    {this.props.selectedFields.map(val => {
                        if (val.isFiltering)
                            return (
                                <td>
                                    <Input
                                        type="text"
                                        id={val.name}
                                        value={this.props.filterList[val.name]}
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
    fetchSetStudentsListFilters: PropTypes.func,
}

THead.state = {
    cahngeFilterFlag: PropTypes.number,
}

const mapStateToProps = state => ({
    selectedFields: getStudentListFields(state),
    filterList: getStudentListFiltersValue(state),
})

export default connect(mapStateToProps, { fetchGetStudentListData, fetchSetStudentListFiltersValue })(THead)