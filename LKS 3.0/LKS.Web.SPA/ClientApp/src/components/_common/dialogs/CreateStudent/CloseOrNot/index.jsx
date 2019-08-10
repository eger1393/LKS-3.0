import React, { Component } from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types';
import ModalDialog from '../../../../_common/ModalDialog'
import Button from '../../../elements/Button'
import { Container, ModalContainer, ModalBody, ModalFooter } from './styled'

export default class ModalClose extends React.Component {
    render() {

        const { isOpen, isOk, isCancel } = this.props
        return (
            <Container>
                <ModalDialog
                    show={isOpen}
                    onHide={isCancel}
                    header="Внимание!"
                >
                    <ModalBody>
                        <p>Вы уверены что хотите закрыть окно? Все несохраненные изменения будут удалены!</p>
                    </ModalBody>
                    <ModalFooter>
                        <Button onClick={isOk} value="Да" />
                        <Button onClick={isCancel} value="Отмена" />
                    </ModalFooter>
                </ModalDialog>
            </Container>

        );
    }
}

ModalClose.propTypes = {
    isOpen: PropTypes.bool,
    isOk: PropTypes.func,
    isCancel: PropTypes.func,
}
