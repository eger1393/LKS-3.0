// @flow
import * as _ from 'lodash'

export const getAddStudentFieldsValue = state => _.get(state, ['addStudent', 'fieldsValue']);
export const getAddStudentRelatives = state => _.get(state, ['addStudent', 'fieldsValue', 'relatives']);
export const getIsLoading = state => _.get(state, ['loading']);
