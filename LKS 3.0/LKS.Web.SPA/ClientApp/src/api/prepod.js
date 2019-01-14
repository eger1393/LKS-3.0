import axios from 'axios'

const GET_PREPOD_LIST_URL = '/api/prepod/GetPrepodList'
const CREATE_PREPOD_URL = '/api/prepod/CreatePrepod'
const UPADATE_PREPOD_URL = '/api/prepod/UpdatePrepod'
const DELETE_PREPOD_URL = '/api/prepod/DeletePrepod'
const GET_PREPOD_FROM_ID_URL = '/api/prepod/GetPrepod'

export const apiGetPrepodList = () =>
    axios.post(GET_PREPOD_LIST_URL).then(({ data }) => data);

export const apiCreatePrepod = data =>
  axios.post(CREATE_PREPOD_URL, data);

export const apiUpdatePrepod = data =>
  axios.post(UPADATE_PREPOD_URL, data);

export const apiDeletePrepod = data =>
  axios.delete(DELETE_PREPOD_URL, { data: data });

export const apiGetPrepodFromId = (data) =>
  axios.get(GET_PREPOD_FROM_ID_URL, { params: { id: data.id, } }).then(({ data }) => data);
