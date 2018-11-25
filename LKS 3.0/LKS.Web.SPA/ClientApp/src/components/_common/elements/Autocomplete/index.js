import Autocomplete from 'react-autocomplete'
import React from 'react'
import { Container } from './styled'

export default class AutocompleteInput extends React.Component {

    constructor(props) {
        super(props)
        this.state = {
            value: this.props.value,
            isFocus: false,
        }
    }

   
    Focus = event => {
        this.setState({ isFocus: true })
    }

    Blur = event => {
        if (event.target.value === '') this.setState({ isFocus: false })
    }

    Change = event => {
        if (this.props.middlewareValidator === undefined || this.props.middlewareValidator(event)) {
            this.props.onChange(event);
        }
    }
      
    render() {
        return (
            
            <Autocomplete
                items={this.props.items}
                getItemValue={item => item}
                renderItem={(item) =>
                    <div>
                        {item}
                    </div>
                }
                className="sh-control"
                value={this.props.value}
                onFocus={this.Focus}
                onBlur={this.Blur}
                onChange={e => this.setState({ value: e.target.value })}
                onSelect={value => this.setState({ value })}
                />
                
        )
    }
}