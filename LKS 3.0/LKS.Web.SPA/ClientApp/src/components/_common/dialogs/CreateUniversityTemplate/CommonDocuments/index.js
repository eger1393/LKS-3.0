import React from 'react'
import PropTypes from 'prop-types'
import 'react-picky/dist/picky.css'
import Button from '../../../elements/Button'
import { FlexBox, FlexRow } from '../../../elements/StyleDialogs/styled'

import { apiCreateTemplate } from '../../../../../api/templates'

import { TemplateItem } from '../styled'

class CommonDocuments extends React.Component {
    state = {
        fieldValue: {}, // значение полей формы
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
        return (
            <div>
                <FlexBox className="flex-box">
                    <FlexRow className="flex-row">
                        <div>
                            <p>Документы:</p>
                            <TemplateItem>
                                <input
                                    id="universityCycleStudentList"
                                    type="radio"
                                    name="selectedTemplate"
                                    value="universityCycleStudentList"
                                    onChange={this.changeField}
                                />
                                <label htmlFor="universityCycleStudentList" unselectable="on">Список обущающихся на цикле</label>
                            </TemplateItem>
                            <TemplateItem>
                                <input
                                    id="universityDeductionStudentList"
                                    type="radio"
                                    name="selectedTemplate"
                                    value="universityDeductionStudentList"
                                    onChange={this.changeField}
                                />
                                <label htmlFor="universityDeductionStudentList" unselectable="on">Список студентов на отчисление</label>
                            </TemplateItem>
                            <TemplateItem>
                                <input
                                    id="universityExpellendStudentList"
                                    type="radio"
                                    name="selectedTemplate"
                                    value="universityExpellendStudentList"
                                    onChange={this.changeField}
                                />
                                <label htmlFor="universityExpellendStudentList" unselectable="on">Список отчисленных студентов</label>
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



export default CommonDocuments