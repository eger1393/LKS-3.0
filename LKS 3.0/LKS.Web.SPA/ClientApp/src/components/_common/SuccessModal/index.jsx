import React from 'react'
import ModalDialog from '../ModalDialog'
import Button from '../elements/Button'
import { Container, ModalBody, ModalFooter } from './styled'

export default class SuccessModal extends React.Component {
    render() {

        const { isOpen, isOk, onHide, children } = this.props
        return (
            <Container>
                <ModalDialog
                    show={isOpen}
                    onHide={onHide}
                    header="Внимание!"
                >
                    <ModalBody>
                        {children}
                    </ModalBody>
                    <ModalFooter>
                        <Button onClick={isOk} value="Закрыть" />
                    </ModalFooter>
                </ModalDialog>
            </Container>

        );
    }
}

