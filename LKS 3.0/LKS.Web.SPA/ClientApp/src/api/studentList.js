import axios from 'axios'

const GET_STUDENT_LIST_DATA_URL = '/api/studentList/GetStudentListData'

export const apiGetStudentListData = fetch =>
    axios.post(GET_STUDENT_LIST_DATA_URL, fetch).then(({ data }) =>data);

