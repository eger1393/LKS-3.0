//@flow
import React from 'react'
import {
  BrowserRouter as Router,
  Route,
  Switch,
  Redirect,
} from 'react-router-dom'

import { PrivateRoute } from '../layouts/PrivateRoute'
import StudentList from './StudentList'
import LoginPage from './LoginPage'

import { Container } from './styled'

const Pages = () => {
  return (
    <Router>
      <Container>
        <Switch>
          <Redirect exact from="/" to="/studentList" />
          <Route path="/login" component={LoginPage} />
          <PrivateRoute path="/studentList" component={StudentList} />
        </Switch>
      </Container>
    </Router>
  )
}

export default Pages
