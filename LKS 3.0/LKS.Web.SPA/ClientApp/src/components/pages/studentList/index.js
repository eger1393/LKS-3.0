import React from 'react'

import TroopSidebar from './TroopSidebar'
import NavBar from './NavBar'
import StudentTable from './StudentTable'
import DataSelectors from './DataSelestors'
import { Container} from './styled'

class StydentsList extends React.Component {
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

export default StydentsList