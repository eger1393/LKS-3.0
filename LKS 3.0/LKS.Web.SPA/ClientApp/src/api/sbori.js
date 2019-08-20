import axios from 'axios'

const GET_ADMIN_LIST_URL = '/api/admin/GetAdminList'
const SET_ADMIN_LIST_URL = '/api/admin/SetAdminList'

export const apiGetAdminList = () =>
    axios.get(GET_ADMIN_LIST_URL).then(({ data }) => data);

export const apiSetAdminList = (data) =>
    axios.post(SET_ADMIN_LIST_URL, data).then(({ data }) => data);