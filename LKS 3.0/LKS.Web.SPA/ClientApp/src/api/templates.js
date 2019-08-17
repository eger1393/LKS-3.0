import axios from 'axios'
import fileDownload from 'js-file-download'

const CREATE_TELMPLATE_URL = '/api/template/CreateTemplate'
const SET_TELMPLATE_DATA_URL = '/api/template/SetTemlateData'
const UPDATE_TEMPLATE_URL = '/api/template/UpdateTemplate'
const GET_CATEGORIES_URL = '/api/template/GetCategories'
const GET_TYPES_URL = '/api/template/GetTypes'
const GET_TEMPLATE_LIST_URL = '/api/template/GetTemplateList'

export const apiSetTemplateData = data => axios.post(SET_TELMPLATE_DATA_URL, { json: JSON.stringify(data) });
export const apiCreateTemplate = data =>
  axios.get(CREATE_TELMPLATE_URL, {
    responseType: 'arraybuffer',
  }).then(res => {
    var blob = new Blob([res.data], { type: res.headers["content-type"] });
    var fileName = res.headers['content-disposition'].split("''")[1];
    
    fileDownload(blob, decodeURIComponent(fileName));
  });

export const apiCreateLKSTemplate = data => { }

export const apiUpdateTemplate = data => {
  let form = new FormData();
  Object.keys(data).map(key => {
    form.append(`${key}`, data[key])
  });
  return axios.post(UPDATE_TEMPLATE_URL, form);
}


export const apiGetCategories = (parentId) =>
  axios.get(GET_CATEGORIES_URL, { params: { parentId } }).then(({ data }) => data);

export const apiGetTypes = () =>
  axios.get(GET_TYPES_URL).then(({ data }) => data);

export const apiGetTemplateList = (subCategoryId) =>
  axios.get(GET_TEMPLATE_LIST_URL, {params: {subCategoryId}}).then(({ data }) => data);



