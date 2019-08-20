import React from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import ModalDialog from '../../ModalDialog'
import Input from '../../elements/Input'
import Select from '../../elements/Select'
import Button from '../../elements/Button'
import CheckBox from '../../elements/Checkbox'
import { FlexBox, FlexRow } from '../../elements/StyleDialogs/styled'
import {
  apiGetCycleList,
  apiGetPrepodList,
  apiCreateTroop,
  apiUpdateTroop,
  apiGetTroopFromId
} from '../../../../api/dialogs'
import { fetchGetTroopList } from '../../../../redux/modules/studentList'
import { getTroopList } from '../../../../selectors/studentList'
import { day } from '../../../../constants/addTroop'

import { Container } from './styled'

class CreateTroop extends React.Component {
  state = {
    fieldValue: {}, // значение полей формы
    cycle: [], // список циклов(тянем из бд)
    prepod: [], // список преподов (тянем из бд)
    error: {}
  }

  changeSelect = event => {
    var name = event.target.name ? event.target.name : event.target.id,
      val = event.target.value,
      troopIsExist = name === 'numberTroop' ? false : this.state.error.troopIsExist;
    this.setState(prevState => ({
      fieldValue: { ...prevState.fieldValue, [name]: val, },
      error: { ...prevState.error, [name]: false, troopIsExist: troopIsExist },
    }));
  }

  createTroop = () => {
    if (this.validate()) {
      if (this.props.troopId) {
        apiUpdateTroop(this.state.fieldValue)
          .then(() => { this.props.fetchGetTroopList(); });
      } else {
        apiCreateTroop(this.state.fieldValue)
          .then(() => { this.props.fetchGetTroopList(); });
      }
      this.props.onHide();
    }

  }

  numberTroopValidate = () => {
    var { troopId, troops } = this.props;
    var val = this.state.fieldValue,
      troopIsExist = false;
    if (!troopId) {
      (troops &&
        troops.map(ob => {
          if (ob.numberTroop == val.numberTroop)
            troopIsExist = true;
        }))
    } else {
      if (troops.find(ob => ob.id == troopId).numberTroop == val.numberTroop)
        troopIsExist = false;
      else
        (troops &&
          troops.map(ob => {
            if (ob.numberTroop == val.numberTroop)
              troopIsExist = true;
          }))
    }
    return troopIsExist;
  }

  validate = () => {

    var val = this.state.fieldValue,
      troopIsExist = this.numberTroopValidate();

    if (!val.numberTroop
      || !val.cycleId
      || !val.arrivalDay
      || !val.prepodId
      || troopIsExist
    ) {
      this.setState(prevSate => (
        {
          error: {
            ...prevSate.error,
            numberTroop: !prevSate.fieldValue.numberTroop,
            cycleId: !prevSate.fieldValue.cycleId,
            arrivalDay: !prevSate.fieldValue.arrivalDay,
            prepodId: !prevSate.fieldValue.prepodId,
            troopIsExist: troopIsExist,
          }
        }
      ))
      return false;
    }
    return true;
  }

  componentDidMount() {
    var self = this;
    apiGetCycleList().then(res => self.setState({ cycle: res }));
    apiGetPrepodList().then(res => self.setState({ prepod: res }));
    if (this.props.troopId) {
      apiGetTroopFromId({ id: this.props.troopId }).then(res =>
        self.setState({ fieldValue: { ...res, id: self.props.troopId } }
        ))
    }
  }

  render() {

    return (
      <ModalDialog
        show={this.props.show}
        onHide={this.props.onHide}
        header="Создать взвод"
      >
        <Container>
          <FlexBox>
            <FlexRow className="flex-row">
              <div>
                <Select
                  id="cycleId"
                  data={this.state.cycle}
                  placeholder="Цикл"
                  onChange={this.changeSelect}
                  value="id"
                  text="number"
                  selectedValue={this.state.fieldValue.cycleId}
                  error={this.state.error.cycleId}
                />
                {
                  this.state.error.cycleId
                  && (<div className="error-message">Выберите цикл!</div>)
                }
              </div>
              <div>
                <Input id="numberTroop"
                  type="text"
                  isRequired={true}
                  placeholder="Номер взвода"
                  value={this.state.fieldValue['numberTroop']}
                  onChange={this.changeSelect}
                  error={this.state.error.numberTroop || this.state.error.troopIsExist}
                />
                {
                  this.state.error.numberTroop
                  && (<div className="error-message">Введите номер взвода!</div>)
                }
                {
                  this.state.error.troopIsExist
                  && (<div className="error-message">Данный взвод уже существует!</div>)
                }
              </div>
            </FlexRow>
            <FlexRow className="flex-row">
              <div>
                <Select id="arrivalDay"
                  data={day}
                  value="id"
                  text="val"
                  placeholder="День прихода"
                  selectedValue={this.state.fieldValue.arrivalDay}
                  onChange={this.changeSelect}
                  error={this.state.error.arrivalDay}
                />
                {
                  this.state.error.arrivalDay
                  && (<div className="error-message">Выберите день прихода!</div>)
                }
              </div>
              <div>
                <Select
                  id="prepodId"
                  data={this.state.prepod}
                  value="id" text="initials"
                  placeholder="Ответственный преподаватель"
                  selectedValue={this.state.fieldValue.prepodId}
                  onChange={this.changeSelect}
                  error={this.state.error.prepodId}
                />
                {
                  this.state.error.prepodId
                  && (<div className="error-message">Выберите преподавателя!</div>)
                }
              </div>
            </FlexRow>
            <FlexRow className="flex-row">
              <CheckBox
                id="sboriTroop"
                value={this.state.fieldValue.sboriTroop}
                title="Возвод для сборов?"
                onChange={this.changeSelect}
              />
              <div />
            </FlexRow>
          </FlexBox>
          <div className="form-submit">
            <Button onClick={this.createTroop} value="Сохранить" />
          </div>
        </Container>
      </ModalDialog>
    );
  }
}

CreateTroop.props = {
  show: PropTypes.bool,
  onHide: PropTypes.func,
  troopId: PropTypes.string,
  fetchGetTroopList: PropTypes.func,
}

CreateTroop.state = {
  fieldValue: PropTypes.array,
}


const mapStateToProps = state => ({
  troops: getTroopList(state),
})

export default connect(mapStateToProps, { fetchGetTroopList })(CreateTroop)