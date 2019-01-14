import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { Panel } from 'react-bootstrap'

import Picky from 'react-picky'
import 'react-picky/dist/picky.css'

import { Container, Contant } from './styled'
import {
  fetchSetStudentListFields,
  fetchSetStudentListFiltersValue,
  fetchGetStudentListData,
} from '../../../../redux/modules/studentList'

import { getStudentListFields, getStudentListFiltersValue } from '../../../../selectors/studentList'


// TODO Вынести в константы 
const fieldArr = [
  { id: 1, name: 'numTroop', value: 'Номер взвода', isFiltering: true },
  { id: 2, name: 'position', value: 'Должность', isFiltering: false },
  { id: 3, name: 'instGroup', value: 'Группа в институте', isFiltering: true },
  { id: 4, name: 'mobilePhone', value: 'Мобильный телефон', isFiltering: true },
  { id: 5, name: 'homePhone', value: 'Домашний телефон', isFiltering: true },
  { id: 6, name: 'faculty', value: 'Факультет', isFiltering: true },
  { id: 7, name: 'kurs', value: 'Курс', isFiltering: true },
  { id: 8, name: 'specInst', value: 'Специальность в институте', isFiltering: true },
  { id: 9, name: 'conditionsOfEducation', value: 'Условия обучения в ВУЗе', isFiltering: false },
  { id: 10, name: 'rectal', value: 'Военкомат', isFiltering: true },
  { id: 11, name: 'specialityName', value: 'Название специальности', isFiltering: true },
  { id: 12, name: 'birthday', value: 'Дата рождения', isFiltering: true },
  { id: 13, name: 'placeBirthday', value: 'Место рождения', isFiltering: true },
  { id: 14, name: 'dateOfOrder', value: 'Дата приказа о приеме', isFiltering: true },
  { id: 15, name: 'numberOfOrder', value: 'Номер приказа о приеме', isFiltering: true },
  { id: 16, name: 'citizenship', value: 'Гражданство', isFiltering: true },
  { id: 17, name: 'nationality', value: 'Национальность', isFiltering: true },
  { id: 18, name: 'familiStatys', value: 'Семейный статус', isFiltering: false },
  { id: 19, name: 'placeOfRegestration', value: 'Адрес прописки', isFiltering: true },
  { id: 20, name: 'placeOfResidence', value: 'Адрес проживания', isFiltering: true },
  { id: 21, name: 'school', value: 'Школа', isFiltering: true },
  { id: 22, name: 'yearOfAddMAI', value: 'Год поступления в МАИ', isFiltering: true },
  { id: 23, name: 'yearOfAddVK', value: 'Год поступления на ВК', isFiltering: true },
  { id: 24, name: 'yearOfEndMAI', value: 'Год окончания МАИ', isFiltering: true },
  { id: 25, name: 'yearOfEndVK', value: 'Год окончания ВК', isFiltering: true },
  { id: 26, name: 'collness', value: 'Звание', isFiltering: true },

]

class DataSelectors extends React.Component {

  changeSelectedFields = val => {
    var self = this;
    self.props.selectedFields.map(ob => {
      // Затираем значение фильтрации в поле, с которого сняли выбор
      if (!val.includes(ob)) {
        self.props.fetchSetStudentListFiltersValue({ fieldName: ob.name, value: '' });
      }
    });
    this.props.fetchSetStudentListFields(val.sort((a, b) => a.id - b.id));
  }

  changeSelectedStudentFilter = async event => { // выпадашка со статусами студентов
    var name = 'studentType',
      val = event.target.value;
    await this.props.fetchSetStudentListFiltersValue({ fieldName: name, value: val }); // добавили фильтр
    await this.props.fetchGetStudentListData(); // дернули студентов
  }

  render() {
    return (
      <Container>
        <Panel id="DetaSelectorsPanel">
          <Panel.Heading >
            <Panel.Title toggle>
              Панель настроек таблицы
                        </Panel.Title>
          </Panel.Heading>
          <Panel.Collapse>
            <Panel.Body>
              <Contant>
                <select onChange={this.changeSelectedStudentFilter}>
                  <option value="all" selected>Все студенты</option>
                  <option value="train">Обучаются</option>
                  <option value="forDeductions">На отчисление</option>
                  <option value="suspended">Отстранены</option>
                  <option value="trainingFees">На сборах</option>
                  <option value="completedFees">Прошел сборы</option>
                </select>

                <Picky
                  options={fieldArr}
                  value={this.props.selectedFields}
                  onChange={this.changeSelectedFields}
                  multiple={true}
                  valueKey="name"
                  labelKey="value"
                  numberDisplayed="2"
                  placeholder=""
                />
              </Contant>
            </Panel.Body>
          </Panel.Collapse>

        </Panel>
      </Container>
    );
  }
}

DataSelectors.props = {
  selectedFields: PropTypes.array,
  filters: PropTypes.array,
  fetchSetStudentListFields: PropTypes.func,
  fetchSetStudentsListFilters: PropTypes.func,
  fetchGetStudentListData: PropTypes.func,
}

const mapStateToProps = state => ({
  selectedFields: getStudentListFields(state),
  filters: getStudentListFiltersValue(state),
})

export default connect(mapStateToProps, {
  fetchSetStudentListFields,
  fetchSetStudentListFiltersValue,
  fetchGetStudentListData,
})(DataSelectors);