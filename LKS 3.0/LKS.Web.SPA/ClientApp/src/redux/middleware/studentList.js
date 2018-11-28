import { all, takeEvery, call, put, select, take } from 'redux-saga/effects'

import { apiGetStudentListData, apiSetStudentPosition, apiSetStudentStatus } from '../../api/studentList'

import { getStudentListFilters } from '../../selectors/studentList'

import { apiGetTroopNumberList } from '../../api/dialogs'

import {
    FETCH_GET_STUDENT_LIST_DATA,
    fetchGetStudentListDataSuccess,
    fetchGetStudentListDataFailed,
    FETCH_GET_TROOP_NUMBER_LIST,
    fetchGetTroopNumberListSuccess,
    FETCH_SET_STUDENT_STATUS,
    FETCH_SET_STUDENT_POSITION
} from '../modules/studentList'



function* studentList() {
    yield all([
        takeEvery(FETCH_GET_STUDENT_LIST_DATA, function* () {
            try {
                var filters = yield select(getStudentListFilters);
                const data = yield call(apiGetStudentListData, filters);
                yield put(fetchGetStudentListDataSuccess(data));
            } catch{
                yield put(fetchGetStudentListDataFailed());
            }
        }),
        takeEvery(FETCH_SET_STUDENT_STATUS, function* (data) {
            yield call(apiSetStudentStatus, data.payload)
        }),
        takeEvery(FETCH_SET_STUDENT_POSITION, function* (data) {
            yield call(apiSetStudentPosition, data.payload)
        }),
        takeEvery(FETCH_GET_TROOP_NUMBER_LIST, function* () {
            try {
                const data = yield call(apiGetTroopNumberList);
                yield put(fetchGetTroopNumberListSuccess(data));
            } catch{
                //yield put(fetchGetStudentListDataFailed());
            }
        }),
    ])
}

export default studentList;