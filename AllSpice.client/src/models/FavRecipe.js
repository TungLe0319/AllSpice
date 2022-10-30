import { Account } from "./Account.js";
import { Recipe } from "./Recipe.js";

export class FavRecipe  {
  constructor(data) {
    this.id = data.id;
    this.recipeId = data.recipeId;
    this.accountId = data.accountId;
  }
}


// export class FavRecipe extends Recipe {
//   super(data) {
//     this.favoriteId = data.id;
//     this.recipeId = data.recipeId;
//     this.accountId = data.accountId;
//   }
// }
