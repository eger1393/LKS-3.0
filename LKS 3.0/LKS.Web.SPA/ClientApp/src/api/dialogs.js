import axios from 'axios'

const GET_CYCLE_LIST_URL = '/api/cycle/GetCycleList'
const GET_TROOP_LIST_URL = '/api/troop/GetTroopList'
const GET_PREPOD_LIST_URL = '/api/prepod/GetPrepodList'
const CREATE_TROOP_URL = '/api/troop/CreateTroop'


const GET_TROOP_STUDENTS_LIST_INITIAL = '/api/troop/GetTroopStudentsListInitial'

// return [{id: '12w', number: '4'},]
export const apiGetCycleList = data =>
    axios.post(GET_CYCLE_LIST_URL, data).then(({ data }) => data);

// return [{id:'1123', numberTroop: '410'},]
export const apiGetTroopList = data =>
    axios.post(GET_TROOP_LIST_URL, data).then(({ data }) => data);

//return [{id: '12eq', initials: 'Иванов И. И.'},]
export const apiGetPrepodList = data =>
    axios.post(GET_PREPOD_LIST_URL, data).then(({ data }) => data);

//return [{id: '123', initials: 'Сидоров В. С.'},]
export const apiGetTroopStudentsListInitial = data =>
    axios.get(GET_TROOP_STUDENTS_LIST_INITIAL, { params: { troopId: data } });

export const apiCreateTroop = data =>
    axios.post(CREATE_TROOP_URL, data);

