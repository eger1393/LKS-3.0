import React from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { fetchSetStudentPhoto } from '../../../../../redux/modules/addStudent'
import { getAddStudentFieldValue } from '../../../../../selectors/addStudent'


import Cropper from './Cropper'

class Photo extends React.Component {
  state = {
    file: undefined,
    imagePreviewUrl: '',
    cropperWindow: false
  };


  hadleCropSaveImage = image => {
    image.toBlob(
      img => {
        this.setState({
          imagePreviewUrl: image.toDataURL(),
          file: img,
          cropperWindow: false,
        })
        this.props.fetchSetStudentPhoto(img);
      },
      'image/jpeg',
      1
    )
  }

  _handleImageChange(e) {
    e.preventDefault();

    let reader = new FileReader();
    let file = e.target.files[0];

    reader.onloadend = () => {
      this.setState({
        file: file,
        imagePreviewUrl: reader.result,
        cropperWindow: true,
      });
    }

    reader.readAsDataURL(file)
  }

  render() {
    let { imagePreviewUrl, cropperWindow } = this.state;
    let { imagePath } = this.props;
    let $imagePreview = null;
    if (imagePreviewUrl || imagePath) {
      $imagePreview = (<img src={imagePreviewUrl ? imagePreviewUrl : imagePath} />);
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
        {cropperWindow && (<Cropper isOpen={cropperWindow} src={imagePreviewUrl} saveImage={this.hadleCropSaveImage} />)}
      </div>
    )
  }
}

Photo.props = {
  imagePath: PropTypes.str,
}

 const mapStateToProps = (store) => ({
  imagePath: getAddStudentFieldValue(store, 'imagePath')
})


export default connect(mapStateToProps, { fetchSetStudentPhoto })(Photo)