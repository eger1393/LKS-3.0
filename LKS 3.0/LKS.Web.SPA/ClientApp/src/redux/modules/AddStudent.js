const module = 'addStudent'

export const FETCH_UPDATE_STUDENT = `${module}/FETCH_UPDATE_STUDENT`
export const FETCH_UPDATE_STUDENT_SUCCESS = `${module}/FETCH_UPDATE_STUDENT_SUCCESS`
export const FETCH_UPDATE_STUDENT_FAILED = `${module}/FETCH_UPDATE_STUDENT_FAILED`

export const FETCH_SET_VALUE_FOR_STUDENT = `${module}/FETCH_SET_VALUE_FOR_STUDENT`
export const FETCH_SET_STUDENT = `${module}/FETCH_SET_STUDENT`
export const FETCH_SET_STUDENT_SUCCESS = `${module}/FETCH_SET_STUDENT_SUCCESS`

export const FETCH_SET_RELATIVE = `${module}/FETCH_SET_RELATIVE`

export const FETCH_CLEAR_STUDENT = `${module}/FETCH_CLEAR_STUDENT`

export const FETCH_SET_ERRORS = `${module}/FETCH_SET_ERRORS`

export const FETCH_SET_STUDENT_PHOTO = `${module}/FETCH_SET_STUDENT_PHOTO`

const defaultState = {
    fieldsValue: {
        lastName: "Иванов",
        firstName: "Иван",
        middleName: "Иванович",
        position: 6,
        faculty: "3",
        kurs: "4",
        birthday: "01-01-2000",
        placeBirthday: "Москва",
        mobilePhone: "8(999)11-11-11",
        placeOfRegestration: "Москва",

    },
    relatives: [],
    errorValues: {
        infoTab: {
            lastName: false,
            firstName: false,
            middleName: false,
            troopId: false,
            position: false,
            faculty: false,
            kurs: false,
        },
        personalTab: {
            birthday: false,
            placeBirthday: false,
            mobilePhone: false,
            placeOfRegestration: false,
        },
    },
    errorMessage: '',
    loading: false,
    studentPhoto: undefined,
}

export default function reducer(currentStudentState = defaultState, action = {}) {
    const { type, payload } = action;
    switch (type) {
        case FETCH_UPDATE_STUDENT:
            return {
                ...currentStudentState,
            }
        case FETCH_SET_STUDENT_PHOTO:
            return {
                ...currentStudentState,
                studentPhoto: payload,
            }
        case FETCH_CLEAR_STUDENT:
        case FETCH_UPDATE_STUDENT_SUCCESS:
            return {
                ...currentStudentState,
                fieldsValue: {
                    lastName: "Иванов",
                    firstName: "Иван",
                    middleName: "Иванович",
                    position: 6,
                    faculty: "3",
                    kurs: "4",
                    birthday: "01-01-2000",
                    placeBirthday: "Москва",
                    mobilePhone: "8(999)11-11-11",
                    placeOfRegestration: "Москва",
                },
                relatives: [],
                errorValues: {
                    ...currentStudentState.errorValues,
                    infoTab: {
                        lastName: false,
                        firstName: false,
                        middleName: false,
                        troopId: false,
                        position: false,
                        faculty: false,
                        kurs: false,
                    },
                    personalTab: {
                        birthday: false,
                        placeBirthday: false,
                        mobilePhone: false,
                        placeOfRegestration: false,
                    },
                },
            }

        case FETCH_UPDATE_STUDENT_FAILED:
            return {
                ...currentStudentState,
                errorMessage: 'Произошла ошибка!', // обработать этот момент(подумать в какой момент я на серве кидаю ошибки)
            }

        case FETCH_SET_VALUE_FOR_STUDENT:
            {
                var errorsInfo, errorsPersonal;
                if (payload.tab == "infoTab") {
                    errorsInfo = currentStudentState.errorValues.infoTab;
                    errorsInfo[payload.name] = payload.error;
                    errorsPersonal = currentStudentState.errorValues.personalTab;
                }
                else if (payload.tab == "personalTab") {
                    errorsPersonal = currentStudentState.errorValues.personalTab;
                    errorsPersonal[payload.name] = payload.error;
                    errorsInfo = currentStudentState.errorValues.infoTab;
                }

                return {
                    ...currentStudentState,
                    fieldsValue: {
                        ...currentStudentState.fieldsValue,
                        [payload.name]: payload.val,
                    },
                    errorValues: {
                        ...currentStudentState.errorValues,
                        infoTab: errorsInfo,
                        personalTab: errorsPersonal,
                    }
                }

            }

        case FETCH_SET_RELATIVE:
            {
                //var relatives;
                //if (payload.index != undefined) {
                //  relatives = [...currentStudentState.fieldsValue.relatives];
                //  relatives[payload.index] = payload.values;
                //} else {
                var relatives = [...currentStudentState.relatives, payload.values]; //TODO BAD
                //}
                return {
                    ...currentStudentState,
                    relatives: relatives,

                }
            }
        case FETCH_SET_STUDENT:
            return {
                ...currentStudentState,
                loading: true,
            }
        case FETCH_SET_STUDENT_SUCCESS:
            var student = payload.student;
            delete student.relatives;
            var relatives = payload.relatives;
            return {
                ...currentStudentState,
                fieldsValue: {
                    ...student,
                },
                relatives: relatives,
                loading: false,
            }
        case FETCH_SET_ERRORS:
            return {
                ...currentStudentState,
                errorValues: {
                    ...currentStudentState.errorValues,
                    infoTab: {
                        lastName: !currentStudentState.fieldsValue.lastName,
                        firstName: !currentStudentState.fieldsValue.firstName,
                        middleName: !currentStudentState.fieldsValue.middleName,
                        troopId: !currentStudentState.fieldsValue.troopId,
                        kurs: !currentStudentState.fieldsValue.kurs,
                        faculty: !currentStudentState.fieldsValue.faculty,
                        position: !currentStudentState.fieldsValue.position,
                    },
                    personalTab: {
                        birthday: !currentStudentState.fieldsValue.birthday,
                        placeBirthday: !currentStudentState.fieldsValue.placeBirthday,
                        mobilePhone: !currentStudentState.fieldsValue.mobilePhone,
                        placeOfRegestration: !currentStudentState.fieldsValue.placeOfRegestration,
                    },
                }
            }
        default:
            return currentStudentState;
    }
}

export const fetchSetStudentPhoto = photo => ({
    type: FETCH_SET_STUDENT_PHOTO,
    payload: photo,
})


export const fetchSetValueForStudent = (data) => ({
    type: FETCH_SET_VALUE_FOR_STUDENT,
    payload: data,
})

// data { index, values }
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

export const fetchUpdateStudentFailed = () => ({
    type: FETCH_UPDATE_STUDENT_FAILED,
})

export const fetchSetErrors = (data) => ({
    type: FETCH_SET_ERRORS,
    payload: data,
})

export const fetchClearStudent = () => ({
    type: FETCH_CLEAR_STUDENT,
})