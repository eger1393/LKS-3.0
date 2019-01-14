import React from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import { Modal, Table } from 'react-bootstrap'
import Input from '../../elements/Input'
import Select from '../../elements/Select'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import { FlexBox, ModalContainer } from '../../elements/StyleDialogs/styled'
import { apiGetTroopList } from '../../../../api/dialogs'
import { fetchGetTroopNumberList } from '../../../../redux/modules/studentList'
import { getTroopNumberList } from '../../../../selectors/studentList'
import { getArrivalDayValue } from '../../../../helpers'
import { ContextMenu, MenuItem, ContextMenuTrigger } from "react-contextmenu";

import CreateTroop from '../CreateTroop'

import { Container, Content } from './styled'


class TroopList extends React.Component {
  state = {
    troop: [],
    troopWindowIsOpen: false,
    editedTroopId: '',
    width: 0,
  }

  constructor(props) {
    super(props)
    this.myInput = React.createRef()
  }

  toggleWindow = () => {
    this.setState(prevState => ({ troopWindowIsOpen: !prevState.troopWindowIsOpen }))
  }

  componentDidMount() {
    var self = this;
    apiGetTroopList().then(res => {
      self.setState({ troop: res }
      )
    })
    //this.boundingBox = this.element.getBoundingClientRect();

    //this.setState({
    //  width: this.myInput.current.offsetWidth
    //});

    //Observable.fromEvent(this.element, "resize")
    //  .subscribe(
    //    () => {
    //      this.boundingBox = this.element.getBoundingClientRect();
    //      this.setState({
    //        width: this.boundingBox.width
    //      });
    //    }
    //  );
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
          console.log('editStudent');
          break;
        }
      case 'deliteTroop':
        {
          console.log('deliteTroop');
          break;
        }
      default:
    }
  }
    
  render() {
    const { troop } = this.state;
    return (
      <Modal show={this.props.show} onHide={this.props.onHide}>
        <ModalContainer ref="ModalContainer">
          <Container>
            <FormHead text="Список взводов" handleClick={this.props.onHide} />
            <FlexBox>
              <Content ref="test2">
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
                      troop && troop.map(ob => {
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

            <div className="form-submit" ref={this.myInput}>
              <Button onClick={this.createTroop} value="Создать" />
            </div>
            <ContextMenu id="troopMenu">
                <MenuItem onClick={this.menuClick} data={{ type: 'editTroop' }}>Редактировать взвод</MenuItem>
                <MenuItem onClick={this.menuClick} data={{ type: 'deliteTroop' }}>Удалить взвод</MenuItem>
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
  fetchGetTroopNumberList: PropTypes.func,
}

TroopList.state = {
  fieldValue: PropTypes.array,
}


const mapStateToProps = state => ({
  troops: getTroopNumberList(state),
})

export default connect(null, { fetchGetTroopNumberList })(TroopList)