// @flow
import * as _ from 'lodash'

export const getErrors = state => _.get(state, ['login', 'errorMessage'])
export const getSuccessLogin = state => _.get(state, ['login','isSuccess'])
