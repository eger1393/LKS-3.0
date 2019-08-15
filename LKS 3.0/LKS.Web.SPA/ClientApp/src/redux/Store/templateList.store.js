import { observable, computed, toJS, action, when, autorun } from 'mobx'

class CreateRequest {
  constructor() {
    this.setDefaultValue()
  }

  @observable departure = {};

  @action setDefaultValue() {
  
  }

}

export default new CreateRequest()
