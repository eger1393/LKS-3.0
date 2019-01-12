import { all, takeEvery, call, put, select, take } from 'redux-saga/effects'
import { apiCreateStudent, apiGetStudent, apiUpdateStudent } from '../../api/addStudent'
import { getAddStudentFieldsValue } from '../../selectors/addStudent'
import {
    FETCH_ADD_NEW_STUDENT,
    fetchAddStudentSuccess,
    fetchAddStudentFailed,
    FETCH_SET_STUDENT,
    fetchSetStudentSuccess,
    FETCH_UPDATE_STUDENT,
    fetchUpdateStudentSuccess
} from '../modules/AddStudent'



function* addStudent() {
    yield all([
        takeEvery(FETCH_ADD_NEW_STUDENT, function* () {
            try {
                var newStudent = yield select(getAddStudentFieldsValue);
                const result = yield call(apiCreateStudent, newStudent);
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
                var newStudent = yield select(getAddStudentFieldsValue);
                const result = yield call(apiUpdateStudent, newStudent);
                yield put(fetchUpdateStudentSuccess(result));
            } catch{
                //yield put(fetchAddStudentFailed());
            }
        }),
    ])
}

export default addStudent;