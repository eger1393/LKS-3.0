import styled from 'styled-components'

export const Container = styled.div``

export const LoginFormContainer = styled.div`
  margin-top: 40px;
`
export const LoginForm = styled.form``

export const FieldsGroup = styled.div`
  margin-top: 35px;
`

export const InputField = styled.input`
  width: 260px;
  height: 30px;
  border: none;
  border-bottom: 1px solid #d8d8d8;
  font-size: 16px;
  font-weight: 300;
  ::placeholder {
    color: #aaa;
    font-family: PFEncoreSansPro-Light;
  }
`
export const ButtonContainer = styled.div`
  margin-top: 25px;
`

export const InputContainer = styled.div`
  width: 260px;
  position: relative;
  margin: 0;
  display: flex;
`

export const InputFieldLabel = styled.label`
  font-size: 16px;
  font-weight: 300;
  color: #aaaaaa;
  position: absolute;
  cursor: text;
  transform: translateY(-10px);
  transition: transform 0.3s ease;
  left: 0;
  bottom: 0px;
`

export const AnimatedInputContainerLabel = styled(InputFieldLabel)`
  transform: translateY(-35px);
  height: 12px;
  font-size: 12px;
  font-weight: 300;
  color: #aaaaaa;
`

export const FogotPasswordBlock = styled.div`
  width: 260px;
  font-size: 14px;
  font-weight: 300;
  color: #aaaaaa;
  display: flex;
  justify-content: flex-end;

  a:visited,
  a:link {
    color: #aaaaaa;
  }
`

export const ForgotPasswordContainer = styled.div`
  color: #aaaaaa;
  :hover {
    color: #757575;
  }
`

export const PrivacyPolicyBlock = styled.div`
  display: flex;
  margin-top: 30px;
`

export const PolicyText = styled.div`
  color: #1b1e2d;
  font-family: PFEncoreSansPro-Book;
  font-size: 14px;
  padding-top: 2px;
`
