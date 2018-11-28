import axios from 'axios'

const GET_CYCLE_LIST_URL = '/api/cycle/GetCycleList'
const GET_TROOP_NUMBER_LIST_URL = '/api/troop/GetTroopNumberList'
const GET_TROOP_LIST_URL = '/api/troop/GetTroopList'
const GET_TROOP_FROM_ID_URL = '/api/troop/GetTroop'
const GET_PREPOD_LIST_URL = '/api/prepod/GetPrepodList'
const CREATE_TROOP_URL = '/api/troop/CreateTroop'
const UPADATE_TROOP_URL = '/api/troop/UpdateTroop'
const CREATE_STUDENT_URL = '/api/studentList/CreateStudent'
const GET_INSTGROUP_LIST_URL = '/api/studentList/GetInstGroupList'

const GET_TROOP_STUDENTS_LIST_INITIAL = '/api/troop/GetTroopStudentsListInitial'

// return troop data
export const apiGetTroopFromId = (data) =>
    axios.get(GET_TROOP_FROM_ID_URL, { params: { id: data.id, } }).then(({ data }) => data);

// return [{id: '12w', number: '4'},]
export const apiGetCycleList = () =>
    axios.post(GET_CYCLE_LIST_URL).then(({ data }) => data);

// return [{id:'1123', numberTroop: '410'},]
export const apiGetTroopNumberList = () =>
    axios.post(GET_TROOP_NUMBER_LIST_URL).then(({ data }) => data);

//return [{id: '12eq', initials: 'Иванов И. И.'},]
export const apiGetPrepodList = () =>
    axios.post(GET_PREPOD_LIST_URL).then(({ data }) => data);

//return [{id: '123', initials: 'Сидоров В. С.'},]
export const apiGetTroopStudentsListInitial = data =>
    axios.get(GET_TROOP_STUDENTS_LIST_INITIAL, { params: { troopId: data } });

export const apiCreateTroop = data =>
    axios.post(CREATE_TROOP_URL, data);

export const apiUpdateTroop = data =>
    axios.post(UPADATE_TROOP_URL, data);


export const apiCreateStudent = data =>
    axios.post(CREATE_STUDENT_URL, data);

export const apiGetInstGroupList = data =>
    axios.post(GET_INSTGROUP_LIST_URL, data).then(({ data }) => data);

// return Troop model
export const apiGetTroopList = () =>
    axios.post(GET_TROOP_LIST_URL).then(({ data }) => data);