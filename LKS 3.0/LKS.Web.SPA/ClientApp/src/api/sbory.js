import axios from 'axios'

const GET_ADMIN_LIST_URL = '/api/admin/GetAdminList'
const SET_ADMIN_LIST_URL = '/api/admin/SetAdminList'
const GET_SBORY_INFO_URL = '/api/summerSbory/GetSummerSboryInfo'
const SET_SBORY_INFO_URL = '/api/summerSbory/SetSummerSboryInfo'
const GET_STUDENT_ASSESSMENTS_URL = '/api/studentList/GetStudenAssessments'
const SAVE_ASSESSMENTS_URL = '/api/studentList/SaveAssessments'

export const apiGetAdminList = () =>
    axios.get(GET_ADMIN_LIST_URL).then(({ data }) => data);

export const apiSetAdminList = (data) =>
    axios.post(SET_ADMIN_LIST_URL, data);

export const apiGetSummerSboryInfo = () =>
    axios.get(GET_SBORY_INFO_URL).then(({ data }) => data);

export const apiSetSummerSboryInfo = (data) =>
    axios.post(SET_SBORY_INFO_URL, data);

export const apiGetStudentAssessments = troopId =>
    axios.get(GET_STUDENT_ASSESSMENTS_URL, { params: { troopId } })

export const apiSaveAssessments = studentList =>
    axios.post(SAVE_ASSESSMENTS_URL, studentList);
