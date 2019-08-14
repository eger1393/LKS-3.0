import React, { Component } from 'react';
import PropTypes from 'prop-types'
import CreatableSelect  from 'react-select/creatable'
import { Container } from './styled'

const createOption = (value) => ({
    label: value,
});

export default class CreatableAdvanced extends Component {
    state = {
        options: this.props.data,
        value: this.props.value,
    }
    handleChange = (setValue, actionMeta) => {
       
        this.setState({ value: setValue });

        var val = (setValue) ? setValue.label : null;

        this.props.onChange({
            target: {
                id: this.props.id, value: val,
            }
        })
    };
    handleCreate = (inputValue) => {
        const { options } = this.state;
        const newOption = createOption(inputValue);

            this.setState({
                options: [...options, newOption],
                value: newOption,
        });
        var val = newOption.label;
        this.props.onChange({
            target: {
                id: this.props.id, value: val,
            }
        })
        
    };
    render() {
        const { isLoading, options, value } = this.state;
        return (
            <Container>
                <CreatableSelect className="custom-style"
                    isClearable
                    onChange={this.handleChange}
                    onCreateOption={this.handleCreate}
                    options={options}
                    value={this.props.data.filter(option => option.label === this.props.value)}
                    placeholder={this.props.placeholder}
                />
                </Container>
        );
    }
}

CreatableAdvanced.props = {
    id: PropTypes.string,
    value: PropTypes.string,
    options: PropTypes.Array,
    onChange: PropTypes.func,
    placeholder: PropTypes.string,
}