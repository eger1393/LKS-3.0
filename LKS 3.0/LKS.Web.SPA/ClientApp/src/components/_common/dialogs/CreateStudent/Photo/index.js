import React from 'react'
import PropTypes from 'prop-types'
import Input from '../../../elements/Input'
import Select from '../../../elements/Select'
import Autocomplete from '../../../elements/Autocomplete'
import { connect } from 'react-redux'
import { FlexBox, FlexRow } from '../../../elements/StyleDialogs/styled'
import { fetchSetValueForStudent } from '../../../../../redux/modules/AddStudent'
import { apiGetLanguagesList } from '../../../../../api/addStudent'
import { getAddStudentFieldsValue, getAddStudentErrorValues } from '../../../../../selectors/addStudent'
import { Container } from './styled'


class Photo extends React.Component {
    constructor(props) {
        super(props);
        this.state = { file: '', imagePreviewUrl: '' };
    }

    _handleSubmit(e) {
        //e.preventDefault();
        //var base64 = this.state.imagePreviewUrl;
        //this.props.fetchSetValueForStudent({ name: "photo", val: base64, error:false });
        //console.log('handle uploading-', this.state.file);
    }

    _handleImageChange(e) {
        e.preventDefault();

        let reader = new FileReader();
        let file = e.target.files[0];

        reader.onloadend = () => {
            this.setState({
                file: file,
                imagePreviewUrl: reader.result
            });
        }

        reader.readAsDataURL(file)
    }

    render() {
        let { imagePreviewUrl } = this.state;
        let $imagePreview = null;
        if (imagePreviewUrl) {
            $imagePreview = (<img src={imagePreviewUrl} />);
        } else {
            $imagePreview = (<div className="previewText">Выберите изображение</div>);
        }

        return (
            <div className="previewComponent">
                <form onSubmit={(e) => this._handleSubmit(e)}>
                    <input className="fileInput"
                        type="file"
                        onChange={(e) => this._handleImageChange(e)} />
                    <button className="submitButton"
                        type="submit"
                        onClick={(e) => this._handleSubmit(e)}>Загрузить</button>
                </form>
                <div className="imgPreview">
                    {$imagePreview}
                </div>
            </div>
        )
    }
}

Photo.props = {
    fieldValue: PropTypes.object,
    errorValues: PropTypes.object,
}

function mapStateToProps(store) {
    return {
        fieldValue: getAddStudentFieldsValue(store),
        errorValues: getAddStudentErrorValues(store),
    }
}

export default connect(mapStateToProps, { fetchSetValueForStudent })(Photo)