// @flow
import * as _ from 'lodash'

export const getAddStudentFieldsValue = state => _.get(state, ['addStudent', 'fieldsValue']);
export const getAddStudentErrorValues = state => _.get(state, ['addStudent', 'errorValues']);
export const getAddStudentRelatives = state => _.get(state, ['addStudent', 'fieldsValue', 'relatives']);
export const getIsLoading = state => _.get(state, ['loading']);
export const getStudentRelative = (state, index) => _.get(state, `addStudent.fieldsValue.relatives[${index}]`)
export const getStudentId = (state) => _.get(state, 'addStudent.fieldsValue[id]')
export const getStudentPhoto = state => _.get(state, 'addStudent.getStudentPhoto')
