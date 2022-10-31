import { Account } from "./Account.js";

export class Comment {
  constructor(data) {
    this.id = data.id;
    this.body = data.body;
    this.recipeId = data.recipeId;
    this.creator = new Account(data.creator) || null;
  }
}
