import React from 'react'
import PropTypes from 'prop-types'
import Select from '../../../elements/Select'
import Picky from 'react-picky'
import 'react-picky/dist/picky.css'
import Button from '../../../elements/Button'
import { FlexBox, FlexRow } from '../../../elements/StyleDialogs/styled'

import { apiGetTroopStudentsListInitial } from '../../../../../api/dialogs'
import { apiCreateLKSTemplate } from '../../../../../api/templates'

import { TemplateItem } from '../styled'

class LKS extends React.Component {
    state = {
        fieldValue: {}, // значение полей формы
        selectedTroop: '',
        students: [],
        selectedStudents: [],
    }

    changeTroop = event => {
        var self = this;
        this.setState({ selectedTroop: event.target.value, selectedStudents: [] });
        apiGetTroopStudentsListInitial(event.target.value).then(res => {
            self.setState({ students: res.data })
        })
        this.changeField(event);
    }

    changeField = event => {
        var name = event.target.name ? event.target.name : event.target.id,
            val = event.target.value;
        this.setState(prevState => ({
            fieldValue: { ...prevState.fieldValue, [name]: val, }
        }));
    }

    createTemplate = () => {
        this.state.selectedStudents && this.state.selectedStudents.map(ob => {
            apiCreateLKSTemplate({ selectedTemplate: this.state.fieldValue.selectedTemplate, studentId: ob.id }).then(ob => {
                //TODO сделать лоадер
            });

        })

    }

    changeSelectedStudents = val => {
        this.setState({ selectedStudents: val });
    }

    render() {
        var order = [
            { value: 'firstName', text: 'По фамилии' },
            { value: 'group', text: 'По группе' },
            { value: 'none', text: 'Нет' },
        ]
        return (
            <div>
                <FlexBox className="flex-box">
                    <FlexRow className="flex-row">
                        <div>
                            <p>Документы:</p>
                            <TemplateItem>
                                <input
                                    id="universityAdmissionForm"
                                    type="radio"
                                    name="selectedTemplate"
                                    value="universityAdmissionForm"
                                    onChange={this.changeField}
                                />
                                <label htmlFor="universityAdmissionForm" unselectable="on">Форма допуска</label>
                            </TemplateItem>
                            <TemplateItem>
                                <input
                                    id="universityCandidateExamen"
                                    type="radio"
                                    name="selectedTemplate"
                                    value="universityCandidateExamen"
                                    onChange={this.changeField}
                                />
                                <label htmlFor="universityCandidateExamen" unselectable="on">Лист изучения кандидата на призыв</label>
                            </TemplateItem>
                            <TemplateItem>
                                <input
                                    id="universityLKS"
                                    type="radio"
                                    name="selectedTemplate"
                                    value="universityLKS"
                                    onChange={this.changeField}
                                />
                                <label htmlFor="universityLKS" unselectable="on">Личная карточка студента</label>
                            </TemplateItem>
                        </div>
                        <div>
                            <Select id="numberTroop"
                                data={this.props.troops}
                                placeholder="Номер взвода"
                                value="id"
                                text="numberTroop"
                                onChange={this.changeTroop}
                            />

                            <Picky
                                options={this.state.students}
                                value={this.state.selectedStudents}
                                onChange={this.changeSelectedStudents}
                                multiple={true}
                                valueKey="id"
                                labelKey="initials"
                                numberDisplayed="1"
                                manySelectedPlaceholder="%s выбранно"
                                allSelectedPlaceholder="%s выбранно"
                                includeSelectAll={true}
                                selectAllText="Выбрать всех"
                                placeholder=""
                            />

                        </div>
                    </FlexRow>
                </FlexBox>
                <div className="form-submit">
                    <Button onClick={this.createTemplate} value="Создать" />
                </div>
            </div>
        );
    }
}

LKS.props = {
    changeField: PropTypes.func,
    troops: PropTypes.array,
}


export default LKS