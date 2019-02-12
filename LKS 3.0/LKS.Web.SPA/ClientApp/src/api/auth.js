import axios from 'axios'
import { setAuthToken } from '../axiosExtensions'
import history from '../history'

const login_url = '/api/auth/login'
const getUser_url = '/api/auth/getUser'

export const apiLogin = fetch => {
  return axios.post(login_url, fetch.payload).then(data => {
    const { token } = data.data
    localStorage.setItem('LKS-jwt-client', token)
    setAuthToken(token)
    history.push('/')
    return data.data
  })
}

export const apiLogout = () => {
  localStorage.removeItem('LKS-jwt-client')
  setAuthToken(false)
  history.go(0)
}

export const apiGetUser = () => {
  return axios.get(getUser_url).then(data => ( data.data ));
}
