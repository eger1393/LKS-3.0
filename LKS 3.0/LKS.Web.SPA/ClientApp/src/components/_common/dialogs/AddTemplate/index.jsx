import React  from "react";
import { FlexBox, FlexRow } from '../../elements/StyleDialogs/styled'
import Autocomplete from '../../elements/Autocomplete'
import { Container } from "../../NavBar/styled";




class AddTemplate extends React.Component {

    state = {
        file: {},
        categories: [],
        templateTypes: [],
        selectedCategoryId: null,
        selectedTemplateTypeId: null
    }
    
    changeSelect = event => {
        console.log(event)

        var id = event.target.id,
            val = event.target.value;
        
    }
       
    componentWillMount() {
        if (this.isUnmounted) {
            return;
        }
        var self = this;
        //apiGetInstGroupList().then(res =>
        //    self.setState({ instGroup: res })
        //);
        self.setState({
            categories: [{ id: 1, value: "1 категория" }, { id: 2, value: "2 категория" }],
            templateTypes: [{ id: 1, value: "1 тип" }, { id: 2, value: "2 тип" }] })
    }

    componentWillUnmount() {
        this.isUnmounted = true;
    }

    handleImageChange = e => {
        e.preventDefault();

        let reader = new FileReader();
        let file = e.target.files[0];

        reader.onloadend = () => {
            this.setState({file: file})
        }

        reader.readAsDataURL(file)
    }

    handleSave = e => {
        e.preventDefault();
        //todo
    }

    render() {
        return (
            <Container>
                <FlexBox className="flex-box">
                    <FlexRow>
                        <div>
                            <p>Выберите файл шаблона!</p>
                            <input className="fileInput"
                                type="file"
                                onChange={(e) => this.handleImageChange(e)} />

                        </div>
                    </FlexRow>
                    <FlexRow>
                        <div>
                            {
                                this.state.categories.length != 0 && (
                                    <Autocomplete id="listCategories"
                                        data={this.state.categories}
                                        onChange={this.changeSelect}
                                        placeholder="Категория шаблона"
                                        value={this.state.selectedCategoryId}
                                    />)}
                        </div>
                        <div>
                            {
                                this.state.templateTypes.length != 0 && (
                                    <Autocomplete id="listTypes"
                                        data={this.state.templateTypes}
                                        onChange={this.changeSelect}
                                        placeholder="Тип шаблона"
                                        value={this.state.selectedTemplateTypeId}
                                    />)}
                        </div>
                    </FlexRow>
                    <FlexRow>
                        <button className="saveButton"
                            type="button"
                            onClick={(e) => this.handleSave(e)}>Сохранить</button>
                    </FlexRow>
                </FlexBox>
            </Container>
        );
    }
}
export default AddTemplate