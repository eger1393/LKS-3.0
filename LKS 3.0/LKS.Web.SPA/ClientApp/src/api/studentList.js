import axios from 'axios'

const GET_STUDENT_LIST_DATA_URL = '/api/studentList/GetStudentListData'
const SET_STUDENT_STATUS_URL = '/api/studentList/SetStudentStatus'
const SET_STUDENT_POSITION_URL = '/api/studentList/SetStudentPosition'

export const apiGetStudentListData = fetch =>
    axios.post(GET_STUDENT_LIST_DATA_URL, fetch).then(({ data }) => data);

export const apiSetStudentStatus = fetch =>
    axios.post(SET_STUDENT_STATUS_URL, { id: fetch.id, status: fetch.status });

export const apiSetStudentPosition = fetch =>
    axios.post(SET_STUDENT_POSITION_URL, { id: fetch.id, position: fetch.position });

