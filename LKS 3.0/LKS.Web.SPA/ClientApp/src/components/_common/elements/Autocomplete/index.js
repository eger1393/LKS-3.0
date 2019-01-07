import React, { Component } from 'react';
import PropTypes from 'prop-types'
import CreatableSelect from 'react-select/lib/Creatable'
import { Container } from './styled'

type State = {
    options: [{ [string]: string }],
    value: string | void,
};

const createOption = (value: string) => ({
    label: value,
});
export default class CreatableAdvanced extends Component<*, State> {
    state = {
        isLoading: false,
        options: [],
        value: undefined,
    };
    componentWillMount() {
        this.setState({ options: this.props.data })
    };
    handleChange = (newValue: any, actionMeta: any) => {
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
    handleCreate = (inputValue: any) => {
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
                    value={value}
                    placeholder={this.props.placeholder}
                />
                </Container>
        );
    }
}

CreatableAdvanced.props = {
    id: PropTypes.string,
    data: PropTypes.array,
    onChange: PropTypes.func,
    placeholder: PropTypes.string,
}