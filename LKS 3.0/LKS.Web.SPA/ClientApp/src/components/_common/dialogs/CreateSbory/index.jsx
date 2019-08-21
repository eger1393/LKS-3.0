import React, { useState, useMemo } from 'react';
import { connect } from 'react-redux'
import ModalDialog from '../../ModalDialog'
import { FlexBox, FlexRow } from '../../elements/StyleDialogs/styled'
import Piky from 'react-picky'
import { getTroopList, getStudentListData } from '../../../../selectors/studentList'
import SVGIcon from '../../elements/SVGIcon'
import Button from '../../elements/Button'
import { apiSetStudentSboryTroop } from '../../../../api/studentList'
import { fetchGetStudentListData } from '../../../../redux/modules/studentList'

import { DropDownContainerStyled, ColumnStule, ContainerStyle, ArrowButton, ArrowContainerStyled } from './styled';

const CreateSbory = props => {
    const [universityState, setUniversityState] = useState({ slectedTroop: [], studentList: [], selectedStudents: [] });
    const [sboriState, setSboriState] = useState({ slectedTroop: null, studentList: [], selectedStudents: [] });
    const [studentList, setStudentList] = useState(props.students || [])
    const [disabled, setDisabled] = useState(false)
    const universityTroop = (props.troops && props.troops.filter(troop => !troop.isSboriTroop)) || [];
    const sboriTroop = props.troops && props.troops.filter(troop => troop.isSboriTroop);
    const handleChangeUniversityTroop = data => {
        let students = studentList.filter(x => data.some(troop => x.troopId === troop.id));
        setUniversityState({ ...universityState, studentList: students, slectedTroop: data })
    }

    const handleChangeSboriTroop = data => {
        let students = studentList.filter(x => x.sboryTroopId === data.id);
        setSboriState({ ...universityState, studentList: students, slectedTroop: data, selectedStudents: [] })
    }

    const handleMoveForvard = async () => {
        if (!sboriState.slectedTroop) {
            return; // TODO error
        }
        let students = studentList.map(x => {
            if (universityState.selectedStudents.some(st => st.id === x.id)) {
                return { ...x, sboryTroopId: sboriState.slectedTroop.id }
            }
            return { ...x }
        })
        setStudentList(students);
        students = students.filter(x => x.sboryTroopId === sboriState.slectedTroop.id);
        setSboriState({ ...universityState, studentList: students, slectedTroop: sboriState.slectedTroop, selectedStudents: [] })
    }

    const handleMoveBack = () => {
        if (!sboriState.slectedTroop) {
            return; // TODO error
        }
        let students = studentList.map(x => {
            if (sboriState.selectedStudents.some(st => st.id === x.id)) {
                return { ...x, sboryTroopId: null }
            }
            return { ...x }
        })
        setStudentList(students);
        students = students.filter(x => x.sboryTroopId === sboriState.slectedTroop.id);
        setSboriState({ ...universityState, studentList: students, slectedTroop: sboriState.slectedTroop, selectedStudents: [] })
    }
    const handleSave = () => {
        setDisabled(true)
        apiSetStudentSboryTroop(studentList).then(() => {
            props.fetchGetStudentListData();
            props.onHide();
        });
    }
    return (
        <ModalDialog
            show={props.show}
            onHide={props.onHide}
            header="Список шаблонов"
            crossOnly={true}
        >
            <FlexBox>
                <ContainerStyle>
                    <ColumnStule>
                        <DropDownContainerStyled>
                            <label htmlFor="universityTroop">Взвода</label>
                            <Piky
                                id="universityTroop"
                                options={universityTroop}
                                value={universityState.slectedTroop}
                                onChange={handleChangeUniversityTroop}
                                placeholder="Выберите взвод"
                                valueKey="id"
                                labelKey="numberTroop"
                                multiple={true}
                                keepOpen={true}
                                numberDisplayed={2}
                                manySelectedPlaceholder="Выбранно %s элементов"
                                includeSelectAll={universityTroop.length}
                                selectAllText="Выбрать всех"
                            />
                        </DropDownContainerStyled>

                        <DropDownContainerStyled>
                            <label htmlFor="universityStudents">Студенты</label>
                            <Piky
                                id="universityStudents"
                                options={universityState.studentList}
                                value={universityState.selectedStudents}
                                onChange={data => setUniversityState({ ...universityState, selectedStudents: data })}
                                placeholder="Выберите студентов"
                                valueKey="id"
                                labelKey="initials"
                                multiple={true}
                                keepOpen={true}
                                numberDisplayed={2}
                                manySelectedPlaceholder="Выбранно %s элементов"
                                includeSelectAll={universityState.studentList.length}
                                selectAllText="Выбрать всех"
                            />
                        </DropDownContainerStyled>
                    </ColumnStule>
                    <ArrowContainerStyled>
                        <ArrowButton onClick={handleMoveForvard}>
                            <SVGIcon name="rightArrowsCouple" />
                        </ArrowButton>
                        <ArrowButton onClick={handleMoveBack}>
                            <SVGIcon name="rightArrowsCouple" style={{ transform: 'rotate(180deg)' }} />
                        </ArrowButton>
                    </ArrowContainerStyled>
                    <ColumnStule>
                        <DropDownContainerStyled>
                            <label htmlFor="sboriTroop">Взвода</label>
                            <Piky
                                id="sboriTroop"
                                options={sboriTroop}
                                value={sboriState.slectedTroop}
                                onChange={handleChangeSboriTroop}
                                placeholder="Выберите взвод"
                                valueKey="id"
                                labelKey="numberTroop"
                            />
                        </DropDownContainerStyled>

                        <DropDownContainerStyled>
                            <label htmlFor="sboriStudents">Студенты</label>
                            <Piky
                                id="sboriStudents"
                                options={sboriState.studentList}
                                value={sboriState.selectedStudents}
                                onChange={data => setSboriState({ ...sboriState, selectedStudents: data })}
                                placeholder="Выберите студентов"
                                valueKey="id"
                                labelKey="initials"
                                multiple={true}
                                keepOpen={true}
                                numberDisplayed={2}
                                manySelectedPlaceholder="Выбранно %s элементов"
                                includeSelectAll={sboriState.studentList.length}
                                selectAllText="Выбрать всех"
                            />
                        </DropDownContainerStyled>
                    </ColumnStule>
                </ContainerStyle>
            </FlexBox>
            <div className="form-submit">
                <Button disabled={disabled} onClick={handleSave} value="Сохранить" />
            </div>
        </ModalDialog>
    );
}

const mapStateToProps = state => ({
    troops: getTroopList(state),
    students: getStudentListData(state)
})

export default connect(mapStateToProps, { fetchGetStudentListData })(CreateSbory);