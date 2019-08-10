import React, {createRef} from 'react'
import PropTypes from 'prop-types'
import { Table } from 'react-bootstrap'
import Modal from '../../ModalDialog'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import { FlexBox, ModalContainer } from '../../elements/StyleDialogs/styled'
import { getCoolnessValue } from '../../../../helpers'
import { apiDeletePrepod, apiGetPrepodList } from '../../../../api/prepod'
import { ContextMenu, MenuItem, ContextMenuTrigger } from "react-contextmenu";

import CreatePrepod from '../CreatePrepod'

import { Container, Content } from './styled'


class PrepodList extends React.Component {
  constructor(props) {
    super(props)
    this.modalRef = createRef()
  }

  state = {
    prepodWindowIsOpen: false,
    editedPrepodId: null,
    prepodList: null,
  }

  toggleWindow = () => {
    if (this.state.prepodWindowIsOpen)
      apiGetPrepodList().then(data => this.setState({ prepodList: data }));
    this.setState(prevState => ({ prepodWindowIsOpen: !prevState.prepodWindowIsOpen }))
  }

  componentDidMount() {
    apiGetPrepodList().then(data => this.setState({ prepodList: data }));
  }

  collect = props => ({
    id: props.troopId,
  })

  menuClick = (e, data) => {
    switch (data.type) {
      case 'editPrepod':
        {
          this.setState({ editedPrepodId: data.id });
          this.toggleWindow();
          break;
        }
      case 'deletePrepod':
        {
          apiDeletePrepod(this.state.prepodList.find(ob => ob.id == data.id))
            .then(() => {
              apiGetPrepodList().then(data => this.setState({ prepodList: data }));
            });
          break;
        }
      default:
    }
  }

  render() {
    const { prepodList } = this.state;
    return (
      <Modal show={this.props.show} onHide={this.props.onHide}>
        <ModalContainer ref={this.modalRef}>
          <Container>
            <FormHead text="Список преподавателей" handleClick={this.props.onHide} />
            <FlexBox>
              <Content >
                <Table bordered condensed hover>
                  <thead>
                    <tr>
                      <td>
                        Фамилия
                      </td>
                      <td>
                        Имя
                      </td>
                      <td>
                        Отчество
                      </td>
                      <td>
                        Звание
                      </td>
                      <td>
                        Должность
                      </td>
                      <td>
                        Дополнительно
                      </td>
                    </tr>
                  </thead>
                  <tbody>
                    {
                      prepodList && this.modalRef.current && prepodList.map(ob => {
                        return (
                          <ContextMenuTrigger
                            renderTag="tr"
                            id="prepodMenu"
                            troopId={ob.id}
                            key={ob.id}
                            collect={this.collect}
                            posX={this.modalRef.current.getBoundingClientRect().left - 15}
                            posY={this.modalRef.current.getBoundingClientRect().top - 7}
                          >
                            <td>
                              {ob.middleName}
                            </td>
                            <td>
                              {ob.firstName}
                            </td>
                            <td>
                              {ob.lastName}
                            </td>
                            <td>
                              {getCoolnessValue(ob.coolness)}
                            </td>
                            <td>
                              {ob.prepodRank}
                            </td>
                            <td>
                              {ob.additionalInfo}
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
              <Button onClick={() => this.setState({ troopWindowIsOpen: true, editedPrepodId: null })} value="Создать" />
            </div>
            <ContextMenu id="prepodMenu">
              <MenuItem onClick={this.menuClick} data={{ type: 'editPrepod' }}>Редактировать преподавателя</MenuItem>
              <MenuItem onClick={this.menuClick} data={{ type: 'deletePrepod' }}>Удалить преподавателя</MenuItem>
            </ContextMenu>
            {this.state.prepodWindowIsOpen && (
              <CreatePrepod
                show={this.state.prepodWindowIsOpen}
                onHide={this.toggleWindow}
                prepodId={this.state.editedPrepodId}
              />
            )}
          </Container>
        </ModalContainer>
      </Modal>
    );
  }
}

PrepodList.props = {
  show: PropTypes.bool,
  onHide: PropTypes.func,
  fetchGetTroopList: PropTypes.func,
  fetchGetStudentListData: PropTypes.func,
}

PrepodList.state = {
  prepodWindowIsOpen: PropTypes.bool,
  editedPrepodId: PropTypes.string,
  prepodList: PropTypes.array,
}

export default PrepodList