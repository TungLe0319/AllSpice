import { Account } from "./Account.js";

export class Instruction {
  constructor(data) {
    this.id = data.id;
    this.step = data.step;
    this.recipeId = data.recipeId;
    this.creator = new Account(data.creator) ;
  }
}
