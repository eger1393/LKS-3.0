﻿const module = 'studentList'

export const FETCH_SET_STUDENTS_LIST_FILTER = `${module}/FETCH_SET_FILTER`
export const FETCH_GET_STUDENT_LIST_DATA = `${module}/FETCH_GET_STUDENT_LIST_DATA`
export const FETCH_GET_STUDENT_LIST_DATA_SUCCESS = `${module}/FETCH_GET_STUDENT_LIST_DATA_SUCCESS`
export const FETCH_GET_STUDENT_LIST_DATA_FAILED = `${module}/FETCH_GET_STUDENT_LIST_DATA_FAILED`

const defaultState = {
    filtersValue: {},
    studentListData: [],
    dataLoading: false,
    errorLoadingMessage: '',
}

export default function reducer(studentListState = defaultState, action = {}) {
    const { type, payload } = action;
    switch (type) {
        case FETCH_SET_STUDENTS_LIST_FILTER:
            return {
                ...studentListState, 
                filtersValue: {
                    ...studentListState.filtersValue,
                    [payload.fieldName]: payload.value,
                }
            }
        case FETCH_GET_STUDENT_LIST_DATA:
            return { // при обновлении данных, ставить контент лоадер
                ...studentListState,
                dataLoading: true,
            }
        case FETCH_GET_STUDENT_LIST_DATA_SUCCESS:
            return {
                ...studentListState,
                dataLoading: false,
                studentListData: payload.studentList,
            }
        case FETCH_GET_STUDENT_LIST_DATA_FAILED:
            return {
                ...studentListState,
                dataLoading: false,
                studentListData: [],
                errorLoadingMessage: 'Произошла ошибка при загрузке данных', // обработать этот момент(подумать в какой момент я на серве кидаю ошибки)
            }
        default:
            return studentListState;
    }
}

//data example {name: 'firstName', value: 'Иван',}
export const fetchSetStudentsListFilter = data => ({
    type: FETCH_SET_STUDENTS_LIST_FILTER,
    payload: data,
})

export const fetchGetStudentListData = data => ({
    type: FETCH_GET_STUDENT_LIST_DATA,
    payload: data,
})

export const fetchGetStudentListDataSuccess = data => ({
    type: FETCH_GET_STUDENT_LIST_DATA_SUCCESS,
    payload: data,
})

export const fetchGetStudentListDataFailed = data => ({
    type: FETCH_GET_STUDENT_LIST_DATA_FAILED,
})