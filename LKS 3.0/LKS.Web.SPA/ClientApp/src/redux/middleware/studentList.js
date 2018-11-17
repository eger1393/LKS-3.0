import { all, takeEvery, call, put } from 'redux-saga/effects'

import { apiGetStudentListData } from '../../api/studentList'

import {
    FETCH_GET_STUDENT_LIST_DATA,
    fetchGetStudentListDataSuccess,
    fetchGetStudentListDataFailed,
} from '../modules/studentList'



function* studentList(filters) {
    yield all([
        takeEvery(FETCH_GET_STUDENT_LIST_DATA, function* (filters) {
            try {
                const data = yield call(apiGetStudentListData, filters);
                yield put(fetchGetStudentListDataSuccess(data));
            } catch{
                yield put(fetchGetStudentListDataFailed());
            }
        }),
    ])
}

export default studentList;