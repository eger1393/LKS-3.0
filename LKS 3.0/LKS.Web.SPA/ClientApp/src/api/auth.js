import axios from 'axios'
import { setAuthToken } from '../axiosExtensions'
import history from '../history'

const login_url = '/api/auth/login'
const getUser_url = '/api/auth/getUser'

export const apiLogin = fetch => {
  return axios.post(login_url, fetch.payload).then(data => {
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
