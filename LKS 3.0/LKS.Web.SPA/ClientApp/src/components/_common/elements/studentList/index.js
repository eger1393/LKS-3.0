import React from 'react'
import axios from 'axios'

import Input from '../../Input'
import { Container } from './styled'

const GET_STUDENTS_URL = '/api/studentList/GetStudents'

class StydentsList extends React.Component<{}, { data: object, }> {
    state = {
        data: {},
    }


    getStudents = async () => {
        let self = this
        await axios({
            url: GET_STUDENTS_URL,
            method: 'post',
            headers: { 'Content-type': 'text/json; charset=UTF-8' },
            //data: this.state.fieldsValue['friend-phone'],
        }).then(
            function (query) {
                self.setState({
                    data: query.data.data
                });
            },
            function (query) {
                console.log('ERR!');
            }
        )
        return;
    }
    componentWillMount() {
        this.getStudents();
    }

    render() {
        return (
            <Container>
                <table class="table">
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

                    </tbody>
                </table>
            </Container>
        );
    }
}

export default StydentsList