// @flow
import * as _ from 'lodash'

export const getStudentListFilters = state => _.get(state, ['stydentList', 'filtersValue'])
