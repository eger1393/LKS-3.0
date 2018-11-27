import React from 'react'
import PropTypes from 'prop-types'
import Select from '../../../elements/Select'
import Button from '../../../elements/Button'
import { FlexBox, FlexRow } from '../../../elements/StyleDialogs/styled'

import { TemplateItem } from '../styled'

class Journal extends React.Component {

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
                                id="universityJournalCover"
                                type="radio"
                                name="selectedTemplate"
                                value="universityJournalCover"
                                onChange={this.props.changeField}
                            />
                            <label htmlFor="universityJournalCover" unselectable="on">Обложка</label>
                        </TemplateItem>
                        <TemplateItem>
                            <input
                                id="universityJournalFull"
                                type="radio"
                                name="selectedTemplate"
                                value="universityJournalFull"
                                onChange={this.props.changeField}
                            />
                            <label htmlFor="universityJournalFull" unselectable="on">Журнал целиком</label>
                        </TemplateItem>
                        <TemplateItem>
                            <input
                                id="universityJournalPenalties"
                                type="radio"
                                name="selectedTemplate"
                                value="universityJournalPenalties"
                                onChange={this.props.changeField}
                            />
                            <label htmlFor="universityJournalPenalties" unselectable="on">Наряды, взыскания, инструктажи</label>
                        </TemplateItem>
                        <TemplateItem>
                            <input
                                id="universityJournalAttendance"
                                type="radio"
                                name="selectedTemplate"
                                value="universityJournalAttendance"
                                onChange={this.props.changeField}
                            />
                            <label htmlFor="universityJournalAttendance" unselectable="on">Посещаемость</label>
                        </TemplateItem>
                        <TemplateItem>
                            <input
                                id="universityJournalStudentList"
                                type="radio"
                                name="selectedTemplate"
                                value="universityJournalStudentList"
                                onChange={this.props.changeField}
                            />
                            <label htmlFor="universityJournalStudentList" unselectable="on">Список взвода для журнала</label>
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
            </div >

        );
    }
}

Journal.props = {
    changeField: PropTypes.func,
    troops: PropTypes.array,
}


export default Journal