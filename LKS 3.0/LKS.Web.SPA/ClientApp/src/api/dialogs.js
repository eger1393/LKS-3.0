import axios from 'axios'

const GET_CYCLE_LIST_URL = '/api/cycle/GetCycleList'
const GET_TROOP_LIST_URL = '/api/troop/GetTroopList'
const GET_PREPOD_LIST_URL = '/api/prepod/GetPrepodList'
const CREATE_TROOP_URL = '/api/troop/CreateTroop'


export const apiGetCycleList = data =>
    axios.post(GET_CYCLE_LIST_URL, data).then(({ data }) => data);

export const apiGetTroopList = data =>
    axios.post(GET_TROOP_LIST_URL, data).then(({ data }) => data);

export const apiGetPrepodList = data =>
    axios.post(GET_PREPOD_LIST_URL, data).then(({ data }) => data);

export const apiCreateTroop = data =>
    axios.post(CREATE_TROOP_URL, data);

