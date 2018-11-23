import React from 'react'
import PropTypes from 'prop-types'

import { Container} from './styled'

class SidebarContent extends React.Component {

    render() {
        const troop = [
            { id: '1', value: '410' },
            { id: '2', value: '420' },
            { id: '3', value: '430' },
            { id: '4', value: '440' },
            { id: '5', value: '450' },
            { id: '6', value: '460' },
        ]
        return (
            <Container>
                <h3>Взвода</h3>
                {troop.map(ob => {
                    return (<div className="TroopItem" onClick={() => this.props.selectTroop(ob.id)}>{ob.value}</div>)
                })}
            </Container>
        );
    }
}

SidebarContent.props = {
    selectTroop: PropTypes.func.isReqired,
}

export default SidebarContent