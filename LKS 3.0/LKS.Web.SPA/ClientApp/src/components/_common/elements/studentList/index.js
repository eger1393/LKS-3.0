import React from 'react'
import axios from 'axios'

import Input from '../../Input'
import { Container } from './styled'

const GET_STUDENTS_URL = '/api/StudentList/GetStudents'

class StydentsList extends React.Component<{}, { data: object, }> {
    state = {
        data: {},
    }


    getStudents = async () => {
        let self = this
        let result = await axios({
            url: GET_STUDENTS_URL,
            method: 'post',
            headers: { 'Content-type': 'text/json; charset=UTF-8' },
        });
        var t = 'test';
        await result;
        return true;
    }
    componentWillMount() {
       var res = this.getStudents();
    }

    render() {
        return (
            <Container>
                <table className="table">
                    <thead>
                        <tr>
                            <th nowrap>
                                Фамилия
                            </th>
                            <th nowrap>
                                Имя
                            </th>
                            <th nowrap>
                                Отчество
                            </th>
                            <th nowrap>
                                Взвод
                            </th>
                            <th>
                                Должность
                            </th>
                            <th>
                                Специальность(военная)
                            </th>
                            <th>
                                Группа
                            </th>
                            <th>
                                Курс
                            </th>
                            <th>
                                Факультет
                            </th>
                            <th>
                                Специальность в институте
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.data.map(function() {
                            return (
                                <tr>
                                    <th>ob.middleName</th>
                                    <th>ob.firstName</th>
                                    <th>ob.lastName</th>
                                    <td>ob.numTroop</td>
                                    <td>ob.rank</td>
                                    <td>ob.specialityName</td>
                                    <td>ob.instGroup</td>
                                    <td>ob.kurs</td>
                                    <td>ob.faculty</td>
                                    <td>ob.specInst</td>
                                </tr>
                            )
                        })}
                    </tbody>
                </table>
            </Container>
        );
    }
}

export default StydentsList