import { all, fork } from 'redux-saga/effects'

import studentList from './studentList'
import addStudent from './addStudent'

export default function rootMiddleware() {
    return function* () {
        yield all([fork(studentList), fork(addStudent)])
    }
}
