import React from 'react'
import PropTypes from 'prop-types'
import Select from '../../../elements/Select'
import Picky from 'react-picky'
import 'react-picky/dist/picky.css'
import Button from '../../../elements/Button'
import { FlexBox, FlexRow } from '../../../elements/StyleDialogs/styled'

import { apiGetTroopStudentsListInitial } from '../../../../../api/dialogs'
import { apiCreateTemplate } from '../../../../../api/templates'

import { TemplateItem } from '../styled'

class Ancets extends React.Component {
    state = {
        fieldValue: {}, // значение полей формы
        selectedTroop: '',
        students: [],
        selectedStudents: [],
    }

    changeField = event => {
        var name = event.target.name ? event.target.name : event.target.id,
            val = event.target.value;
        this.setState(prevState => ({
            fieldValue: { ...prevState.fieldValue, [name]: val, }
        }));
    }

    createTemplate = () => {
            apiCreateTemplate({ selectedTemplate: this.state.fieldValue.selectedTemplate}).then(ob => {
                //TODO сделать лоадер
            });

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
                                    id="universityQuestionnaire"
                                    type="radio"
                                    name="selectedTemplate"
                                    value="universityQuestionnaire"
                                    onChange={this.changeField}
                                />
                                <label htmlFor="universityQuestionnaire" unselectable="on">Анкета</label>
                            </TemplateItem>
                            <TemplateItem>
                                <input
                                    id="universitySampleQuestionnaire"
                                    type="radio"
                                    name="selectedTemplate"
                                    value="universitySampleQuestionnaire"
                                    onChange={this.changeField}
                                />
                                <label htmlFor="universitySampleQuestionnaire" unselectable="on">Образец анкеты</label>
                            </TemplateItem>
                        </div>
                        <div>
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

export default Ancets