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
       //var res = this.getStudents();
    }

    render() {
        return (
            <Container>
                
            </Container>
        );
    }
}

export default StydentsList