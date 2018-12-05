const module = 'AddStudent'

export const FETCH_ADD_NEW_STUDENT = `${module}/FETCH_ADD_NEW_STUDENT`
export const FETCH_ADD_STUDENT_SUCCESS = `${module}/FETCH_ADD_STUDENT_SUCCESS`
export const FETCH_ADD_STUDENT_FAILED = `${module}/FETCH_ADD_STUDENT_FAILED`


export const FETCH_SET_VALUE_FOR_STUDENT = `${module}/FETCH_SET_VALUE_FOR_STUDENT`

const defaultState = {
    fieldsValue: {},
    errorMessage: '',
}

export default function reducer(currentStudentState = defaultState, action = {}) {
    const { type, payload } = action;
    switch (type) {
        case FETCH_ADD_NEW_STUDENT:
            return {
                ...currentStudentState,
            }
        case FETCH_ADD_STUDENT_SUCCESS:
            return {
                ...currentStudentState,
            }
        case FETCH_ADD_STUDENT_FAILED:
            return {
                ...currentStudentState,
                info: {},
                errorMessage: 'Произошла ошибка!', // обработать этот момент(подумать в какой момент я на серве кидаю ошибки)
            }
        case FETCH_SET_VALUE_FOR_STUDENT:
            return {
                ...currentStudentState,
                fieldsValue: {
                    ...currentStudentState.fieldsValue,
                    [payload.name]: payload.val,
                }
            }
        default:
            return currentStudentState;
    }
}

export const fetchAddNewStudent = () => ({
    type: FETCH_ADD_NEW_STUDENT,
    //payload: data,
})

export const fetchAddStudentSuccess = data => ({
    type: FETCH_ADD_STUDENT_SUCCESS,
    payload: data,
})

export const fetchAddStudentFailed = data => ({
    type: FETCH_ADD_STUDENT_FAILED,
})


export const fetchSetValueForStudent = (data) => ({
    type: FETCH_SET_VALUE_FOR_STUDENT,
    payload: data,
})