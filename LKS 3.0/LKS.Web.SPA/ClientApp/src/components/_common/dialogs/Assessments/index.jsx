import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux'
import Piky from 'react-picky'
import { getStudentListData, getTroopList } from '../../../../selectors/studentList'
import ModalDialog from '../../ModalDialog'
import { FlexBox } from '../../elements/StyleDialogs/styled'
import { apiGetStudentAssessments, apiSaveAssessments } from '../../../../api/sbori'
import Input from '../../elements/Input'
import Button from '../../elements/Button'
import SuccessModal from '../../SuccessModal'
import { DropDownContainerStyled, TableStyled } from './styled';

const Assessments = props => {
    const [studentList, setStudentList] = useState();
    const [troopList, setTroopList] = useState([]);
    const [showSuccess, setShowSuccess] = useState(false)
    const [selectedTroop, setSelectedTroop] = useState(null)
    useEffect(() => {
        setTroopList(props.troops && props.troops.filter(x => x.isSboriTroop))
    }, [props.troops])

    const handleChangeTroop = data => {
        setSelectedTroop(data);
        apiGetStudentAssessments(data.id).then(({ data }) => {
            setStudentList(data.map(x => ({ ...x, assessment: x.assessment || {} })))
        })
    }
    const handleAssessmentChange = (studentId, fieldName) => e => {
        let val = Number.parseInt(e.target.value);
        if (e.target.value !== '' && (isNaN(val) || val > 5 || val < 2)) {
            return;
        }
        let students = studentList.map(x => {
            if (x.id === studentId) {
                return { ...x, assessment: { ...x.assessment, [fieldName]: e.target.value } }
            } else {
                return { ...x }
            }
        })
        setStudentList(students)
    }
    const handleSaveClick = async () => {
        await apiSaveAssessments(studentList);
    }

    return (
        <ModalDialog
            show={props.show}
            onHide={props.onHide}
            header="Оценки"
        >
            <FlexBox>
                <DropDownContainerStyled>
                    <label htmlFor="troop">Взвода</label>
                    <Piky
                        id="troop"
                        options={troopList}
                        value={selectedTroop}
                        onChange={handleChangeTroop}
                        placeholder="Выберите взвод"
                        valueKey="id"
                        labelKey="numberTroop"
                        keepOpen={false}
                    />
                </DropDownContainerStyled>
                {studentList && (
                    <>
                        <TableStyled>
                            <thead>
                                <tr>
                                    <th>ФИО</th>
                                    <th>Оценка1</th>
                                    <th>Оценка2</th>
                                    <th>Оценка3</th>
                                    <th>Оценка4</th>
                                    <th>Оценка5</th>
                                    <th>Оценка6</th>
                                </tr>
                            </thead>
                            <tbody>
                                {studentList && studentList.map(student => (
                                    <tr key={student.id}>
                                        <td>{student.initials}</td>
                                        <td>
                                            <Input id={student.id + "protocolOneTheory"}
                                                type="text"
                                                placeholder="Оценка1"
                                                value={student.assessment.protocolOneTheory}
                                                onChange={handleAssessmentChange(student.id, "protocolOneTheory")}
                                            />
                                        </td>
                                        <td>
                                            <Input id={student.id + "protocolOnePractice"}
                                                type="text"
                                                placeholder="Оценка2"
                                                value={student.assessment.protocolOnePractice}
                                                onChange={handleAssessmentChange(student.id, "protocolOnePractice")}
                                            />
                                        </td>
                                        <td>
                                            <Input id={student.id + "protocolOneFinal"}
                                                type="text"
                                                placeholder="Оценка3"
                                                value={student.assessment.protocolOneFinal}
                                                onChange={handleAssessmentChange(student.id, "protocolOneFinal")}
                                            />
                                        </td>
                                        <td>
                                            <Input id={student.id + "characteristicMilitaryTechnicalTraining"}
                                                type="text"
                                                placeholder="Оценка4"
                                                value={student.assessment.characteristicMilitaryTechnicalTraining}
                                                onChange={handleAssessmentChange(student.id, "characteristicMilitaryTechnicalTraining")}
                                            />
                                        </td>
                                        <td>
                                            <Input id={student.id + "characteristicTacticalSpecialTraining"}
                                                type="text"
                                                placeholder="Оценка5"
                                                value={student.assessment.characteristicTacticalSpecialTraining}
                                                onChange={handleAssessmentChange(student.id, "characteristicTacticalSpecialTraining")}
                                            />
                                        </td>
                                        <td>
                                            <Input id={student.id + "characteristicMilitarySpeialTraining"}
                                                type="text"
                                                placeholder="Оценка6"
                                                value={student.assessment.characteristicMilitarySpeialTraining}
                                                onChange={handleAssessmentChange(student.id, "characteristicMilitarySpeialTraining")}
                                            />
                                        </td>
                                        <td>
                                            <Input id={student.id + "characteristicFinal"}
                                                type="text"
                                                placeholder="Оценка7"
                                                value={student.assessment.characteristicFinal}
                                                onChange={handleAssessmentChange(student.id, "characteristicFinal")}
                                            />
                                        </td>
                                    </tr>
                                ))}
                            </tbody>
                        </TableStyled>
                        <Button onClick={handleSaveClick} value="Сохранить" />
                    </>
                )}
                {showSuccess && <SuccessModal
                    show={showSuccess}
                    onHide={() => setShowSuccess(false)}
                    isOk={() => setShowSuccess(false)}
                >
                    Оценки успешно сохранены!
                </SuccessModal>}
            </FlexBox>
        </ModalDialog>
    );
}

const mapStateToProps = state => ({
    students: getStudentListData(state).slice(0, 10),
    troops: getTroopList(state)
})

export default connect(mapStateToProps)(Assessments);