//@flow
import React from 'react'
import { Form, Field } from 'react-final-form'
import { connect } from 'react-redux'

import { Redirect } from 'react-router-dom'
//import AuthError from '../Common/AuthError'
import Input from '../../../_common/elements/Input'
import Button from '../../../_common/elements/Button'

import {
  LoginFormContainer,
  InputContainer,
  ButtonContainer,
  Container,
} from './styled'
import { PageTitleBlock } from '../styled'
import { fetchLogin } from '../../../../redux/modules/login'
import { getErrors, getSuccessLogin } from '../../../../selectors/login'

const StyledInputFieldAdapter = ({ input, meta, maxlength, ...rest }) => (
  <Input {...input} {...rest} onChange={value => input.onChange(value)} />
)

class Login extends React.Component {
  state = {
    isError: false,
    login: '',
    password: '',
  }


  onSubmit = () => {
    const { password, login } = this.state
    //TODO
    this.props.fetchLogin({
      Login: login,
      Password: password,
    })

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
    const { errorMessage, isSuccess } = this.props

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
          <ButtonContainer>
            <Button type="button" value="Войти" onClick={this.onSubmit} />
          </ButtonContainer>
        </LoginFormContainer>
      </Container>
    )
  }
}

const mapStateToProps = state => ({
  errorMessage: getErrors(state),
  isSuccess: getSuccessLogin(state),
})

export default connect(
  mapStateToProps,
  { fetchLogin }
)(Login)
