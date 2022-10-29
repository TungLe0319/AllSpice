import { Account } from "./Account.js";
import { Recipe } from "./Recipe.js";

export class FavRecipe {
  constructor(data) {
    this.id = data.id;
// this.favorited=data.favorited || false;
    this.recipeId = data.recipeId;
    this.accountId = data.accountId;
  }
}
