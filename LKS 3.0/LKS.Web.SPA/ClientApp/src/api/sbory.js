import axios from 'axios'

const GET_ADMIN_LIST_URL = '/api/admin/GetAdminList'
const SET_ADMIN_LIST_URL = '/api/admin/SetAdminList'
const GET_SBORY_INFO_URL = '/api/summerSbory/GetSummerSboryInfo'
const SET_SBORY_INFO_URL = '/api/summerSbory/SetSummerSboryInfo'

export const apiGetAdminList = () =>
    axios.get(GET_ADMIN_LIST_URL).then(({ data }) => data);

export const apiSetAdminList = (data) =>
    axios.post(SET_ADMIN_LIST_URL, data);

export const apiGetSummerSboryInfo = () =>
    axios.get(GET_SBORY_INFO_URL).then(({ data }) => data);

export const apiSetSummerSboryInfo = (data) =>
    axios.post(SET_SBORY_INFO_URL, data);
