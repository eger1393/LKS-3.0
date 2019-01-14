import { combineReducers } from 'redux'
import { routerReducer } from 'react-router-redux'
import studentList from './studentList'
import login from './login'

export default combineReducers({
  routing: routerReducer,
  studentList,
  login,
})
