// @flow
import * as _ from 'lodash'
export const getAddStudentFieldsValue = state => _.get(state, ['addStudent', 'fieldsValue']);
export const getAddStudentErrorValues = state => _.get(state, ['addStudent', 'errorValues']);
export const getAddStudentRelatives = state => _.get(state, ['addStudent', 'fieldsValue', 'relatives']);
export const getIsLoading = state => _.get(state, ['loading']);
export const getIsError = state => _.get(state, ['errorStudent']);
export const getStudentRelative = (state, index) => _.get(state, `addStudent.fieldsValue.relatives[${index}]`)
export const getStudentId = (state) => _.get(state, 'addStudent.fieldsValue[id]')
export const getStudentPhoto = state => _.get(state, 'addStudent.studentPhoto')
export const getAddStudentFieldValue = (state, fieldName) =>
  _.get(state, `addStudent.fieldsValue.${fieldName}`);
export const getIsErrorInfo = state => TrueOrFalse(_.get(state, ['addStudent', 'errorValues', 'infoTab']));
export const getIsErrorPersonal = state => TrueOrFalse(_.get(state, ['addStudent', 'errorValues', 'personalTab']));

function TrueOrFalse(errors) {
    var res = false;
    for (var er in errors) {
        res = res || errors[er];
    }
    return res;
}