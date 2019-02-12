//@flow
import React from 'react'
import { connect } from 'react-redux'
import {
  BrowserRouter as Router,
  Route,
  Switch,
  Redirect,
} from 'react-router-dom'

import { fetchGetUser } from '../../redux/modules/login'
import { PrivateRoute } from '../layouts/PrivateRoute'
import StudentList from './StudentList'
import LoginPage from './LoginPage'

import { Container } from './styled'

class Pages extends React.Component {

  componentDidMount() {
    this.props.fetchGetUser();
  }

  render() {
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
}

export default connect(null, { fetchGetUser })(Pages)
