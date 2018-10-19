import React from 'react'

import { Container } from './styled'

class InputTextContainer extends React.Component {
    constructor(props) {
        super(props);
        this.state = { isFocus: false };

        this.Blur = this.Blur.bind(this);
        this.Focus = this.Focus.bind(this);
    }

    Focus(event) {
        this.setState({ isFocus: true });
    }

    Blur(event) {
        if (event.target.value === '')
            this.setState({ isFocus: false });
    }

    render() {
        return (
            <Container>

            </Container>
        );
    }
}

export default InputTextContainer