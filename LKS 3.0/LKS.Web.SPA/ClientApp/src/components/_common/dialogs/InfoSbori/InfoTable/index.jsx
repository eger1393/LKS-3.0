import React from "react";
import { apiGetSummerSboryInfo, apiSetSummerSboryInfo } from '../../../../../api/sbory'
import Button from "../../../elements/Button";
import Input from "../../../elements/Input";
import { Container } from "./styled.js";
import { FlexBox, FlexRow } from "../../../elements/StyleDialogs/styled";
import SuccessModal from "../SuccessModal";


class InfoTable extends React.Component {
  state = { 
    info: {},
    successModal: false,
   };

   closeModal = e => {
    this.setState({
        successModal: false,
    });
    this.props.onHide();
}

  componentDidMount() {
    var self = this;
    apiGetSummerSboryInfo()
        .then(
            data => self.setState(
                { info: data }
            ))
    
  }
  
  changeField = event =>
  {
    let { info } = this.state;
    info[event.target.name] = event.target.value;
    this.setState ( {info: {...info}});
  }

  handleSave = () =>
  {
    let self = this;
    apiSetSummerSboryInfo(this.state.info).then(function () {
      self.setState({
          successModal: true,
      })
    })
  }


  render() {
    let { info } = this.state;
    return (
       <Container>
        <FlexBox>
          <FlexRow>
          <Input
            type="text"
            value={info.numberofOrder}
            name="numberofOrder"
            onChange={this.changeField}
            placeholder = "Номер приказа"
            />
             <Input
            type="text"
            value={info.dateOfOrder}
            name="dateOfOrder"
            onChange={this.changeField}
            placeholder = "Дата приказа"
            />
             <Input
            type="text"
            value={info.textOrder}
            name="textOrder"
            onChange={this.changeField}
            placeholder = "Текст приказа"
            />
          </FlexRow>
          <FlexRow>
          <Input
            type="text"
            value={info.dateBeginSbori}
            name="dateBeginSbori"
            onChange={this.changeField}
            placeholder = "Дата начала сборов"
            />
             <Input
            type="text"
            value={info.dateEndSbori}
            name="dateEndSbori"
            onChange={this.changeField}
            placeholder = "Дата окончания сборов"
            />
             <Input
            type="text"
            value={info.datePrisyaga}
            name="datePrisyaga"
            onChange={this.changeField}
            placeholder = "Дата присяги"
            />
          </FlexRow>
          <FlexRow>
          <Input
            type="text"
            value={info.dateExamen}
            name="dateExamen"
            onChange={this.changeField}
            placeholder = "Дата экзамена"
            />
             <Input
            type="text"
            value={info.numberVK}
            name="numberVK"
            onChange={this.changeField}
            placeholder = "Номер военной части"
            />
             <Input
            type="text"
            value={info.locationVK}
            name="locationVK"
            onChange={this.changeField}
            placeholder = "Расположение военной части"
            />
          </FlexRow>
          <FlexRow>
          <Input
            type="text"
            value={info.bmpKr}
            name="bmpKr"
            onChange={this.changeField}
            placeholder = "Боевая машина (кратко)"
            />
             <Input
            type="text"
            value={info.bmpFull}
            name="bmpFull"
            onChange={this.changeField}
            placeholder = "Боевая машина (полное)"
            />
           
          </FlexRow>
        </FlexBox>
        <Button value="Сохранить" onClick={(e) => this.handleSave(e)} />
        {this.state.successModal && (<SuccessModal isOpen={this.state.successModal} isOk={this.closeModal} onHide={this.closeModal} />)}
       </Container>
    );
  }
}

export default InfoTable;