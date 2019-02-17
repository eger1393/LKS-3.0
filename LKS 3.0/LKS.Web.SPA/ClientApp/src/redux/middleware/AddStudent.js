import { all, takeEvery, call, put, select, take } from 'redux-saga/effects'
import { apiCreateStudent, apiGetStudent, apiUpdateStudent } from '../../api/addStudent'
import { getAddStudentFieldsValue, getStudentPhoto } from '../../selectors/addStudent'
import {
    FETCH_ADD_NEW_STUDENT,
    fetchAddStudentSuccess,
    fetchAddStudentFailed,
    FETCH_SET_STUDENT,
    fetchSetStudentSuccess,
    FETCH_UPDATE_STUDENT,
    fetchUpdateStudentSuccess
} from '../modules/AddStudent'

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
              var data = {
                Student: Student,
                Photo: Photo,
              }
                Student.id = guid();
              Student.relatives = Student.relatives.map(function (obj) {
                    return { ...obj, StudentId: Student.id }
                })
              const result = yield call(apiCreateStudent, data);
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
              var Student = yield select(getAddStudentFieldsValue);
              Student.relatives = Student.relatives.map(function (obj) {
                    return { ...obj, StudentId: (Student.id != undefined ? Student.id : null) }
                })
                const result = yield call(apiUpdateStudent, Student);
                yield put(fetchUpdateStudentSuccess(result));
            } catch{
                //yield put(fetchAddStudentFailed());
            }
        }),
    ])
}

export default addStudent;