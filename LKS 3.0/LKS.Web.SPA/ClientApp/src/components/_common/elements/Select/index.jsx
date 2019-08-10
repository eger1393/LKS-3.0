import React, { useState } from 'react'
import PropTypes from 'prop-types'

import { Container } from './styled'

const Select = props => {
    const [isFocus, setIsFocus] = useState(false)

    const handleFocus = () => setIsFocus(true)

    const handleBlur = event => {
        if (event.target.value === '')
            setIsFocus(false)
    }
    const { value, text, selectedValue, id, data, placeholder, isRequired } = props
    return (
        <Container
            className={`${(isFocus || selectedValue !== undefined) ? 'animate' : ''} ${
                props.error ? 'invalid' : ''
                }`}
        >
            <select
                value={selectedValue}
                onChange={props.onChange}
                id={id}
                onFocus={handleFocus}
                onBlur={handleBlur}
            >
                <option disabled selected></option>
                {data && data.map(ob => {
                    return (
                        <option value={ob[value]}>{ob[text]}</option>
                    )
                })}
            </select>
            <label
                htmlFor={id}
                unselectable="on"
                className="label-for-input"
            >
                {placeholder}
                {isRequired ? <span className="red-star">*</span> : ''}
            </label>
            <span className="layer">!</span>
        </Container>

    );
}
Select.props = {
    placeholder: PropTypes.string,
    id: PropTypes.string,
    data: PropTypes.array,
    value: PropTypes.string,
    selectedValue: PropTypes.string,
    text: PropTypes.string,
    isRequired: PropTypes.bool,
    error: PropTypes.bool,
    onChange: PropTypes.func,
}

Select.defaultProps = {
    key: 'id',
    value: 'val',
    isRequired: false,
    error: false,
}

export default Select
