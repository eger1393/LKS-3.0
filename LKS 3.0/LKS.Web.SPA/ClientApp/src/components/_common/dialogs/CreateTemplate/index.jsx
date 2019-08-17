import React  from "react";
import { FlexBox, FlexRow } from '../../elements/StyleDialogs/styled'
import CreatableSelect from 'react-select/creatable'
import Select from 'react-select'
import ModalDialog from "../../ModalDialog";
import { Container, ErrorInput } from './styled'
import Button from "../../elements/Button";
import Input from "../../elements/Input";
import {getTypeTemplateValue} from '../../../../helpers/index'
import { apiUpdateTemplate, apiGetCategories, apiGetTypes } from '../../../../api/templates'
import SuccessModal from "./SuccessModal";

class CreateTemplate extends React.Component {

    state = {
        file: {},
        categories: [],
        subcategories: [],
        templateTypes: [],
        selectedTemplateName: null,
        selectedCategory: null,
        selectedSubcategory: null,
        selectedTemplateType: null,
        successModal: false,
        error: {},
    }
    
    changeSelectTemplateType = value => {
        this.setState({ selectedTemplateType: value})  
    }
    changeSelectTemplateName = event =>
    {
        this.setState({ selectedTemplateName: event.target.value})  
    }

    changeSelectCategory = value => {

        this.setState({ selectedCategory: value })
        apiGetCategories(value.id)
        .then(
            data => this.setState(
                { subcategories: data.map(x => ({id: x.id, label: x.name}))}
                )) 

        if(this.state.selectedSubcategory != null)
        {
            this.setState({ selectedSubcategory: null})
        }
    }
    
    changeSelectSubcategory = value =>
    {
        this.setState({ selectedSubcategory: value})  
    }
    
    handleCreateCategory = value =>
    {
        let {subcategories} = this.state;
        let newOption = ({id:null, label: value})
        this.setState({
            subcategories: [...subcategories, newOption],
            selectedSubcategory: newOption,
          });
    }

    handleCreateSubcategory = value =>
    {
        let {categories} = this.state;
        let newOption = ({id:null, label: value})
        this.setState({
            categories: [...categories, newOption],
            selectedCategory: newOption,
          });
    }

    componentDidMount() {
        var self = this;
        apiGetCategories()
        .then(
            data => self.setState(
                { categories: data.map(x => ({id: x.id, label: x.name}))}
                ))
        apiGetTypes().then(res =>
                self.setState({ templateTypes: res.map(x => ({id: x, label: getTypeTemplateValue(x)})) }));
    }

    validate = () => 
    {   
        let { selectedCategory,selectedSubcategory,selectedTemplateName,selectedTemplateType } = this.state;
      
        let stateErrors = { category: !!selectedCategory,
            subcategory: !!selectedSubcategory, 
            name: !!selectedTemplateName,
        type: !!selectedTemplateType };

        this.setState({ error: stateErrors})

        return Object.keys(stateErrors).every(function(k){ return stateErrors[k] });
    
    }

    handleFileChange = e => {
        e.preventDefault();

        let reader = new FileReader();
        let file = e.target.files[0];

        reader.onloadend = () => {
            this.setState({file: file, selectedTemplateName: file.name.replace(/\.[^.]+$/, "") })
        }

        reader.readAsDataURL(file)
    }

    handleSave = e =>
    {
        if(this.validate())
        {
            var self = this;
            apiUpdateTemplate({ 
                categoryId: self.state.selectedСategory.id, 
                categoryName: self.state.selectedСategory.label,
                subcategoryId: self.state.selectedSubcategory.id, 
                subcategoryName: self.state.selectedSubcategory.label,
                enumType: self.state.selectedTemplateType.id,
                templateName: self.state.templateName,
                templateFile: self.state.file
            })
            .then(function () {
                self.setState({
                    successModal: true,
                })
              })
        }
        
    }

    closeModal = e =>
    {
        this.setState({
            successModal: false,
        });
        this.props.onHide();
    }
    render() {
        return (
            <ModalDialog header="Добавление шаблона" show ={this.props.show} onHide={this.props.onHide} >
                <FlexBox className="flex-box">
                    <FlexRow>
                        <div>
                            <label>Выберите файл шаблона</label>
                            <input type="file"  id="fileUpload" style={{width: "100%"}} onChange={(e) => this.handleFileChange(e)}/>
                        </div>
                        
                    </FlexRow>
                    <FlexRow>
                    <div>
                    <ErrorInput error={!this.state.selectedTemplateName}>
                            <Input id="templateName"
                                type="text"
                                placeholder="Имя шаблона"
                                value={this.state.selectedTemplateName}
                                onChange={this.changeSelectTemplateName}>
                            </Input>
                    </ErrorInput>
                        </div>
                        <div>
                            <Container error={!this.state.selectedTemplateType}>
                            {
                                this.state.templateTypes.length !== 0 && (
                                    <Select isClearable id="listTypes" className="custom-style"
                                        options={this.state.templateTypes}
                                        onChange={this.changeSelectTemplateType}
                                        placeholder="Тип шаблона"
                                        value={this.state.selectedTemplateType}
                                    />)}
                            </Container>
                        </div>
                    </FlexRow>
                    <FlexRow>
                        <div>
                        <Container error={!this.state.selectedCategory}>
                            {
                                this.state.categories.length !== 0 && (
                                    <CreatableSelect id="listCategories" className="custom-style"
                                        options={this.state.categories}
                                        onChange={this.changeSelectCategory}
                                        onCreateOption={this.handleCreateCategory}
                                        placeholder="Основная категория"
                                        value={this.state.selectedCategory}
                                    />)}
                                    </Container>
                        </div>
                        <div>
                        <Container error={!this.state.selectedSubcategory}>
                            {
                                this.state.categories.length !== 0 && (
                                    <CreatableSelect isClearable id="listSubcategories" className="custom-style"
                                        options={this.state.subcategories}
                                        onChange={this.changeSelectSubcategory}
                                        onCreateOption={this.handleCreateSubcategory}
                                        placeholder="Категория шаблона"
                                        value={this.state.selectedSubcategory}
                                    />)}
                        </Container>
                        </div>
                    </FlexRow>
                    <FlexRow>
                        <Button value="Сохранить" onClick={(e) => this.handleSave(e)}/>
                    </FlexRow>
                </FlexBox>
                {this.state.successModal && (<SuccessModal isOpen={this.state.successModal} isOk={this.closeModal} onHide={this.closeModal} />)}
             </ModalDialog>
        );
    }
}
export default CreateTemplate