import React from "react";

import { apiGetAdminList, apiSetAdminList } from '../../../../../api/sbory'
import Button from "../../../elements/Button";
import Input from "../../../elements/Input";
import { Container } from "./styled.js";
import SuccessModal from "../SuccessModal";


class AdminList extends React.Component {
  state = { 
    rows: [],
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
    apiGetAdminList()
        .then(
            data => self.setState(
                { rows: data }
            ))
    
  }
  
  changeField = event =>
  {
    let { rows } = this.state;
    let admin = rows.filter( x => x.id === event.target.id);
    admin[0][event.target.name] = event.target.value;
    this.setState({...rows, admin});
  }

  handleSave = () =>
  {
    let self = this;
    apiSetAdminList( { admins: this.state.rows })
    .then(function () {
      self.setState({
          successModal: true,
      })
    })
  }


  render() {
    return (
      <div>
       <Container>
         <table>
           <thead>
                <tr>
                    <th> Команда </th>
                    <th> Должность </th>
                    <th> Фамилия </th>
                    <th> Имя </th>
                    <th> Отчество </th>
                    <th> Звание </th>
                </tr>
          </thead>
          <tbody>
                {this.state.rows.length > 0 && (
                    this.state.rows.map(ob => {
                        return (
                          <tr>
                            <td className="select-color">
                                    {ob.command}
                                </td>
                            <td className="select-color">
                                    <Input
                                      type="text"
                                      id={ob.id}
                                      value={ob.collness}
                                      name="collness"
                                     
                                      onChange={this.changeField}
                                      />
                                </td>
                                <td className="select-color">
                                    <Input
                                      type="text"
                                      id={ob.id}
                                      value={ob.lastName}
                                      name="lastName"
                                      
                                      onChange={this.changeField}
                                      />
                                </td>
                                <td className="select-color">
                                      <Input
                                      type="text"
                                      id={ob.id}
                                      value={ob.firstName}
                                      name="firstName"
                                      
                                      onChange={this.changeField}
                                      />
                                </td>
                                <td className="select-color">
                                      <Input
                                      type="text"
                                      id={ob.id}
                                      value={ob.middleName}
                                      name="middleName"
                                     
                                      onChange={this.changeField}
                                      />
                                </td>
                                <td className="select-color">
                                      <Input
                                      type="text"
                                      id={ob.id}
                                      value={ob.rank}
                                      name="rank"
                                      
                                      onChange={this.changeField}
                                      />
                                </td>
                          </tr>
                                )}))}
          </tbody>
        </table>
            </Container>
      <Button value="Сохранить" onClick={(e) => this.handleSave(e)} />
      {this.state.successModal && (<SuccessModal isOpen={this.state.successModal} isOk={this.closeModal} onHide={this.closeModal} />)}
      </div>
    );
  }
}

export default AdminList;