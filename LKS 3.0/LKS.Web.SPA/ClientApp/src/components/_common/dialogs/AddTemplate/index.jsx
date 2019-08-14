import React  from "react";
import { FlexBox, FlexRow } from '../../elements/StyleDialogs/styled'
import Autocomplete from '../../elements/Autocomplete'
import { Container } from "../../NavBar/styled";
import CreatableSelect from 'react-select/creatable'





class AddTemplate extends React.Component {

    state = {
        file: {},
        categories: [],
        templateTypes: [],
        selectedCategory: null,
        selectedTemplateTypeId: null
    }
    
    changeSelectTemplateType = event => {
        console.log(event)

        var id = event.target.value;
          
        this.setState({ selectedTemplateTypeId: id})
        
    }

    changeSelectCategory = event => {
        console.log(event)

        var id = event.target.value;
          
        this.setState({ selectedCategory: id})
        
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
            categories: [{ id: 1, label: "1 категория" }, { id: 2, label: "2 категория" }],
            templateTypes: [{ value: 1, label: "1 тип" }, { value: 2, label: "2 тип" }] })
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
                                        onChange={this.changeSelectCategory}
                                        placeholder="Категория шаблона"
                                        value={this.state.selectedCategory}
                                    />)}
                        </div>
                        <div>
                            {
                                this.state.templateTypes.length != 0 && (
                                    <CreatableSelect id="listTypes"
                                        options={this.state.templateTypes}
                                        onChange={this.changeSelectTemplateType}
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