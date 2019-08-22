import React from 'react'
import { Container } from './styled'

class Input extends React.Component {
    state = { isFocus: false, value: '', type: this.props.type }

    Focus = event => {
        if (this.props.date == true) this.state.type = 'date';
        this.setState({ isFocus: true })
    }

    Blur = event => {
        if (!this.state.value && this.props.date == true) this.state.type = 'text';
        if (event.target.value === '') this.setState({ isFocus: false })
        
    }

    Change = event => {
        if (this.props.middlewareValidator === undefined || this.props.middlewareValidator(event)) {
            this.props.onChange(event);
        }
    }
   
    render() {
        return (
            <Container
                className={`${this.props.className} ${(this.state.isFocus || this.props.value) ? 'animate' : ''} ${
                    this.props.error ? 'invalid' : ''
                    }`}
            >
                <input
                    autoComplete={this.props.autocomplete}
                    type={this.state.type}
                    id={this.props.id}
                    onFocus={this.Focus}
                    name={this.props.name}
                    onBlur={this.Blur}
                    onChange={this.Change}
                    value={this.props.value ? this.props.value : ''}
                    className="sh-control"
                    tabIndex={this.props.tabIndex}
                    min={this.min}
                    max={this.max}
                    pattern={this.pattern}
                    disabled = {this.props.disabled}
                />
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

export default Input
