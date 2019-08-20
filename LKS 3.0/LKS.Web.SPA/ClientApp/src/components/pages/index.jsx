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
import UserCabinet from './UserCabinet'
import LoginPage from './LoginPage'

import { Container } from './styled'
import AdminList from '../_common/dialogs/InfoSbori/AdminList';

const Pages = () => {
  const isAdmin = localStorage.getItem('role') === 'Admin'

// return (<AdminCabinet />)

  return (
    <Router>
      <Container>
        <Switch>
          <Redirect exact from="/" to="/Cabinet" />
          <Route path="/login" component={LoginPage} />
                  <PrivateRoute path="/Cabinet" component={isAdmin ? AdminCabinet : UserCabinet} />
          <Route path="/test" component={AdminList}/>
        </Switch>
      </Container>
    </Router>
  )
}

export default Pages
