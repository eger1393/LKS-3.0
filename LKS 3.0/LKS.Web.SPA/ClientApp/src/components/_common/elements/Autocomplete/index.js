﻿import React, { Component } from 'react';

import CreatableSelect from 'react-select/lib/Creatable';

const createOption = (label: string) => ({
    label,
    value: label.toLowerCase().replace(/\W/g, ''),
});

const defaultOptions = [
    createOption('One'),
    createOption('Two'),
    createOption('Three'),
];

export default class CreatableAdvanced extends Component {
    state = {
        isLoading: false,
        options: [],
        value: undefined,
    };

    componentWillMount() {
        this.setState({ options: this.props.data })
    }

    handleChange = (newValue: any, actionMeta: any) => {
        console.group('Value Changed');
        console.log(newValue);
        console.log(`action: ${actionMeta.action}`);
        console.groupEnd();
        this.setState({ value: newValue });
    };
    handleCreate = (inputValue: any) => {
        this.setState({ isLoading: true });
        console.group('Option created');
        console.log('Wait a moment...');
        setTimeout(() => {
            const { options } = this.state;
            const newOption = createOption(inputValue);
            console.log(newOption);
            console.groupEnd();
            this.setState({
                isLoading: false,
                options: [...options, newOption],
                value: newOption,
            });
        }, 1000);
    };
    render() {
        const { isLoading, options, value } = this.state;
        return (
            <CreatableSelect
                isClearable
                isDisabled={isLoading}
                isLoading={isLoading}
                onChange={this.handleChange}
                onCreateOption={this.handleCreate}
                options={options}
                value={value}
            />
        );
    }
}