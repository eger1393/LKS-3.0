import React from 'react'

import StudentTable from './StudentTable'
import DataSelectors from './DataSelestors'
import { Container } from './styled'

class StydentsList extends React.Component {


    render() {
        return (
            <Container>
                <DataSelectors/>
                <StudentTable/>
            </Container>
        );
    }
}

export default StydentsList