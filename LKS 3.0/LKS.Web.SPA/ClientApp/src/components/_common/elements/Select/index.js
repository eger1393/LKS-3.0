import React from 'react'
import PropTypes from 'prop-types'

import { Container } from './styled'

class Select extends React.Component {
    state = { isFocus: false}

    Focus = event => {
        this.setState({ isFocus: true })
    }

    Blur = event => {
        if (event.target.value === '') this.setState({ isFocus: false })
    }

    render() {
        return (
            <Container
                className={`${this.state.isFocus ? 'animate' : ''} ${
                    this.props.error ? 'invalid' : ''
                    }`}
            >
                <select onChange={this.props.onChange} id={this.props.id} onFocus={this.Focus} onBlur={this.Blur}>
                    <option disabled selected></option>
                    {this.props.value.map(ob => {
                        return (
                            <option value={ob.id}>{ob.val}</option>
                        )
                    })}
                </select>
                <label
                    htmlFor={this.props.id}
                    unselectable="on"
                    className="label-for-input"
                >
                    {this.props.placeholder}
                    {this.props.isRequired ? <span className="red-star">*</span> : ''}
                </label>
                <span className="layer">!</span>
            </Container>
        )
    }
}

Select.props = {
    placeholder: PropTypes.string,
    id: PropTypes.string,
    value: PropTypes.array,
    isRequired: PropTypes.bool,
    error: PropTypes.bool,
    onChange: PropTypes.func,
}

export default Select
