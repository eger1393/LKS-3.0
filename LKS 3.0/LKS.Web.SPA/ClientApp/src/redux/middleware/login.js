import { all, takeEvery, call, put } from 'redux-saga/effects'

import { apiLogin, apiLogout } from '../../api/user'
import {
  FETCH_LOGIN,
  FETCH_LOGOUT,
  fetchLoginFailed,
  fetchLoginSuccess
} from '../modules/login'

function* login() {
  yield all([
    takeEvery(FETCH_LOGIN, function*(user) {
      try {
        const data = yield call(apiLogin, user)
        yield put(fetchLoginSuccess(data))
      } catch (error) {
        yield put(fetchLoginFailed(error))
      }
    }),
    takeEvery(FETCH_LOGOUT, function*() {
      try {
        yield call(apiLogout)
      } catch (error) {}
    }),
  ])
}

export default login
