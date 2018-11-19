import React from 'react'
import PropTypes from 'prop-types'
import { Button, Modal } from 'react-bootstrap'

import { Container } from './styled'

class CreateTroop extends React.Component {
    hide = () => {
        this.props.onHide('TroopCreate');
    }

    render() {
        return (
            <Modal show={this.props.show} onHide={this.props.onHide}>
                <Container>

                </Container>
            </Modal>
        );
    }
}

CreateTroop.props = {
    show: PropTypes.bool,
    onHide: PropTypes.func,
}

export default CreateTroop