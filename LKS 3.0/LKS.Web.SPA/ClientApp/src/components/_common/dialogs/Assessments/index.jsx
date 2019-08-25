import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux'
import Piky from 'react-picky'
import { getTroopList } from '../../../../selectors/studentList'
import ModalDialog from '../../ModalDialog'
import { FlexBox } from '../../elements/StyleDialogs/styled'
import { apiGetStudentAssessments, apiSaveAssessments } from '../../../../api/sbory'
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
        setShowSuccess(true);
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
                                    <th>Теоретические знания</th>
                                    <th>Практичесикие умения</th>
                                    <th>Общая оценка</th>
                                    <th>Оценка за ФИЗО</th>
                                    <th>Методический уровень</th>
                                </tr>
                            </thead>
                            <tbody>
                                {studentList && studentList.map(student => (
                                    <tr key={student.id}>
                                        <td>{student.initials}</td>
                                        <td>
                                            <Input id={student.id + "protocolOneTheory"}
                                                type="text"
                                                placeholder="Теоретические знания"
                                                value={student.assessment.protocolOneTheory}
                                                onChange={handleAssessmentChange(student.id, "protocolOneTheory")}
                                            />
                                        </td>
                                        <td>
                                            <Input id={student.id + "protocolOnePractice"}
                                                type="text"
                                                placeholder="Практичесикие умения"
                                                value={student.assessment.protocolOnePractice}
                                                onChange={handleAssessmentChange(student.id, "protocolOnePractice")}
                                            />
                                        </td>
                                        <td>
                                            <Input id={student.id + "protocolOneFinal"}
                                                type="text"
                                                placeholder="Общая оценка"
                                                value={student.assessment.protocolOneFinal}
                                                onChange={handleAssessmentChange(student.id, "protocolOneFinal")}
                                            />
                                        </td>
                                        <td>
                                            <Input id={student.id + "sportLevel"}
                                                type="text"
                                                placeholder="Оценка за ФИЗО"
                                                value={student.assessment.sportLevel}
                                                onChange={handleAssessmentChange(student.id, "sportLevel")}
                                            />
                                        </td>
                                        <td>
                                            <Input id={student.id + "methodologicalLevel"}
                                                type="text"
                                                placeholder="Методический уровень"
                                                value={student.assessment.methodologicalLevel}
                                                onChange={handleAssessmentChange(student.id, "methodologicalLevel")}
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
    troops: getTroopList(state)
})

export default connect(mapStateToProps)(Assessments);