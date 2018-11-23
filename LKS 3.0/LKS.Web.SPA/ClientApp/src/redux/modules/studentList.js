const module = 'studentList'

export const FETCH_SET_STUDENT_LIST_FILTERS_VALUE = `${module}/FETCH_SET_STUDENT_LIST_FILTERS_VALUE`
export const FETCH_RESET_STUDENT_LIST_FILTERS_VALUE = `${module}/FETCH_RESET_STUDENT_LIST_FILTERS_VALUE`
export const FETCH_SET_STUDENT_LIST_FILTERS_SELECT_TROOP = `${module}/FETCH_SET_STUDENT_LIST_FILTERS_SELECT_TROOP`

export const FETCH_GET_STUDENT_LIST_DATA = `${module}/FETCH_GET_STUDENT_LIST_DATA`
export const FETCH_GET_STUDENT_LIST_DATA_SUCCESS = `${module}/FETCH_GET_STUDENT_LIST_DATA_SUCCESS`
export const FETCH_GET_STUDENT_LIST_DATA_FAILED = `${module}/FETCH_GET_STUDENT_LIST_DATA_FAILED`

export const FETCH_SET_STUDENT_LIST_FIELDS = `${module}/FETCH_SET_STUDENT_LIST_FIELDS`

const defaultState = {
    studentListFilters: {
        filters: {},
        selectTroop: '',
    },
    studentListFields: [],
    studentListData: [],
    dataLoading: false,
    errorLoadingMessage: '',
}

export default function reducer(studentListState = defaultState, action = {}) {
    const { type, payload } = action;
    switch (type) {
        case FETCH_SET_STUDENT_LIST_FILTERS_VALUE:
            return {
                ...studentListState, 
                studentListFilters: {
                    ...studentListState.studentListFilters,
                    filters: {
                        ...studentListState.studentListFilters.filters,
                        [payload.fieldName]: payload.value,
                    }
                }
            }

        case FETCH_RESET_STUDENT_LIST_FILTERS_VALUE:
            return {
                ...studentListState,
                studentListFilters: {
                    ...studentListState.studentListFilters,
                    filters: {},
                }
            }

        case FETCH_SET_STUDENT_LIST_FILTERS_SELECT_TROOP:
            return {
                ...studentListState,
                studentListFilters: {
                    ...studentListState.studentListFilters,
                    selectTroop: payload,
                }
            }
        case FETCH_SET_STUDENT_LIST_FIELDS:
            return {
                ...studentListState,
                studentListFields: [...payload],
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

//data example {fieldName: 'firstName', value: 'Иван',}
export const fetchSetStudentListFiltersValue = data => ({
    type: FETCH_SET_STUDENT_LIST_FILTERS_VALUE,
    payload: data,
})

export const fetchResetStudentListFiltersValue = () => ({
    type: FETCH_RESET_STUDENT_LIST_FILTERS_VALUE,
})

export const fetchSetStudentListFiltersSelectTroop = troopId => ({
    type: FETCH_SET_STUDENT_LIST_FILTERS_SELECT_TROOP,
    payload: troopId, // ид взвода
})

export const fetchSetStudentListFields = data => ({
    type: FETCH_SET_STUDENT_LIST_FIELDS,
    payload: data,
})

export const fetchGetStudentListData = data => ({
    type: FETCH_GET_STUDENT_LIST_DATA,
})

export const fetchGetStudentListDataSuccess = data => ({
    type: FETCH_GET_STUDENT_LIST_DATA_SUCCESS,
    payload: data,
})

export const fetchGetStudentListDataFailed = data => ({
    type: FETCH_GET_STUDENT_LIST_DATA_FAILED,
})