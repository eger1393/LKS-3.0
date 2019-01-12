const module = 'AddStudent'

export const FETCH_ADD_NEW_STUDENT = `${module}/FETCH_ADD_NEW_STUDENT`
export const FETCH_ADD_STUDENT_SUCCESS = `${module}/FETCH_ADD_STUDENT_SUCCESS`
export const FETCH_ADD_STUDENT_FAILED = `${module}/FETCH_ADD_STUDENT_FAILED`

export const FETCH_UPDATE_STUDENT = `${module}/FETCH_UPDATE_STUDENT`
export const FETCH_UPDATE_STUDENT_SUCCESS = `${module}/FETCH_UPDATE_STUDENT_SUCCESS`

export const FETCH_SET_VALUE_FOR_STUDENT = `${module}/FETCH_SET_VALUE_FOR_STUDENT`
export const FETCH_SET_STUDENT = `${module}/FETCH_SET_STUDENT`
export const FETCH_SET_STUDENT_SUCCESS = `${module}/FETCH_SET_STUDENT_SUCCESS`

export const FETCH_SET_RELATIVE = `${module}/FETCH_SET_RELATIVE`

const defaultState = {
    fieldsValue: {
       
    },
    errorMessage: '',
    loading: false,
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
                fieldsValue: {
                   
                },
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
        case FETCH_SET_RELATIVE:
            return {
                ...currentStudentState,
                fieldsValue: {
                    ...currentStudentState.fieldsValue,
                    relatives: [
                        ...currentStudentState.fieldsValue.relatives,
                        { ...payload.value }
                    ]
                }
            }
        case FETCH_SET_STUDENT:
            return {
                ...currentStudentState,
                loading: true,
            }
        case FETCH_SET_STUDENT_SUCCESS:
            return {
                ...currentStudentState,
                fieldsValue: {
                    //...currentStudentState.fieldsValue,
                    ...payload,
                },
                loading: false,
            }
        case FETCH_UPDATE_STUDENT:
            return {
                ...currentStudentState,
            }
        case FETCH_UPDATE_STUDENT_SUCCESS:
            return {
                ...currentStudentState,
                fieldsValue: {
                    
                },
            }
        default:
            return currentStudentState;
    }
}

export const fetchAddNewStudent = () => ({
    type: FETCH_ADD_NEW_STUDENT,
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

// data { id, value }
export const fetchSetRelative = (data) => ({
    type: FETCH_SET_RELATIVE,
    payload: data,
})

//data { id }
export const fetchSetStudent = (data) => ({
    type: FETCH_SET_STUDENT,
    payload: data,
})

export const fetchSetStudentSuccess = (data) => ({
    type: FETCH_SET_STUDENT_SUCCESS,
    payload: data,
})

export const fetchUpdateStudent = () => ({
    type: FETCH_UPDATE_STUDENT,
})

export const fetchUpdateStudentSuccess = () => ({
    type: FETCH_UPDATE_STUDENT_SUCCESS,
})