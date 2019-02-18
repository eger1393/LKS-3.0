import axios from 'axios'
import { setAuthToken } from '../axiosExtensions'
import history from '../history'

const login_url = '/api/user/login'
const getAllUsers_url = '/api/user/getAllUsers'
const updatePassword_url = '/api/user/updatePassword'

//fetch.payload

export const apiLogin = data => {
  return axios.post(login_url, data).then(data => {
    const { token, role } = data.data
    localStorage.setItem('LKS-jwt-client', token)
    localStorage.setItem('role', role);
    setAuthToken(token)
    history.push('/')
    return data.data
  })
}

export const apiLogout = () => {
  localStorage.removeItem('LKS-jwt-client')
  localStorage.removeItem('role')
  setAuthToken(false)
  history.go(0)
}

export const apiGetAllUsers = () => {
  return axios.get(getAllUsers_url).then(data => (data.data))
}

export const apiUpdatePassword = login => {
  return axios.get(updatePassword_url, {
    params: { login: login }
  }).then(data => (data.data))
}
