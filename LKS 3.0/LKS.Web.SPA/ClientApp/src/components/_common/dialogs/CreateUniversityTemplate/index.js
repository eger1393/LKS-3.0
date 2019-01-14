import React from 'react'
import PropTypes from 'prop-types'
import { Modal, Tab, Tabs } from 'react-bootstrap'
import FormHead from '../../elements/FormHead'
import Button from '../../elements/Button'
import { ModalContainer } from '../../elements/StyleDialogs/styled'

import { apiGetTroopList } from '../../../../api/dialogs'
import { apiCreateTemplate } from '../../../../api/templates'

import TroopDocument from './TroopDocument'
import Journal from './Journal'
import LKS from './LKS'
import Ankets from './Ankets'
import CommonDocuments from './CommonDocuments'
import { Container } from './styled'

class CreateUniversityTemplate extends React.Component {
    state = {
        fieldValue: {}, // значение полей формы
        troops: [], // список взводов
        key: 'TroopDocument', // Выбранная вкладка, нужно чтобы отрисовывать вкладку заного при переключении(подумать как убрать этот костыль)
    }

    changeField = event => {
        var name = event.target.name ? event.target.name : event.target.id,
            val = event.target.value;
        this.setState(prevState => ({
            fieldValue: { ...prevState.fieldValue, [name]: val, }
        }));
    }

    createTemplate = () => {
        if (this.validate()) {
            apiCreateTemplate(this.state.fieldValue).then(ob => {
                //TODO сделать лоадер
            });
        }

    }

    tabsSelect = key => {
        this.setState({ fieldValue: {}, key: key })
    }

    validate = () => {
        // TODO add validate fields
        return true;
    }

    componentDidMount() {
        var self = this;
        apiGetTroopList().then(res => self.setState({ troops: res }));

    }

    render() {
        return (
            <Modal show={this.props.show} onHide={this.props.onHide}>
                <ModalContainer>
                    <Container>
                        <FormHead text="Создание отчета" handleClick={this.props.onHide} />
                        <Tabs defaultActiveKey={'TroopDocument'} animation={false} id="myTabs" onSelect={this.tabsSelect}>
                            <Tab eventKey={'TroopDocument'} title="Документы на взвод">
                                {this.state.key ==='TroopDocument' &&(<TroopDocument
                                    changeField={this.changeField}
                                    troops={this.state.troops}
                                    createTemplate={this.createTemplate}
                                />)}
                            </Tab>
                            <Tab eventKey={'Journal'} title="Журналы">
                                {this.state.key === 'Journal' && (<Journal
                                    changeField={this.changeField}
                                    troops={this.state.troops}
                                    createTemplate={this.createTemplate}
                                />)}
                            </Tab>
                            <Tab eventKey={'Ankets'} title="Анкеты">
                                {this.state.key === 'Ankets' && (<Ankets/>)}
                            </Tab>
                            <Tab eventKey={'LKS'} title="ЛКС">
                                {this.state.key === 'LKS' && (<LKS
                                    changeField={this.changeField}
                                    troops={this.state.troops}
                                />)}
                            </Tab>
                            <Tab eventKey={'CommonDocuments'} title="Общие документы">
                                {this.state.key === 'CommonDocuments' && (<CommonDocuments />)}
                            </Tab>
                        </Tabs>
                        
                    </Container>
                </ModalContainer>
            </Modal>
        );
    }
}

CreateUniversityTemplate.props = {
    show: PropTypes.bool,
    onHide: PropTypes.func,
}

CreateUniversityTemplate.state = {
    fieldValue: PropTypes.array,
}

export default CreateUniversityTemplate