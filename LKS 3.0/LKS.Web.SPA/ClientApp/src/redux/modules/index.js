import { combineReducers } from 'redux'
import { routerReducer } from 'react-router-redux'
import studentList from './studentList'
import addStudent from './AddStudent'

export default combineReducers({
  routing: routerReducer,
    studentList,
    addStudent,
})
