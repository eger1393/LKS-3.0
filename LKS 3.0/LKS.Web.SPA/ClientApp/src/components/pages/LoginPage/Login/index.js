//@flow
import React from 'react'

import { Redirect } from 'react-router-dom'
import Input from '../../../_common/elements/Input'
import Button from '../../../_common/elements/Button'

import { apiLogin } from '../../../../api/user'

import {
  LoginFormContainer,
  InputContainer,
  ButtonContainer,
  Container,
} from './styled'
import { PageTitleBlock } from '../styled'



class Login extends React.Component {
  state = {
    errorAuth: false,
    login: '',
    password: '',
    isSuccess: false
  }


  onSubmit = () => {
    var self = this
    const { password, login } = this.state
    apiLogin({ password, login })
      .then(res => self.setState({ isSuccess: true }))
      .catch(err => self.setState({ errorAuth: true }))

    return false;
  }

  onChange = event => {
    var name = event.target.name ? event.target.name : event.target.id,
      val = event.target.value;
    this.setState(prevState => ({
      ...prevState,
      [name]: val,
    }));
  }
  render() {
    const { errorAuth, isSuccess } = this.state

    if (isSuccess) {
      return (<Redirect to="/Cabinet" />)
    }
    return (
      <Container>
        <PageTitleBlock>Система управления циклом</PageTitleBlock>
        <LoginFormContainer>
          <InputContainer>
            <Input
              required={true}
              id="login"
              placeholder="Ваш логин"
              label="Ваш логин"
              type="text"
              value={this.state.login}
              onChange={this.onChange}
            />
          </InputContainer>
          <InputContainer>
            <Input
              required={true}
              id="password"
              placeholder="Ваш пароль"
              label="Ваш пароль"
              type="password"
              value={this.state.password}
              onChange={this.onChange}
            />
          </InputContainer>
          { errorAuth && (<div className="auth-errors">
              <div>Введён неверный логин или пароль</div>
            </div>)}
          <ButtonContainer>
            <Button type="button" value="Войти" onClick={this.onSubmit} />
          </ButtonContainer>
        </LoginFormContainer>
      </Container>
    )
  }
}
export default Login
