// @flow
import * as _ from 'lodash'

export const getStudentListFields = state => _.get(state, ['studentList', 'studentListFields']);
export const getStudentListData = state => _.get(state, ['studentList', 'studentListData']);
export const getStudentFilters = state => _.get(state, ['studentList', 'filtersValue']);
