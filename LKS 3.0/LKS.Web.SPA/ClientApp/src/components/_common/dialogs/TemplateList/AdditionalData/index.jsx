import React, { useState, useEffect } from 'react'
import Piky from 'react-picky'

import { BackButtonStyled, TitleStyled } from '../styled';
import TemplateListStore from '../../../../../Store/templateListStore'
import { observer } from 'mobx-react'
import { connect } from 'react-redux'
import { getStudentListData, getTroopList } from '../../../../../selectors/studentList'
import { DropDownContainerStyled } from './styled';

const AdditionalInfo = props => {
    const [troopStudents, setTroopStudents] = useState([]);
    const { selectedTemplate } = TemplateListStore;

    const handleChangeTroop = data => {
        console.log(data)
        TemplateListStore.selectedTroos = data;
        if (selectedTemplate.type === 'singleStydent' || selectedTemplate.type === 'manyStydent') {
            setTroopStudents(props.students.filter(x => x.troopId === data.id));
        }
    }

    const handleChangeStudent = data => {
        console.log(data)
        TemplateListStore.selectedStudents = data;
    }

    const handleBack = () => {
        TemplateListStore.selectedStudents = [];
        TemplateListStore.selectedTroos = [];
        TemplateListStore.displayedContent = 'TemplateListItems'
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
                    multiple={selectedTemplate.type === 'manyTroop'}
                    keepOpen={selectedTemplate.type === 'manyTroop'}
                    numberDisplayed={4}
                    manySelectedPlaceholder="Выбранно %s элементов"
                />
            </DropDownContainerStyled>

            {(selectedTemplate.type === 'singleStydent' || selectedTemplate.type === 'manyStydent') &&
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
                            multiple={selectedTemplate.type === 'manyStydent'}
                            keepOpen={selectedTemplate.type === 'manyStydent'}
                            numberDisplayed={4}
                            manySelectedPlaceholder="Выбранно %s элементов"
                        />
                    </DropDownContainerStyled>
                )
            }

        </>
    );
}

/*
    singleTroop,
    manyTroop,
    singleStydent,
    manyStydent

*/

const mapStateToProps = (state) => ({
    troops: getTroopList(state),
    students: getStudentListData(state),
})

export default connect(mapStateToProps)(observer(AdditionalInfo));