import axios from 'axios'
import fileDownload from 'js-file-download'
import fileD from 'react-file-download'

const CREATE_TELMPLATE_URL = '/api/template/CreateTemplate'

export const apiCreateTemplate = data =>
    axios.get(CREATE_TELMPLATE_URL, { responseType: 'arraybuffer' })
        .then(res => {
            var blob = new Blob([res.data], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' });
            fileDownload(blob, 'test.docx');
        });

