import axios from 'axios'
import fileDownload from 'js-file-download'

const CREATE_TELMPLATE_URL = '/api/template/CreateUniversityTemplate'
const CREATE_TELMPLATE_LKS_URL = '/api/template/CreateUniversityLKSTemplate'
const UPDATE_TEMPLATE_URL = '/api/template/UpdateTemplate'
const GET_CATEGORIES_URL = '/api/template/GetCategories'
const GET_TYPES_URL = '/api/template/GetTypes'

export const apiCreateTemplate = data =>
  axios.get(CREATE_TELMPLATE_URL, {
    responseType: 'arraybuffer',
    params: { troopId: data.numberTroop, template: data.selectedTemplate, order: data.order }
  }).then(res => {
    var blob = new Blob([res.data], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' });
    var fileName = res.headers['content-disposition'].split("''")[1];
    fileDownload(blob, decodeURIComponent(fileName));
  });

export const apiCreateLKSTemplate = data =>
  axios.get(CREATE_TELMPLATE_LKS_URL, {
    responseType: 'arraybuffer',
    params: { troopId: data.numberTroop, template: data.selectedTemplate, order: data.order, studentId: data.studentId }
  }).then(res => {
    var blob = new Blob([res.data], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' });
    var fileName = res.headers['content-disposition'].split("''")[1];
    fileDownload(blob, decodeURIComponent(fileName));
  });

  export const apiUpdateTemplate = data =>
  {
    let form = new FormData();
              Object.keys(data).map(key => {
                  form.append(`${key}`, data[key])
              });
    axios.post(UPDATE_TEMPLATE_URL, form);
  }
    
  
  export const apiGetCategories = () =>
    axios.get(GET_CATEGORIES_URL).then(({ data }) => data);
  
    export const apiGetTypes = () =>
    axios.get(GET_TYPES_URL).then(({ data }) => data);
  

  
