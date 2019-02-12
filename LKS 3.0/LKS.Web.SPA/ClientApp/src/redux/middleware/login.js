import { all, takeEvery, call, put } from 'redux-saga/effects'

import { apiLogin, apiLogout, apiGetUser } from '../../api/auth'
import {
  FETCH_LOGIN,
  FETCH_LOGOUT,
  fetchLoginFailed,
  fetchLoginSuccess,
  FETCH_GET_USER,
  fetchGetUserSuccess,
  fetchGetUserFailed,
} from '../modules/login'

function* login(user) {
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
    takeEvery(FETCH_GET_USER, function* () {
      try {
        const data = yield call(apiGetUser)
        yield put(fetchGetUserSuccess(data))
      } catch (error) {
        yield put(fetchGetUserFailed(error))
      }
    }),
  ])
}

export default login
