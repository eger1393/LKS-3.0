import React, { Component } from 'react';
import PropTypes from 'prop-types'
import CreatableSelect from 'react-select/lib/Creatable'
import { Container } from './styled'


const createOption = (value) => ({
    label: value,
});

export default class CreatableAdvanced extends Component {
    state = {
        options: this.props.data,
        value: this.props.value,
    }
    handleChange = (newValue, actionMeta) => {
        console.group('Value Changed');
        console.log(newValue);
        console.log(`action: ${actionMeta.action}`);
        console.groupEnd();
        this.setState({ value: newValue });
        var val = (newValue) ? newValue.label : null;
        this.props.onChange({
            target: {
                id: this.props.id, value: val,
            }
        })
    };
    handleCreate = (inputValue) => {
        this.setState({ isLoading: true });
        console.group('Option created');
        console.log('Wait a moment...');
     
        const { options } = this.state;
        const newOption = createOption(inputValue);
            console.log(newOption);
            console.groupEnd();
            this.setState({
                isLoading: false,
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
                    isDisabled={isLoading}
                    isLoading={isLoading}
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