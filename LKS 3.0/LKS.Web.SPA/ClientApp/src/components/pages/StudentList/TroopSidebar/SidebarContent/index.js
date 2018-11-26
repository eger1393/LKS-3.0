import React from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'

import { apiGetTroopList } from '../../../../../api/dialogs'
import { getStudentListFiltersSelectedTroop } from '../../../../../selectors/studentList'

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
                    return (
                        <div
                            className={`TroopItem ${ob.id === this.props.selectedTroop ? ' selected' : ''}`}
                            onClick={() => this.props.onClick(ob.id)}
                        >
                            {ob.numberTroop}
                        </div>
                    )
                }))}
            </Container>
        );
    }
}

SidebarContent.props = {
    onClick: PropTypes.func.isReqired,
    selectedTroop: PropTypes.string,
}

const mapStateToProps = state => ({
    selectedTroop: getStudentListFiltersSelectedTroop(state),
})

export default connect(mapStateToProps)(SidebarContent)