import React, { Component } from 'react';
import PropTypes from 'prop-types'
import { Container } from './styled'
import { Checkbox } from 'react-bootstrap'

export default class CheckBox extends Component {
    Change = (val) => {
    this.props.onChange({
        target: {
            id: this.props.id, value: val.target.checked,
        }
    })
    }

    render() {
        return (
                <Checkbox
                id={this.props.id}
                inline={this.props.inline}
                onChange={this.Change}
                checked={this.props.value} >
                {this.props.title}
                </Checkbox>
        );
    }
}

CheckBox.props = {
    id: PropTypes.string,
    title: PropTypes.string,
    inline: PropTypes.boolean,
}