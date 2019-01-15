import React, { useState, useEffect } from 'react'
import { Redirect } from 'react-router-dom'

import Login from './Login'
//import Logo from '../../_common/Logo'

import leftColumnImage from '../../../images/STORY_restaurant.jpg'
import { Container, FirstColumn, SecondColumn } from './styled'

const LoginPage = () => {
  const [redirect, setRedirect] = useState(false)

  useEffect(() => {
    if (localStorage.getItem('LKS-jwt-client')) {
      setRedirect(true)
    }
  }, [])

  if (redirect) {
    return <Redirect to="/" />
  }

  return (
    <Container>
      <FirstColumn>
        {/* <Logo /> */}
        <Login />
      </FirstColumn>
      <SecondColumn image={`url(${leftColumnImage})`} />
    </Container>
  )
}

export default LoginPage
