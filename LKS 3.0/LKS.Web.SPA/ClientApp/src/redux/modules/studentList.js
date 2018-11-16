const module = 'studentList'

export const FECTH_SET_STUDENTS_LIST_FILTER = `${module}/FETCH_SET_FILTER`

const defaultState = {
    filtersValue: {},
}

export default function reducer(studentListState = defaultState, action = {}) {
    const { type, payload } = action;
    switch (type) {
        case FECTH_SET_STUDENTS_LIST_FILTER:
            return {
                ...studentListState, 
                filtersValue: {
                    ...studentListState.filtersValue,
                    [payload.fieldName]: payload.value,
                }
            }
        default:
            return studentListState;
    }
}

//data example {name: 'firstName', value: 'Иван',}
export const fetchSetStudentsListFilter = data => ({
    type: FECTH_SET_STUDENTS_LIST_FILTER,
    payload: data,
})