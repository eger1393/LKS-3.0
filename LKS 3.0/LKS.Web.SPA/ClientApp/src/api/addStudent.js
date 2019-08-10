import axios from 'axios'

const UPDATE_STUDENT_URL = '/api/addStudent/UpdateStudent'
const GET_STUDENT_URL = '/api/addStudent/GetStudent'
const GET_INSTGROUP_LIST_URL = '/api/addStudent/GetInstGroupList'
const GET_SPECINST_LIST_URL = '/api/addStudent/GetSpecInstList'
const GET_LANGUAGES_LIST_URL = '/api/addStudent/GetLanguagesList'
const GET_RECTAL_LIST_URL = '/api/addStudent/GetRectalList'

export const apiUpdateStudent = data =>
    axios.post(UPDATE_STUDENT_URL, data);

export const apiGetStudent = data =>
    axios.post(GET_STUDENT_URL, data).then(({ data }) => data);

export const apiGetInstGroupList = data =>
    axios.post(GET_INSTGROUP_LIST_URL, data).then(({ data }) => data);

export const apiGetSpecInstList = data =>
    axios.post(GET_SPECINST_LIST_URL, data).then(({ data }) => data);

export const apiGetRectalList = data =>
    axios.post(GET_RECTAL_LIST_URL, data).then(({ data }) => data);

export const apiGetLanguagesList = data =>
    axios.post(GET_LANGUAGES_LIST_URL, data).then(({ data }) => data);