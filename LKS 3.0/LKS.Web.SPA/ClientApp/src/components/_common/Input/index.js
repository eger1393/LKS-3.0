import React from 'react'
import { Container } from './styled'

type InputProps = {
  type: string,
  placeholder: string,
  id: string,
  isRequired?: boolean,
  error?: boolean,
  onChange?: Function,
}

class Input extends React.Component<InputProps> {
  state = { isFocus: false }

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
        <input
          autoComplete={this.props.autocomplete}
          type={this.props.type}
          id={this.props.id}
          onFocus={this.Focus}
          name={this.props.name}
          onBlur={this.Blur}
          onChange={this.props.onChange}
          className="sh-control"
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
