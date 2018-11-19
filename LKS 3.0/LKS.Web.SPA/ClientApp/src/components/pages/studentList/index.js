import React from 'react'


import NavBar from './NavBar'
import StudentTable from './StudentTable'
import DataSelectors from './DataSelestors'
import { Container } from './styled'

class StydentsList extends React.Component {


    render() {
        return (
            <Container>
                <NavBar />
                <DataSelectors/>
                <StudentTable/>
            </Container>
        );
    }
}

export default StydentsList