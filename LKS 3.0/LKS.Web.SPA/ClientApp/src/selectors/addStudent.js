// @flow
import * as _ from 'lodash'

export const getAddStudentFieldsValue = state => _.get(state, ['addStudent', 'fieldsValue']);

