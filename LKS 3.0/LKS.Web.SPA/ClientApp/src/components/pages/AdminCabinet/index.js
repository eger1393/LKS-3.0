import React from 'react'

import TroopSidebar from '../../_common/TroopSidebar'
import NavBar from '../../_common/NavBar'
import StudentTable from './StudentTable'
import DataSelectors from './DataSelestors'
import { Container} from './styled'

class AdminCabinet extends React.Component {
    state = {
        sidebarOpen: false,
    }

    toggleSideBar = () => {
        this.setState(prevState => ({
            sidebarOpen: !prevState.sidebarOpen,
        }))
    }

    render() {
        return (
            <Container>
                <NavBar />
                <DataSelectors />
                <StudentTable />
                <TroopSidebar/>
            </Container>
        );
    }
}

export default AdminCabinet