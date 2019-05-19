//@flow
import React from 'react'
import {
  BrowserRouter as Router,
  Route,
  Switch,
  Redirect,
} from 'react-router-dom'

import { PrivateRoute } from '../layouts/PrivateRoute'
import AdminCabinet from './AdminCabinet'
import MainAdminCabinet from './MainAdminCabinet'
import UserCabinet from './UserCabinet'
import LoginPage from './LoginPage'

import { Container } from './styled'

const Pages = () => {
    const isAdmin = localStorage.getItem('role') === 'Admin'
    const isMainAdmin = localStorage.getItem('role') === 'MainAdmin'
  return (
    <Router>
      <Container>
        <Switch>
          <Redirect exact from="/" to="/Cabinet" />
          <Route path="/login" component={LoginPage} />
                  <PrivateRoute path="/Cabinet" component={isAdmin ? AdminCabinet : isMainAdmin ? MainAdminCabinet : UserCabinet} />
        </Switch>
      </Container>
    </Router>
  )
}

export default Pages
