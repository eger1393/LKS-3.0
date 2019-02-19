import React, { Component } from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types';
import Modal from '../../../../_common/ModalDialog'
import Button from '../../../elements/Button'
import { Container, ModalContainer, ModalBody, ModalFooter } from './styled'
import FormHead from '../../../elements/FormHead'

export default class ModalClose extends React.Component {


    render() {

        const { isOpen, isOk, isCancel } = this.props
        return (
            <Container>
                <Modal
                    show={isOpen}
                    onHide={isCancel} >
                    <ModalContainer>
                        <FormHead text="Внимание!" handleClick={isCancel} />
                        <ModalBody>
                            <p>Вы уверены что хотите закрыть окно? Все несохраненные изменения будут удалены!</p>
                        </ModalBody>
                        <ModalFooter>
                                <Button onClick={isOk} value="Да" />
                                <Button onClick={isCancel} value="Отмена" />
                        </ModalFooter>
                    </ModalContainer>
                </Modal>
            </Container>

        );
    }
}

ModalClose.propTypes = {
    isOpen: PropTypes.bool,
    isOk: PropTypes.func,
    isCancel: PropTypes.func,
}
