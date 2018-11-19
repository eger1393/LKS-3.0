import { all, takeEvery, call, put, select } from 'redux-saga/effects'

import { apiGetStudentListData } from '../../api/studentList'

import { getStudentFilters } from '../../selectors/studentList'

import {
    FETCH_GET_STUDENT_LIST_DATA,
    fetchGetStudentListDataSuccess,
    fetchGetStudentListDataFailed,
} from '../modules/studentList'



function* studentList() {
    yield all([
        takeEvery(FETCH_GET_STUDENT_LIST_DATA, function* () {
            try {
                var filterList = yield select(getStudentFilters);
                const data = yield call(apiGetStudentListData, { filters: filterList });
                yield put(fetchGetStudentListDataSuccess(data));
            } catch{
                yield put(fetchGetStudentListDataFailed());
            }
        }),
    ])
}

export default studentList;