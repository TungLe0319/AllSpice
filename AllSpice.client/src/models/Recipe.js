import { Account } from "./Account.js";

export class Recipe {
  constructor(data) {
    this.id = data.id;
    this.title = data.title;
    this.img = data.img;
    this.instructions = data.instructions;
    this.ingredients = this.ingredients;
    this.creator = new Account(data.creator);
    this.creatorId = data.creatorId;
    this.archived = data.archived || false
    this.category = data.category
  }
}
