import { Account } from "./Account.js";

export class Recipe {
  constructor(data) {
    this.id = data.id;
    this.title = data.title;
    this.img = data.img;
    this.instructions = data.instructions;
    // this.ingredients = data.ingredients;
    this.creator = new Account(data.creator);
    this.creatorId = data.creatorId;

    this.category = data.category;
    this.favorited = data.favorited || false;
this.favoriteId=data.favoriteId || null
    // this.accountId = data.accountId;
  }
}
