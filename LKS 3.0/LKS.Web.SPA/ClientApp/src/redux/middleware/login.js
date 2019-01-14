import { all, takeEvery, call, put } from 'redux-saga/effects'

import { apiLogin, apiLogout } from '../../api/auth'
import {
  FETCH_LOGIN,
  FETCH_LOGOUT,
  fetchLoginFailed,
  fetchLoginSuccess,
} from '../modules/login'

function* login(user) {
  yield all([
    takeEvery(FETCH_LOGIN, function*(user) {
      try {
        yield call(apiLogin, user)
        yield put(fetchLoginSuccess())
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
