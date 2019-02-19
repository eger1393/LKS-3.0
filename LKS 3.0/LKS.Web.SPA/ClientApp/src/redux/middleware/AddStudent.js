import { all, takeEvery, call, put, select, fork } from 'redux-saga/effects'
import { apiCreateStudent, apiGetStudent, apiUpdateStudent } from '../../api/addStudent'
import { getAddStudentFieldsValue, getStudentPhoto } from '../../selectors/addStudent'
import {
    FETCH_ADD_NEW_STUDENT,
    fetchAddStudentSuccess,
    fetchAddStudentFailed,
    FETCH_SET_STUDENT,
    fetchSetStudentSuccess,
    FETCH_UPDATE_STUDENT,
    fetchUpdateStudentSuccess,
    fetchUpdateStudentFailed
} from '../modules/AddStudent'

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
        takeEvery(FETCH_ADD_NEW_STUDENT, function* () {
            try {
              var Student = yield select(getAddStudentFieldsValue);
              var Photo = yield select(getStudentPhoto);

               Student.id = guid();
              Student.relatives = Student.relatives.map(function (obj) {
                    return { ...obj, StudentId: Student.id }
              })
              
                let form = new FormData();
              Object.keys(Student).map(key => {
                if (Student[key])
                  form.append(`Student[${key}]`, Student[key])
              });
                form.append('Photo', Photo);

              const result = yield call(apiCreateStudent, form);
                yield put(fetchGetStudentListData());
                yield put(fetchAddStudentSuccess(result));
            } catch{
                yield put(fetchAddStudentFailed());
            }
        }),
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
              Student.relatives = Student.relatives.map(function (obj) {
                    return { ...obj, StudentId: (Student.id != undefined ? Student.id : null) }
              })
              let form = new FormData();
              Object.keys(Student).map(key => {
                if (Student[key])
                  form.append(`Student[${key}]`, Student[key])
              });
              form.append('Photo', Photo);
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