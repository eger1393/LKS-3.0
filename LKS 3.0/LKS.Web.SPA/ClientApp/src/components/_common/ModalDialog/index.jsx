import React, { useEffect } from 'react';
import Modal from 'react-modal'
import PropTypes from 'prop-types'

import FormHead from '../elements/FormHead'
import { ModalContainer, Content } from './styled';

const constStyles = {
  content: {
    top: 'calc(100% - 90vh)',
    left: '50%',
    right: 'auto',
    bottom: 'auto',
    transform: 'translate(-50%, 0)',
    padding: '8px',
    border: '0',
    overflow: 'hide'
  },
  overlay: {
    background: 'rgba(0, 0, 0, 0.75)',
    zIndex: '9999'
  },
}
Modal.setAppElement('#root')
const ModalDialog = props => {
  var { show, onHide, customStyles, children, header, crossOnly } = props;
  customStyles = customStyles || {};
  return (
    <Modal
      isOpen={show}
      onRequestClose={!crossOnly && onHide}
      style={{...constStyles, ...customStyles}}
    >
      <ModalContainer ref={props.modalRef}>
        {header && (<FormHead handleClick={onHide}>{header}</FormHead>)}
        <Content >{children}</Content>
      </ModalContainer>
    </Modal>
  );
}

ModalDialog.propTypes = {
  show: PropTypes.bool,
  onHide: PropTypes.func,
  /** Заголовок окна */
  header: PropTypes.string,
  /** Ссылка на контейнер, сейчас исспользуется для фикса смещения контекстного меню */
  modalRef: PropTypes.any,
  /** При значении true, закрывается только нажатием на крестик */
  crossOnly: PropTypes.bool,
}
export default ModalDialog