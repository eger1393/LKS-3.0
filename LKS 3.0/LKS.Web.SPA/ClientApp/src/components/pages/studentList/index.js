import React from 'react'

import StudentTable from './StudentTable'

import { Container } from './styled'

class StydentsList extends React.Component {


    render() {
        return (
            <Container>
                <StudentTable/>
            </Container>
        );
    }
}

export default StydentsList