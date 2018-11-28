import React from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'

import { apiGetTroopNumberList } from '../../../../../api/dialogs'
import { getStudentListFiltersSelectedTroop, getTroopNumberList } from '../../../../../selectors/studentList'
import { fetchGetTroopNumberList } from '../../../../../redux/modules/studentList'


import { Container} from './styled'

class SidebarContent extends React.Component {
    //state = {
    //    //troop: [],
    //}

    componentDidMount() {
        var self = this;
        this.props.fetchGetTroopNumberList();
        //apiGetTroopList().then(res => self.setState({ troop: res }));
    }

    render() {
        return (
            <Container>
                <h3 onClick={() => this.props.onClick('')}>Взвода</h3>
                {this.props.troop && (this.props.troop.map(ob => {
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
    fetchGetTroopNumberList: PropTypes.func,
}

const mapStateToProps = state => ({
    selectedTroop: getStudentListFiltersSelectedTroop(state),
    troop: getTroopNumberList(state),
})

export default connect(mapStateToProps, { fetchGetTroopNumberList })(SidebarContent)