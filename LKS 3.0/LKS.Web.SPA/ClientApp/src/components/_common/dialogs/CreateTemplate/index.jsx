import React  from "react";
import { FlexBox, FlexRow } from '../../elements/StyleDialogs/styled'
import CreatableSelect from 'react-select/creatable'
import Select from 'react-select'
import ModalDialog from "../../ModalDialog";
import { Container } from './styled'
import Button from "../../elements/Button";
import Input from "../../elements/Input";
import {getTypeTemplateValue} from '../../../../helpers/index'
import { apiUpdateTemplate, apiGetCategories, apiGetTypes } from '../../../../api/templates'

class CreateTemplate extends React.Component {

    state = {
        file: {},
        categories: [],
        subcategories: [],
        templateTypes: [],
        templateName: null,
        selectedCategory: null,
        selectedSubcategory: null,
        selectedTemplateType: null
    }
    
    changeSelectTemplateType = value => {
        this.setState({ selectedTemplateType: value})  
    }
    changeSelectTemplateName = event =>
    {
        this.setState({ templateName: event.target.value})  
    }
    changeSelectCategory = value => {
        this.setState({ selectedCategory: value, subcategories: value.subcategories })

        if(this.state.selectedSubcategory != null)
        {
            this.setState({ selectedSubcategory: null})
        }
    }
    changeSelectSubcategory = value =>
    {
        this.setState({ selectedSubcategory: value})  
    }
    
    componentDidMount() {
        var self = this;
        apiGetCategories().then(res =>
            self.setState({ categories: res.filter(x => x.subcategories.length != 0) }));
        apiGetTypes().then(res =>
                self.setState({ templateTypes: res.map(x => ({id: x, label: getTypeTemplateValue(x)})) }));
    }



    handleFileChange = e => {
        e.preventDefault();

        let reader = new FileReader();
        let file = e.target.files[0];

        reader.onloadend = () => {
            this.setState({file: file, templateName: file.name.replace(/\.[^.]+$/, "") })
        }

        reader.readAsDataURL(file)
    }

    handleSave = e =>
    {
        apiUpdateTemplate({ category: this.state.selectedCategory.label,
            subcategory: this.state.selectedSubcategory.label, 
            enumType: this.state.selectedTemplateType.id,
            templateName: this.state.templateName,
            templateFile: this.state.file
        });
        // .then(function () {
        //     this.setState({
        //         successModal: true,
        //     })
        //   })
    }
    render() {
        return (
            <ModalDialog header="Добавление шаблона" show ={this.props.show} onHide={this.props.onHide} >
                <FlexBox className="flex-box">
                    <FlexRow>
                        <div>
                            <label>Выберите файл шаблона</label>
                            <input type="file" id="fileUpload" style={{width: "100%"}} onChange={(e) => this.handleFileChange(e)}/>
                        </div>
                        
                    </FlexRow>
                    <FlexRow>
                    <div>
                            <Input id="templateName"
                                type="text"
                                isRequired={true}
                                placeholder="Имя шаблона"
                                value={this.state.templateName}
                                onChange={this.changeSelectTemplateName}>
                            </Input>
                        </div>
                        <div>
                            <Container>
                            {
                                this.state.templateTypes.length != 0 && (
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
                        <Container>
                            {
                                this.state.categories.length != 0 && (
                                    <CreatableSelect id="listCategories" className="custom-style"
                                        options={this.state.categories}
                                        onChange={this.changeSelectCategory}
                                        placeholder="Основная категория"
                                        value={this.state.selectedCategory}
                                    />)}
                                    </Container>
                        </div>
                        <div>
                        <Container>
                            {
                                this.state.categories.length != 0 && (
                                    <CreatableSelect isClearable id="listSubcategories" className="custom-style"
                                        options={this.state.subcategories}
                                        onChange={this.changeSelectSubcategory}
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
             </ModalDialog>
        );
    }
}
export default CreateTemplate