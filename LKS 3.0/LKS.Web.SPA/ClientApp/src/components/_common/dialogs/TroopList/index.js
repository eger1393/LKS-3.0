import React from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import { Modal, Table } from 'react-bootstrap'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import { FlexBox, ModalContainer } from '../../elements/StyleDialogs/styled'
import { fetchGetTroopList, fetchGetStudentListData } from '../../../../redux/modules/studentList'
import { getTroopList } from '../../../../selectors/studentList'
import { getArrivalDayValue } from '../../../../helpers'
import { apiDeleteTroop } from '../../../../api/dialogs'
import { ContextMenu, MenuItem, ContextMenuTrigger } from "react-contextmenu";

import CreateTroop from '../CreateTroop'

import { Container, Content } from './styled'


class TroopList extends React.Component {
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
      <Modal show={this.props.show} onHide={this.props.onHide}>
        <ModalContainer ref="ModalContainer">
          <Container>
            <FormHead text="Список взводов" handleClick={this.props.onHide} />
            <FlexBox>
              <Content >
                <Table bordered condensed hover>
                  <thead>
                    <tr>
                      <td>
                        Номер взвода
                                            </td>
                      <td>
                        День прихода
                                            </td>
                      <td>
                        Преподаватель
                                            </td>
                      <td>
                        Цикл
                                            </td>
                    </tr>
                  </thead>
                  <tbody>
                    {
                      troops && this.refs.ModalContainer && troops.map(ob => {
                        return (
                          <ContextMenuTrigger
                            renderTag="tr"
                            id="troopMenu"
                            troopId={ob.id}
                            key={ob.id}
                            collect={this.collect}
                            posX={this.refs.ModalContainer.offsetParent.offsetParent.offsetLeft}
                            posY={this.refs.ModalContainer.offsetParent.offsetParent.offsetTop}
                          >
                            <td>
                              {ob.numberTroop}
                            </td>
                            <td>
                              {getArrivalDayValue(ob.arrivalDay)}
                            </td>
                            <td>
                              {ob.prepodInitials}
                            </td>
                            <td>
                              {ob.cycleNumber}
                            </td>
                          </ContextMenuTrigger>
                        )
                      })
                    }

                  </tbody>
                </Table>

              </Content>
            </FlexBox>

            <div className="form-submit">
              <Button onClick={() => this.setState({ troopWindowIsOpen: true, editedTroopId: null })} value="Создать" />
            </div>
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
          </Container>
        </ModalContainer>
      </Modal>
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