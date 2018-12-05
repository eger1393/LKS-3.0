import { all, takeEvery, call, put, select, take } from 'redux-saga/effects'
import { apiCreateStudent } from '../../api/addStudent'
import { getAddStudentFieldsValue } from '../../selectors/addStudent'
import {
    FETCH_ADD_NEW_STUDENT,
    fetchAddStudentSuccess,
    fetchAddStudentFailed,
   
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
    ])
}

export default addStudent;