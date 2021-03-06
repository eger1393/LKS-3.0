﻿import { combineReducers } from 'redux'
import { routerReducer } from 'react-router-redux'
import studentList from './studentList'
import addStudent from './addStudent'

export default combineReducers({
  routing: routerReducer,
    studentList,
    addStudent,
})
