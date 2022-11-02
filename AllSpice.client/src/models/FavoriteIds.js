import { Account } from "./Account.js";
import { Recipe } from "./Recipe.js";

export class FavoriteIds {
  constructor(data) {
    
    this.favoriteId = data.id;
    this.recipeId = data.recipeId;
    this.accountId = data.accountId;
  }
}

// export class FavRecipe extends Recipe {
//   constructor(data) {
//     super(data);
//     this.favoriteId = data.favoriteId;
//     this.recipeId = data.id;
//     this.accountId = data.accountId;
//   }
// }

