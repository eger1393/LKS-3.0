// @flow
import * as _ from 'lodash'

export const getStudentListFilters = state => _.get(state, ['studentList', 'filtersValue']);
export const getStudentListData = state => _.get(state, ['studentList', 'studentListData']);
