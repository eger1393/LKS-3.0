import React from 'react'
import Sidebar from 'react-sidebar'

import SVGIcon from '../../../_common/elements/SVGIcon'
import SidebarContent from './SidebarContent'
import { Container, SidebarButton } from './styled'

class TroopSidebar extends React.Component {
    state = {
        sidebarOpen: false,
    }

    selectTroop = id => {
        console.log(id);
    }

    toggleSideBar = () => {
        this.setState(prevState => ({
            sidebarOpen: !prevState.sidebarOpen,
        }))
    }

    render() {
        return (
            <Container>
                <Sidebar
                    sidebar={<SidebarContent selectTroop={this.selectTroop} />}
                    open={this.state.sidebarOpen}
                    onSetOpen={this.toggleSideBar}
                    styles={{ sidebar: { background: "white" } }}
                    sidebarClassName="TroopSidebar"
                >
                    <SidebarButton onClick={this.toggleSideBar}>
                        <SVGIcon name="rightArrowsCouple" />
                    </SidebarButton>
                </Sidebar>
            </Container>
        );
    }
}

export default TroopSidebar