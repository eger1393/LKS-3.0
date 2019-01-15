import axios from 'axios'
import fileDownload from 'js-file-download'
import fileD from 'react-file-download'

const CREATE_TELMPLATE_URL = '/api/template/CreateUniversityTemplate'
const CREATE_TELMPLATE_LKS_URL = '/api/template/CreateUniversityLKSTemplate'

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


