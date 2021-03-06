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
        if (!Array.isArray(data)) {
            data = [data];
        }
        TemplateListStore.selectedTroos = data;

        if (selectedTemplate.type === 0 || selectedTemplate.type === 1) {
            setTroopStudents(props.students.filter(x => data.some(troop => troop.id === x.troopId)));
            TemplateListStore.selectedStudents = TemplateListStore.selectedStudents.filter(x => data.some(troop => troop.id === x.troopId));
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
                    multiple={selectedTemplate.type !== 2}
                    keepOpen={selectedTemplate.type !== 2}
                    numberDisplayed={4}
                    manySelectedPlaceholder="Выбранно %s элементов"
                />
            </DropDownContainerStyled>

            {(selectedTemplate.type === 0 || selectedTemplate.type === 1) &&
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
                            multiple={true}
                            keepOpen={true}
                            numberDisplayed={4}
                            manySelectedPlaceholder="Выбранно %s элементов"
                            includeSelectAll={true}
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
    singleTroop = 2,
    manyTroops = 3,
    singleStudent = 0,
    manyStudent = 1

*/

const mapStateToProps = (state) => ({
    troops: getTroopList(state),
    students: getStudentListData(state),
})

export default connect(mapStateToProps)(observer(AdditionalInfo));