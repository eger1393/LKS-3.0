import React from 'react'
import PropTypes from 'prop-types'

import { apiGetTroopList } from '../../../../../api/dialogs'
import { Container} from './styled'

class SidebarContent extends React.Component {
    state = {
        troop: [],
    }

    componentDidMount() {
        var self = this;
        apiGetTroopList().then(res => self.setState({ troop: res }));
    }

    render() {
        return (
            <Container>
                <h3 onClick={() => this.props.onClick('')}>Взвода</h3>
                {this.state.troop && (this.state.troop.map(ob => {
                    return (<div className="TroopItem" onClick={() => this.props.onClick(ob.id)}>{ob.numberTroop}</div>)
                }))}
            </Container>
        );
    }
}

SidebarContent.props = {
    onClick: PropTypes.func.isReqired,
}

export default SidebarContent