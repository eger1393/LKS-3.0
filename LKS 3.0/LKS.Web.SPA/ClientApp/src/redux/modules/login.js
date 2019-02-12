const module = 'login'

export const FETCH_LOGIN = `${module}/FETCH_LOGIN`
export const FETCH_LOGIN_FAILED = `${module}/FETCH_LOGIN_FAILED`
export const FETCH_LOGIN_SUCCESS = `${module}/FETCH_LOGIN_SUCCESS`
export const FETCH_LOGOUT = `${module}/FETCH_LOGOUT`
export const FETCH_GET_USER = `${module}/FETCH_GET_USER`
export const FETCH_GET_USER_SUCCESS = `${module}/FETCH_GET_USER_SUCCESS`
export const FETCH_GET_USER_FAILED = `${module}/FETCH_GET_USER_FAILED`

const defaultState = {
  errorMessage: '',
  isChangePassword: false,
  isSuccess: false,
  role: ''
}

export default function reducer(loginState = defaultState, action = {}) {
  const { type, payload } = action
  switch (type) {
    case FETCH_GET_USER:
      return { ...loginState }
    case FETCH_GET_USER_FAILED:
      return {
        ...loginState,
        isSuccess: false,
      }
    case FETCH_GET_USER_SUCCESS:
      return {
        ...loginState,
        errorMessage: '',
        isSuccess: true,
        role: payload.role,
      }
    case FETCH_LOGIN:
      return { ...loginState }
    case FETCH_LOGIN_FAILED:
      return {
        ...loginState,
        errorMessage: 'Введён неверный номер телефона или пароль',
      }
    case FETCH_LOGIN_SUCCESS:
      return {
        ...loginState,
        errorMessage: '',
        isSuccess: true,
        role: payload.role,
      }
    case FETCH_LOGOUT:
      return {
        ...loginState,
        errorMessage: '',
        isSuccess: false,
        role: '',
      }
    default:
      return loginState
  }
}

export const fetchLogin = user => ({
  type: FETCH_LOGIN,
  payload: user,
})

export const fetchLoginFailed = error => ({
  type: FETCH_LOGIN_FAILED,
  payload: error,
})

export const fetchLoginSuccess = data => ({
  type: FETCH_LOGIN_SUCCESS,
  payload: data,
})

export const fetchGetUser = () => ({
  type: FETCH_GET_USER,
})

export const fetchGetUserFailed = error => ({
  type: FETCH_GET_USER_FAILED,
  payload: error,
})

export const fetchGetUserSuccess = data => ({
  type: FETCH_GET_USER_SUCCESS,
  payload: data,
})

export const fetchLogout = () => ({
  type: FETCH_LOGOUT,
})
