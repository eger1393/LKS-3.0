import React, { useState, useEffect } from "react";
import Select from '../../elements/Select';
import { FlexBox, FlexRow } from '../../elements/StyleDialogs/styled'
import Autocomplete from '../../elements/Autocomplete'
import { Container } from "../../NavBar/styled";


export const AddTemplate = props => {

    let [file, setFile] = useState(null);

    let [categories, setCategory] = useState([]);

    let [selectedType, setSelectedType] = useState(null);

    let [selectedCategory, setSelectedCategory] = useState(null);

    const templateTypes = ["Первый тип", "Второй тип"];

    useEffect(() => {
        categories = [{ id: 1, name: "Test" }, { id: 2, name: "Test 2" }];
       
    }, []);

    const changeSelect = event => {
        console.log(event)

    }

    const handleImageChange = e => {
        e.preventDefault();

        let reader = new FileReader();
        let file = e.target.files[0];

        reader.onloadend = () => {
            setFile(file)
        }

        reader.readAsDataURL(file)
    }

    const handleSave = e => {
        e.preventDefault();
        //todo
    }

    return (
        <Container>
            <FlexBox className="flex-box">
                <FlexRow>
                    <div>
                        <p>Выберите файл шаблона!</p>
                        <input className="fileInput"
                            type="file"
                            onChange={(e) => handleImageChange(e)} />

                    </div>
                </FlexRow>
                <FlexRow>
                    <div>
                        {
                            categories && (
                                <Autocomplete id="listCategories"
                                    data={categories}
                                    onChange={e => setSelectedCategory(e.target.value)}
                                    placeholder="Категория шаблона"
                                    value={selectedCategory}
                                />)}
                    </div>
                    <div>
                        templateTypes && (
                                <Autocomplete id="listTypes"
                            data={templateTypes}
                            onChange={e => setSelectedType(e.target.value)}
                            placeholder="Тип шаблона"
                            value={selectedType}
                        />)}
                    </div>
                </FlexRow>
                <FlexRow>
                    <button className="saveButton"
                        type="button"
                        onClick={(e) => handleSave(e)}>Сохранить</button>
                </FlexRow>
            </FlexBox>
        </Container>
    );
}