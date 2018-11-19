﻿import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import Input from '../../../../_common/elements/Input'

import { fetchGetStudentListData } from '../../../../../redux/modules/studentList'
import { getStudentListFields } from '../../../../../selectors/studentList'

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

    componentWillReceiveProps(nextProps) {
        var self = this;
        self.setState(prevState => {
            var filters = [];
            filters['lastName'] = prevState.filterList['lastName'] ? prevState.filterList['lastName'] : '';
            filters['firstName'] = prevState.filterList['firstName'] ? prevState.filterList['firstName'] : '';
            filters['middleName'] = prevState.filterList['middleName'] ? prevState.filterList['middleName'] : '';
            nextProps.selectedFields.map(ob => {
                filters[ob.name] = prevState.filterList[ob.name] ? prevState.filterList[ob.name] : '';
            });
            return {
                filterList: { ...filters },
            };
        })
    }

    render() {
        return (
            <Container>
                <tr>
                    <td>
                        <Input
                            type="text"
                            id="lastName"
                            value={this.state.filterList['lastName']}
                            name="lastName"
                            placeholder="Фамилия"
                            onChange={this.changeField}
                        />
                    </td>
                    <td>
                        <Input
                            type="text"
                            id="firstName"
                            value={this.state.filterList['firstName']}
                            name="firstName"
                            placeholder="Имя"
                            onChange={this.changeField}
                        />
                    </td>
                    <td>
                        <Input
                            type="text"
                            id="middleName"
                            value={this.state.filterList['middleName']}
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
                                        value={this.state.filterList[val.name]}
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

const mapStateToProps = state => ({
    selectedFields: getStudentListFields(state),
})

export default connect(mapStateToProps, { fetchGetStudentListData })(THead)