import React from 'react'
import PropTypes from 'prop-types'
import Select from '../../../elements/Select'
import Button from '../../../elements/Button'
import { FlexBox, FlexRow } from '../../../elements/StyleDialogs/styled'

import { TemplateItem } from '../styled'

class TroopDocument extends React.Component {

    render() {
        var order = [
            { value: 'firstName', text: 'По фамилии' },
            { value: 'group', text: 'По группе' },
            { value: 'none', text: 'Нет' },
        ]
        return (
            <div >
                <FlexBox className="flex-box">
                    <FlexRow className="flex-row">
                        <div>
                            <p>Документы:</p>
                            <TemplateItem>
                                <input
                                    id="universityStudentList"
                                    type="radio"
                                    name="selectedTemplate"
                                    value="universityStudentList"
                                    onChange={this.props.changeField}
                                />
                                <label htmlFor="universityStudentList" unselectable="on">Список взвода</label>
                            </TemplateItem>
                            <TemplateItem>
                                <input
                                    id="universityConditionsEducation"
                                    type="radio"
                                    name="selectedTemplate"
                                    value="universityConditionsEducation"
                                    onChange={this.props.changeField}
                                />
                                <label htmlFor="universityConditionsEducation" unselectable="on">Условия обучения</label>
                            </TemplateItem>
                            <TemplateItem>
                                <input
                                    id="universityThematicControl"
                                    type="radio"
                                    name="selectedTemplate"
                                    value="universityThematicControl"
                                    onChange={this.props.changeField}
                                />
                                <label htmlFor="universityThematicControl" unselectable="on">Тематический контроль</label>
                            </TemplateItem>
                        </div>
                        <div>
                            <Select id="numberTroop"
                                data={this.props.troops}
                                placeholder="Номер взвода"
                                value="id"
                                text="numberTroop"
                                onChange={this.props.changeField}
                            />
                            {
                                //<Select id="order"
                                //    data={order}
                                //    placeholder="Порядок сортировки"
                                //    value="value"
                                //    text="text"
                                //    onChange={this.props.changeField}
                                ///>
                            }
                        </div>
                    </FlexRow>
                </FlexBox>
                <div className="form-submit">
                    <Button onClick={this.props.createTemplate} value="Создать" />
                </div>
            </div>
        );
    }
}

TroopDocument.props = {
    changeField: PropTypes.func,
    troops: PropTypes.array,
    creacteTemplate: PropTypes.func,
}


export default TroopDocument