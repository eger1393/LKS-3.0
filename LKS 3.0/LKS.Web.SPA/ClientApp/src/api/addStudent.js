import axios from 'axios'

const CREATE_STUDENT_URL = '/api/addStudent/CreateStudent'
const GET_INSTGROUP_LIST_URL = '/api/addStudent/GetInstGroupList'
const GET_SPECINST_LIST_URL = '/api/addStudent/GetSpecInstList'
const GET_RECTAL_LIST_URL = '/api/addStudent/GetRectalList'

export const apiCreateStudent = data =>
    axios.post(CREATE_STUDENT_URL, data);

export const apiGetInstGroupList = data =>
    axios.post(GET_INSTGROUP_LIST_URL, data).then(({ data }) => data);

export const apiGetSpecInstList = data =>
    axios.post(GET_SPECINST_LIST_URL, data).then(({ data }) => data);

export const apiGetRectalList = data =>
    axios.post(GET_RECTAL_LIST_URL, data).then(({ data }) => data);