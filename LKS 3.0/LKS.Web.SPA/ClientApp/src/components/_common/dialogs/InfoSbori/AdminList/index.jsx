import React from "react";
import ReactDataGrid from "react-data-grid";
import {AgGridReact} from 'ag-grid-react';

import 'ag-grid/dist/styles/ag-grid.css';
import 'ag-grid/dist/styles/ag-theme-material.css';
import { apiGetAdminList, apiSetAdminList } from '../../../../../api/sbori'
import Button from "../../../elements/Button";
//import "./styles.css";

const defaultColumnProperties = {
  resizable: true,
  width: 120
};

const columns = [
  { field: "id", headerName: "Id" },
  { field: "command", headerName: "Команда" },
  { field: "collness", headerName: "Должность" },
  { field: "middleName", headerName: "Фамилия" },
  { field: "firstName", headerName: "Имя"},
  { field: "lastName", headerName: "Отчество"},
  { field: "rank", headerName: "Звание" },
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

  handleSave = () =>
  {
    apiSetAdminList(this.state.rows);
  }


  render() {
    return (
      <div
				className="ag-theme-material"
				style={{
					height: '500px',
					width: '600px'
				}}
			>
        <AgGridReact>
          columnDefs={columns}
					rowData={this.state.rows}>
        </AgGridReact>
      <Button value="Сохранить" onClick={(e) => this.handleSave(e)} />
      </div>
    );
  }
}

export default AdminList