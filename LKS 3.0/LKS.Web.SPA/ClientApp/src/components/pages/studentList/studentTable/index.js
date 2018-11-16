import React from 'react'

import THead from './THead'

import { Container } from './styled'

class StydentTable extends React.Component<> {

    render() {
        return (
            <Container>
                <table>
                    <THead/>
                </table>
            </Container>
        );
    }
}

export default StydentTable