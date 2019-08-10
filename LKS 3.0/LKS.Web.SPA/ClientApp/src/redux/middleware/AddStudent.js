import { all, takeEvery, call, put, select, fork } from 'redux-saga/effects'
import { apiGetStudent, apiUpdateStudent } from '../../api/addStudent'
import { getAddStudentFieldsValue, getStudentPhoto, getAddStudentRelatives } from '../../selectors/addStudent'
import {
    FETCH_SET_STUDENT,
    fetchSetStudentSuccess,
    FETCH_UPDATE_STUDENT,
    fetchUpdateStudentSuccess,
    fetchUpdateStudentFailed
} from '../modules/addStudent'

import { fetchGetStudentListData } from '../modules/studentList'

function guid() {
  function s4() {
    return Math.floor((1 + Math.random()) * 0x10000)
      .toString(16)
      .substring(1);
  }
  return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
}
function* addStudent() {
    yield all([
        takeEvery(FETCH_SET_STUDENT, function* (data) {
            try {
                const Student = yield call(apiGetStudent, data.payload);
                yield put(fetchSetStudentSuccess(Student));
            } catch{
                //yield put(fetchGetStudentListDataFailed());
            }
        }),
        takeEvery(FETCH_UPDATE_STUDENT, function* () {
            try {
              let Student = yield select(getAddStudentFieldsValue);
              let Photo = yield select(getStudentPhoto);
              let Relatives = yield select(getAddStudentRelatives);
              //Student.relatives = Student.relatives.map(function (obj) {
              //      return { ...obj, StudentId: (Student.id != undefined ? Student.id : null) }
              //  })
                if (Student.position) { Student.position = parseInt(Student.position) } //подумать-переделать
                if (Student.status) { Student.status = parseInt(Student.status) } //подумать-переделать
              let form = new FormData();
              Object.keys(Student).map(key => {
                if (Student[key])
                  form.append(`Student[${key}]`, Student[key])
              });
              form.append('Photo', Photo);

              Relatives && Relatives.map((ob, i) => {
                Object.keys(ob).map(key => {
                  if (ob[key])
                    form.append(`Relatives[${i}].${key}`, ob[key])
                });
              })

              const result = yield call(apiUpdateStudent, form);
                yield put(fetchGetStudentListData());
                yield put(fetchUpdateStudentSuccess(result));
            } catch{
                yield put(fetchUpdateStudentFailed());
            }
        }),
    ])
}

export default addStudent;