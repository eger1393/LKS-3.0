import React, { useState, useEffect } from 'react'
import Piky from 'react-picky'
import Button from '../../../elements/Button'

import { BackButtonStyled, TitleStyled } from '../styled';
import TemplateListStore from '../../../../../Store/templateListStore'
import { observer } from 'mobx-react'
import { connect } from 'react-redux'
import { getStudentListData, getTroopList } from '../../../../../selectors/studentList'
import { DropDownContainerStyled } from './styled';
import { apiCreateTemplate, apiSetTemplateData } from '../../../../../api/templates'

const AdditionalInfo = props => {
    const [troopStudents, setTroopStudents] = useState([]);
    const { selectedTemplate } = TemplateListStore;

    const handleChangeTroop = data => {
        if (Array.isArray(data)) {
            TemplateListStore.selectedTroos = data;
        }
        else {
            TemplateListStore.selectedTroos = [data];
        }
        if (selectedTemplate.type === 'singleStudent' || selectedTemplate.type === 'manyStudents') {
            setTroopStudents(props.students.filter(x => x.troopId === data.id));
        }
        console.log(TemplateListStore.selectedTroos)
    }

    const handleChangeStudent = data => {
        if (Array.isArray(data)) {
            TemplateListStore.selectedStudents = data;
        }
        else {
            TemplateListStore.selectedStudents = [data];
        }
        console.log(TemplateListStore.selectedStudents)
    }

    const handleBack = () => {
        TemplateListStore.selectedStudents = [];
        TemplateListStore.selectedTroos = [];
        TemplateListStore.displayedContent = 'TemplateListItems'
    }

    const handleSubmit = () => {
        // valiate

        let data = {
            templateId: TemplateListStore.selectedTemplate.id,
            studentIds: TemplateListStore.selectedStudents.map(x => x.id),
            troopIds: TemplateListStore.selectedTroos.map(x => x.id),
        }
        apiSetTemplateData(data).then(() => {
            apiCreateTemplate(data);
        });

    }

    return (
        <>
            <TitleStyled>
                <BackButtonStyled
                    onClick={handleBack}
                >&#9668;</BackButtonStyled>Выберите данные
            </TitleStyled>
            <DropDownContainerStyled>
                <label htmlFor="troop">Взвода</label>
                <Piky
                    id="troop"
                    options={props.troops}
                    value={TemplateListStore.selectedTroos}
                    onChange={handleChangeTroop}
                    placeholder="Выберите взвод"
                    valueKey="id"
                    labelKey="numberTroop"
                    multiple={selectedTemplate.type === 'manyTroops'}
                    keepOpen={selectedTemplate.type === 'manyTroops'}
                    numberDisplayed={4}
                    manySelectedPlaceholder="Выбранно %s элементов"
                />
            </DropDownContainerStyled>

            {(selectedTemplate.type === 'singleStudent' || selectedTemplate.type === 'manyStudents') &&
                (
                    <DropDownContainerStyled>
                        <label htmlFor="student">Студенты</label>
                        <Piky
                            id="student"
                            options={troopStudents}
                            value={TemplateListStore.selectedStudents}
                            onChange={handleChangeStudent}
                            placeholder="Выберите студентов"
                            valueKey="id"
                            labelKey="initials"
                            multiple={selectedTemplate.type === 'manyStudents'}
                            keepOpen={selectedTemplate.type === 'manyStudents'}
                            numberDisplayed={4}
                            manySelectedPlaceholder="Выбранно %s элементов"
                            includeSelectAll={selectedTemplate.type === 'manyStudents'}
                            selectAllText="Выбрать всех"
                        />
                    </DropDownContainerStyled>
                )
            }

            <Button onClick={handleSubmit} value="Создать" />

        </>
    );
}

/*
    singleTroop,
    manyTroops,
    singleStudent,
    manyStudents

*/

const mapStateToProps = (state) => ({
    troops: getTroopList(state),
    students: getStudentListData(state),
})

export default connect(mapStateToProps)(observer(AdditionalInfo));