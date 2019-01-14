import { all, fork } from 'redux-saga/effects'

import studentList from './studentList'
import login from './login'

export default function rootMiddleware() {
    return function* () {
      yield all([fork(studentList), fork(login)])
    }
}
