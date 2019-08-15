import { observable, computed, toJS, action, when, autorun } from 'mobx'

class TemplateListStore {
  constructor() {
    this.setDefaultValue()
  }

  @observable displayedContent = 'CategoryList';
  @observable categoryId;
  @observable subCategoryId;
  @observable selectedTemplate;
  @observable selectedTroos = [];
  @observable selectedStudents = [];

  @action setDefaultValue() {
    this.displayedContent = 'CategoryList'
    this.categoryId = undefined;
    this.subCategoryId = undefined;
    this.selectedTemplate = undefined;
    this.selectedStudents = [];
    this.selectedTroos = [];
  }

}

export default new TemplateListStore()
