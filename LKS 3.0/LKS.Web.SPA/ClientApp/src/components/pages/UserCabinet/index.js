import React from 'react'

import StudentTable from './StudentTable'
import NavBar from '../../_common/NavBar'
import { Container } from './styled'

class UserCabinet extends React.Component {
  render() {
    return (
      <Container>
        <NavBar />
        <StudentTable />
      </Container>
    );
  }
}

export default UserCabinet