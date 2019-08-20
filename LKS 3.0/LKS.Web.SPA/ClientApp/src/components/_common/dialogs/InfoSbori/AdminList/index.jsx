import React from "react";
import ReactDataGrid from "react-data-grid";
import { apiGetAdminList, apiSetAdminList } from '../../../../../api/sbori'
import Button from "../../../elements/Button";
//import "./styles.css";

const defaultColumnProperties = {
  resizable: true,
  width: 120
};

const columns = [
  { key: "id", name: "Id", editable: false },
  { key: "command", name: "Команда", editable: false },
  { key: "collness", name: "Должность", editable: true },
  { key: "middleName", name: "Фамилия", editable: true },
  { key: "firstName", name: "Имя", editable: true },
  { key: "lastName", name: "Отчество", editable: true },
  { key: "rank", name: "Звание", editable: true },
].map(c => ({ ...c, ...defaultColumnProperties }));



class AdminList extends React.Component {
  state = { 
    rows: [],
   };

  componentDidMount() {
    var self = this;
    apiGetAdminList()
        .then(
            data => self.setState(
                { rows: data }
            ))
    
}
  onGridRowsUpdated = ({ fromRow, toRow, updated }) => {
    this.setState(state => {
      const rows = state.rows.slice();
      for (let i = fromRow; i <= toRow; i++) {
        rows[i] = { ...rows[i], ...updated };
      }
      return { rows };
    });
  };

  handleSave = () =>
  {
    apiSetAdminList(this.state.rows);
  }


  render() {
    return (
      <div>
        <ReactDataGrid
        columns={columns}
        rowGetter={i => this.state.rows[i]}
        rowsCount={this.state.rows.length}
        onGridRowsUpdated={this.onGridRowsUpdated}
        enableCellSelect={true}
      />
      <Button value="Сохранить" onClick={(e) => this.handleSave(e)} />
      </div>
    );
  }
}

export default AdminList