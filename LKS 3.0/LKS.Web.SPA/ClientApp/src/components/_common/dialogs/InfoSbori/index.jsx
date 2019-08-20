import React from 'react'
import { Tab, Tabs } from 'react-bootstrap'



import ModalDialog from '../../ModalDialog'
import AdminList from './AdminList';

class InfoSbori extends React.Component {
    state = {
        
    };
   

    render() {
        return (
            !this.props.loading &&
            (<ModalDialog
                show={this.props.show}
                onHide={this.props.onHide}
                header="Сборы">
                    <AdminList/>
                    {/* <Tabs defaultActiveKey={1} id="uncontrolled-tab-example" className="customTubs" >
                        <Tab eventKey={1} title="Информация">
                            <AdminList />
                        </Tab>
                        <Tab eventKey={2} title="Администрация">
                            <AdminList />
                        </Tab>
                    </Tabs> */}
            </ModalDialog>)
        );
    }
}

export default InfoSbori