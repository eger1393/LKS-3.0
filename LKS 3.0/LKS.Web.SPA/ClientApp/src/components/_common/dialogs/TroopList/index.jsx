﻿import React, { createRef } from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import { Table } from 'react-bootstrap'
import ModalDialog from '../../ModalDialog'
import Button from '../../elements/Button'
import { FlexBox } from '../../elements/StyleDialogs/styled'
import { fetchGetTroopList, fetchGetStudentListData } from '../../../../redux/modules/studentList'
import { getTroopList } from '../../../../selectors/studentList'
import { getArrivalDayValue } from '../../../../helpers'
import { apiDeleteTroop } from '../../../../api/dialogs'
import { ContextMenu, MenuItem, ContextMenuTrigger } from "react-contextmenu";

import CreateTroop from '../CreateTroop'


class TroopList extends React.Component {
  constructor(props) {
    super(props)
    this.modalRef = createRef()
  }

  state = {
    troopWindowIsOpen: false,
    editedTroopId: null,
  }

  toggleWindow = () => {
    this.setState(prevState => ({ troopWindowIsOpen: !prevState.troopWindowIsOpen }))
  }

  componentDidMount() {
    this.props.fetchGetTroopList()
  }

  collect = props => ({
    id: props.troopId,
  })

  menuClick = (e, data) => {
    switch (data.type) {
      case 'editTroop':
        {
          this.setState({ editedTroopId: data.id });
          this.toggleWindow();
          break;
        }
      case 'deleteTroop':
        {
          apiDeleteTroop(this.props.troops.find(ob => ob.id == data.id))
            .then(data => {
              this.props.fetchGetTroopList();
              this.props.fetchGetStudentListData();
            });
          break;
        }
      default:
    }
  }


  render() {
    const { troops } = this.props;
    return (

      <ModalDialog
        show={this.props.show}
        onHide={this.props.onHide}
        header="Список взводов"
        modalRef={this.modalRef}
      >
        <FlexBox>
          <Table bordered condensed hover>
            <thead>
              <tr>
                <td>Номер взвода</td>
                <td>День прихода</td>
                <td>Преподаватель</td>
                <td>Цикл</td>
              </tr>
            </thead>
            <tbody>
              {
                troops && this.modalRef.current && troops.map(ob => {
                  return (
                    <ContextMenuTrigger
                      renderTag="tr"
                      id="troopMenu"
                      troopId={ob.id}
                      key={ob.id}
                      collect={this.collect}
                      posX={this.modalRef.current.getBoundingClientRect().left - 15}
                      posY={this.modalRef.current.getBoundingClientRect().top - 7}
                    >
                      <td>{ob.numberTroop}</td>
                      <td>{getArrivalDayValue(ob.arrivalDay)}</td>
                      <td>{ob.prepodInitials}</td>
                      <td>{ob.cycleNumber}</td>
                    </ContextMenuTrigger>
                  )
                })
              }

            </tbody>
          </Table>
        </FlexBox>
        <ContextMenu id="troopMenu">
          <MenuItem onClick={this.menuClick} data={{ type: 'editTroop' }}>Редактировать взвод</MenuItem>
          <MenuItem onClick={this.menuClick} data={{ type: 'deleteTroop' }}>Удалить взвод</MenuItem>
        </ContextMenu>
        {this.state.troopWindowIsOpen && (
          <CreateTroop
            show={this.state.troopWindowIsOpen}
            onHide={this.toggleWindow}
            troopId={this.state.editedTroopId}
          />
        )}
      </ModalDialog>
    );
  }
}

TroopList.props = {
  show: PropTypes.bool,
  onHide: PropTypes.func,
  fetchGetTroopList: PropTypes.func,
  fetchGetStudentListData: PropTypes.func,
}

TroopList.state = {
  troopWindowIsOpen: PropTypes.bool,
  editedTroopId: PropTypes.string,
}


const mapStateToProps = state => ({
  troops: getTroopList(state),
})

export default connect(mapStateToProps, { fetchGetTroopList, fetchGetStudentListData })(TroopList)